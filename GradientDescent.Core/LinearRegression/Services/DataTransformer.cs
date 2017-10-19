using System;
using GradientDescent.Core.LinearRegression.Contracts;

namespace GradientDescent.Core.LinearRegression.Services
{
    public class DataTransformer : IDataTransformer
    {
        public double[] GetFeaturesVector()
        {
            throw new NotImplementedException();
            //return new double[]
            //{
            //    1,
            //    house.Size,
            //    house.NumberOfBedrooms,
            //    house.NumberOfFloors,
            //    house.Age
            //};
        }
    }
}
