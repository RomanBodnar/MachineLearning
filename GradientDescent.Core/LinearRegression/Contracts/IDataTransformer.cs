using System.Collections.Generic;
using GradientDescent.Data.Models.LinearRegression;

namespace GradientDescent.Core.LinearRegression.Contracts
{
    public interface IDataTransformer
    {
        IEnumerable<double> GetNthFeatureVector(IEnumerable<TrainingElement> trainingSet, int featureNumber);
    }
}
