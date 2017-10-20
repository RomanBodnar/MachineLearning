using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class MainWindowModel
    {
        public MainWindowModel()
        {
            this.Title = "Example 2";
            this.Points = new List<DataPoint>
            {
                new DataPoint(0, 4),
                new DataPoint(10, 13),
                new DataPoint(20, 15),
                new DataPoint(30, 16),
                new DataPoint(40, 12),
                new DataPoint(50, 12)
            };
        }

        public string Title { get; private set; }

        public IList<DataPoint> Points { get; private set; }

        private List<DataPoint> GetPlotData()
        {
            throw new NotImplementedException();
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
                    //featureVector[i] = valueNormalizer.FeatureScaling(min, max, featureVector[j]);
                }
            }
           
            return null;
        }
    }
}
