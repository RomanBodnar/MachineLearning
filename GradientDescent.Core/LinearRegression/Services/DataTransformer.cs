using System;
using System.Linq;
using System.Collections.Generic;
using GradientDescent.Core.LinearRegression.Contracts;
using GradientDescent.Data.Models.LinearRegression;

namespace GradientDescent.Core.LinearRegression.Services
{
    public class DataTransformer : IDataTransformer
    {
        public IEnumerable<double> GetNthFeatureVector(IEnumerable<TrainingElement> trainingSet, int featureNumber)
        {
            return trainingSet.Select(x => x.Features.ToList()[featureNumber]);
        }

        public IEnumerable<TrainingElement> GetTrainingSet(List<double[]> allFeatures)
        {
            var resultList = new List<TrainingElement>();



            return resultList;
        }
    }
}
