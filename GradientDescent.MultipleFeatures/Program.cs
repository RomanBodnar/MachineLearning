using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradientDescent.Core.LinearRegression.Services;
using GradientDescent.Data.DataSource;
using GradientDescent.Data.Models.LinearRegression;
using MathNet.Numerics.LinearAlgebra;

namespace GradientDescent.MultipleFeatures
{
    // Step 1: Measure how well hypothesis fits using cost function where all thetas are 0
    // Step 2: Update thetas with gradient descent
    // Step 3: Call cost function and see how hypothesis fits now (compare values: new value must be lesser than previous)
    // Step 4: If new value lesser - go to step 2; otherwise go to step 5
    // Step 5: Apply new thetas for predicting unknown value

    // should plot convergence OxyPlot
    class Program
    {
        private static int NumberOfFeatures = 4 + 1;

        static void Main(string[] args)
        {
            var normalize = new ValueNormalizer();
            var dataTransformer = new DataTransformer();
            var dataSupplier = new DataSourceSupplier();
            

            var data = dataSupplier.GetTrainingSet().ToList();
            var trainingSet = GetNormalizedData();
            var functions = new FunctionsCalculator(trainingSet);
            var newHouse = new double[] { 1, 1203, 3 };
            double predictedPrice = 0.0;
            var actualPrice = 239500;
            var theta = new double[] { 89597.9027899082, 504777.895309395, -34952.0620218024 };

            for (int i = 1; i <= 2; i++)
            {
                var featureVector = dataTransformer.GetNthFeatureVector(data, i).ToArray();
                var min = featureVector.Min();
                var max = featureVector.Max();
                newHouse[i] = normalize.FeatureScaling(min, max, newHouse[i]);
            }


            predictedPrice = functions.Hypothesis(newHouse, theta);

            Console.WriteLine($"Actual price: {actualPrice}" );
            Console.WriteLine($"Predicted price: {predictedPrice}");
            Console.Read();
        }
        private static IEnumerable<TrainingElement> GetNormalizedData()
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
