using System;
using System.Linq;
using GradientDescent.Core.Contracts;
using GradientDescent.Data.DataSource.Contracts;

namespace GradientDescent.Core.Services
{
    public class FunctionsCalculator : IFunctionsCalculator
    {
        private readonly IValuesNormalizer valuesNormalizer;
        private readonly IDataSourceSupplier dataSupplier;

        public FunctionsCalculator(IValuesNormalizer valuesNormalizer, IDataSourceSupplier dataSupplier)
        {
            this.valuesNormalizer = valuesNormalizer;
            this.dataSupplier = dataSupplier;
        }

        public double Hypothesis(double[] features, double[] theta)
        {
            double hypothesis = features[0] * theta[0] + features[1] * theta[1] + features[2] * theta[2] +
                                features[3] * theta[3] + features[4] * theta[4];
            return hypothesis;
        }

        public double CostFuction(double[] theta)
        {
            throw new NotImplementedException();
            //var houses = dataSupplier.GetData().ToList();
            //var numberOfTrainingExamples = houses.Count;
            //double result = 0.0;
            //for (int i = 1; i <= numberOfTrainingExamples; i++)
            //{
            //    var features = GetFeaturesVector(houses[i]);
            //    result += Math.Pow(Hypothesis(features, theta) - houses[i].Price, 2);
            //}
            //return 1 * result / (2 * numberOfTrainingExamples);
        }
    }
}
