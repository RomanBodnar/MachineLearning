﻿using System;
using System.Linq;
using GradientDescent.Core.LinearRegression.Contracts;
using GradientDescent.Data.DataSource.Contracts;

namespace GradientDescent.Core.LinearRegression.Services
{
    public class FunctionsCalculator : IFunctionsCalculator
    {
        private readonly IValuesNormalizer valuesNormalizer;
        private readonly IDataSourceSupplier dataSupplier;
        private readonly IDataTransformer dataTransformer;
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
            var houses = this.dataSupplier.GetData().ToList();
            var numberOfTrainingExamples = houses.Count;
            double result = 0.0;
            for (int i = 1; i <= numberOfTrainingExamples; i++)
            {
                var features = this.dataTransformer.GetFeaturesVector(houses[i]);
                result += Math.Pow(Hypothesis(features, theta) - houses[i].Price, 2);
            }
            return 1 * result / (2 * numberOfTrainingExamples);
        }
    }
}