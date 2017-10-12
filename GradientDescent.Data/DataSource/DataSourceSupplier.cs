using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradientDescent.Data.DataSource.Contracts;
using GradientDescent.Data.Entities;

namespace GradientDescent.Data.DataSource
{
    public class DataSourceSupplier : IDataSourceSupplier
    {
        public IEnumerable<House> GetData()
        {
            yield return new House
            {
                Size = 2104,
                NumberOfBedrooms = 5,
                NumberOfFloors = 1,
                Age = 45,
                Price = 460
            };
            yield return new House
            {
                Size = 1416,
                NumberOfBedrooms = 3,
                NumberOfFloors = 2,
                Age = 40,
                Price = 232

            };
            yield return new House
            {
                Size = 1534,
                NumberOfBedrooms = 3,
                NumberOfFloors = 2,
                Age = 30,
                Price = 315

            };
            yield return new House
            {
                Size = 852,
                NumberOfBedrooms = 2,
                NumberOfFloors = 1,
                Age = 36,
                Price = 178

            };
        }
    }
}
