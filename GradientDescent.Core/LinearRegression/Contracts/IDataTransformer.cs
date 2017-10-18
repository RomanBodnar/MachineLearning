using GradientDescent.Data.Entities;

namespace GradientDescent.Core.LinearRegression.Contracts
{
    public interface IDataTransformer
    {
        double[] GetFeaturesVector(House house);
    }
}
