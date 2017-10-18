using System.Collections.Generic;
using System.Linq;
using GradientDescent.Common;
using GradientDescent.Core.LinearRegression.Contracts;
using GradientDescent.Data.DataSource.Contracts;

namespace GradientDescent.Core.LinearRegression.Services
{
    public class GradientDescentCalculator : IGradientDescentCalculator
    {
        private readonly IFunctionsCalculator functions;
        private readonly IDataSourceSupplier dataSupplier;
        private readonly IDataTransformer dataTransformer;

        public GradientDescentCalculator(
            IFunctionsCalculator functions,
            IDataSourceSupplier dataSupplier,
            IDataTransformer dataTransformer)
        {
            this.functions = functions;
            this.dataSupplier = dataSupplier;
            this.dataTransformer = dataTransformer;
        }

        public double CalculateNewTheta(double[] theta, double alpha, int featureNumber)
        {
            var houses = this.dataSupplier.GetData().ToList();
            var numberOfTrainingExamples = houses.Count;

            double result = 0.0;
            for (int i = 0; i<numberOfTrainingExamples; i++)
            {
                var features = this.dataTransformer.GetFeaturesVector(houses[i]);
                result += (this.functions.Hypothesis(features, theta) - houses[i].Price) * features[featureNumber];
            }
            return (1 * alpha * result) / numberOfTrainingExamples;
        }

        public double[] Descent(double[] theta, double alpha)
        {
            List<double> newTheta = new List<double>();

            for (int i = 0; i < Constants.NumberOfFeatures; i++)
            {
                newTheta.Add(theta[i] - this.CalculateNewTheta(theta, alpha, i));
            }

            return newTheta.ToArray();
        }
    }
}
