using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GradientDescent.Core.LinearRegression.Services;
using GradientDescent.Data.DataSource;
using GradientDescent.Data.Models.LinearRegression;
using GradientDescent.Plot.Annotations;
using OxyPlot;
using static System.ValueTuple;

namespace GradientDescent.Plot.ViewModels
{
    public class MainWindowModelLinearRegression
    {
        public MainWindowModelLinearRegression()
        {
            this.Title = "Example 2";
            this.Points = this.GetPlotData();
        }

        public string Title { get; private set; }

        public IList<DataPoint> Points { get; private set; }

        private List<DataPoint> GetPlotData()
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string filePath = @"DataSets\theta.txt";
            string fullPath = Path.Combine(projectPath, filePath);

            var trainingSet = this.GetNormalizedData();
            var resultList = new List<DataPoint>();
            var functionsCalculator = new FunctionsCalculator(trainingSet);
            var gradientDescentCalculator = new GradientDescentCalculator(trainingSet);

            double bound = 2043280050.60283;

            double alpha = 0.1;

            // todo: replace hardcoded number of values with dynamic initialization
            var theta = new double[] {0, 0, 0};

            try
            {
                double costFunctionResult = functionsCalculator.CostFuction(theta);
                int iteration = 1;
                resultList.Add(new DataPoint(iteration, costFunctionResult));
                do
                {
                    theta = gradientDescentCalculator.Descent(theta, alpha, 3);
                    costFunctionResult = functionsCalculator.CostFuction(theta);
                    iteration++;
                    resultList.Add(new DataPoint(iteration, costFunctionResult));
                    Console.WriteLine(costFunctionResult);
                } while (costFunctionResult > bound);

                File.WriteAllText(fullPath, string.Join(" ", theta));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return resultList;
        }

        private IEnumerable<TrainingElement> GetNormalizedData()
        {
            var dataSupplier = new DataSourceSupplier();
            var dataTransformer = new DataTransformer();

            var data = dataSupplier.GetTrainingSet().ToList();

            var valueNormalizer = new ValueNormalizer();
            var featuresCount = data.First().Features.Count() - 1;

           for (int i = 1; i <= featuresCount; i++)
            {
                var featureVector = dataTransformer.GetNthFeatureVector(data, i).ToArray();
                var min = featureVector.Min();
                var max = featureVector.Max();
                for (int j = 0; j < featureVector.Length; j++)
                {
                    data[j].Features[i] = valueNormalizer.FeatureScaling(min, max, featureVector[j]);
                }
            }
           
            return data;
        }
    }
}
