using System.Collections.Generic;
using System.Linq;
using GradientDescent.Common;
using GradientDescent.Core.LinearRegression.Contracts;
using GradientDescent.Data.DataSource;
using GradientDescent.Data.DataSource.Contracts;
using GradientDescent.Data.Models.LinearRegression;

namespace GradientDescent.Core.LinearRegression.Services
{
    public class GradientDescentCalculator : IGradientDescentCalculator
    {
        private readonly IFunctionsCalculator functions;
        private readonly IDataSourceSupplier dataSupplier;
        private readonly IValuesNormalizer valuesNormalizer;

        public List<TrainingElement> trainingSet;

        public GradientDescentCalculator(IEnumerable<TrainingElement> trainingSet)
        {
            this.trainingSet = trainingSet.ToList();
            this.functions = new FunctionsCalculator(trainingSet);
            this.dataSupplier = new DataSourceSupplier();
        }

        public GradientDescentCalculator(
            IFunctionsCalculator functions,
            IDataSourceSupplier dataSupplier)
        {
            this.functions = functions;
            this.dataSupplier = dataSupplier;
        }

        // todo: consider make it Private
        public double CalculateNewTheta(double[] theta, double alpha, int featureNumber)
        {
            //var trainingSet = this.dataSupplier.GetTrainingSet().ToList();
            var numberOfTrainingExamples = trainingSet.Count;
           
            double result = 0.0;
            for (int i = 0; i < numberOfTrainingExamples; i++)
            {
                var features = trainingSet[i].Features.ToArray();
                result += (this.functions.Hypothesis(features, theta) - trainingSet[i].Result) * features[featureNumber];
            }
            return (1 * alpha * result) / numberOfTrainingExamples;
        }

        public double[] Descent(double[] theta, double alpha, int numberOfFeatures)
        {
            List<double> newTheta = new List<double>();

            for (int i = 0; i < numberOfFeatures; i++)
            {
                newTheta.Add(theta[i] - this.CalculateNewTheta(theta, alpha, i));
            }

            return newTheta.ToArray();
        }
    }
}
