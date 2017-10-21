using System;
using System.Collections.Generic;
using System.Linq;
using GradientDescent.Core.LinearRegression.Contracts;
using GradientDescent.Data.DataSource;
using GradientDescent.Data.DataSource.Contracts;
using GradientDescent.Data.Models.LinearRegression;

namespace GradientDescent.Core.LinearRegression.Services
{
    public class FunctionsCalculator : IFunctionsCalculator
    {
        private readonly IValuesNormalizer valuesNormalizer;
        private readonly IDataSourceSupplier dataSupplier;
        private readonly IDataTransformer dataTransformer;

        public List<TrainingElement> TrainingSet { get; set; }
        
        public FunctionsCalculator(IEnumerable<TrainingElement> trainingSet)
        {
            this.TrainingSet = trainingSet.ToList();
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
            //var trainingSet = this.dataSupplier.GetTrainingSet().ToList();
            var numberOfTrainingExamples = this.TrainingSet.Count;
            double result = 0.0;
            try
            {
                for (int i = 0; i < numberOfTrainingExamples; i++)
                {
                    var features = this.TrainingSet[i].Features.ToArray();
                    result += Math.Pow(Hypothesis(features, theta) - this.TrainingSet[i].Result, 2);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 1 * result / (2 * numberOfTrainingExamples);
        }
    }
}
