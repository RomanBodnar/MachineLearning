using GradientDescent.Data.Entities;

namespace GradientDescent.Core.Contracts
{
    public interface IDataTransformer
    {
        double[] GetFeaturesVector(House house);
    }
}
