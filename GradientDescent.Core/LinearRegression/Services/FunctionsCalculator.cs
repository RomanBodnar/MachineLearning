using System;
using System.Linq;
using GradientDescent.Core.LinearRegression.Contracts;
using GradientDescent.Data.DataSource;
using GradientDescent.Data.DataSource.Contracts;

namespace GradientDescent.Core.LinearRegression.Services
{
    public class FunctionsCalculator : IFunctionsCalculator
    {
        private readonly IValuesNormalizer valuesNormalizer;
        private readonly IDataSourceSupplier dataSupplier;
        private readonly IDataTransformer dataTransformer;

        public FunctionsCalculator()
        {
            this.valuesNormalizer = new ValueNormalizer();
            this.dataSupplier = new DataSourceSupplier();
            this.dataTransformer = new DataTransformer();
        }

        public FunctionsCalculator(
            IValuesNormalizer valuesNormalizer, 
            IDataSourceSupplier dataSupplier,
            IDataTransformer dataTransformer)
        {
            this.valuesNormalizer = valuesNormalizer;
            this.dataSupplier = dataSupplier;
            this.dataTransformer = dataTransformer;
        }

        public double Hypothesis(double[] features, double[] theta)
        {
            //double hypothesis = features[0] * theta[0] + features[1] * theta[1] + features[2] * theta[2] +
            //                    features[3] * theta[3] + features[4] * theta[4];
            double hypothesis = features.Zip(theta, (x, t) => x*t).Sum();
            return hypothesis;
        }

        public double CostFuction(double[] theta)
        {
            var trainingSet = this.dataSupplier.GetTrainingSet().ToList();
            var numberOfTrainingExamples = trainingSet.Count;
            double result = 0.0;
            for (int i = 1; i <= numberOfTrainingExamples; i++)
            {
                var features = trainingSet[i].Features.ToArray();
                result += Math.Pow(Hypothesis(features, theta) - trainingSet[i].Result, 2);
            }
            return 1 * result / (2 * numberOfTrainingExamples);
        }
    }
}
