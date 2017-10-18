using GradientDescent.Core.LinearRegression.Contracts;
using GradientDescent.Data.Entities;

namespace GradientDescent.Core.LinearRegression.Services
{
    public class DataTransformer : IDataTransformer
    {
        public double[] GetFeaturesVector(House house)
        {
            return new double[]
            {
                1,
                house.Size,
                house.NumberOfBedrooms,
                house.NumberOfFloors,
                house.Age
            };
        }
    }
}
