using System.Collections;
using System.Collections.Generic;
using GradientDescent.Data.Entities;

namespace GradientDescent.Data.DataSource.Contracts
{
    public interface IDataSourceSupplier
    {
        IEnumerable<House> GetData();
    }
}
