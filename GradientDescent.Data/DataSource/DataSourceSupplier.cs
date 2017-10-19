using System;
using System.Collections.Generic;
using GradientDescent.Data.DataSource.Contracts;
using GradientDescent.Data.Models.LinearRegression;

namespace GradientDescent.Data.DataSource
{
    public class DataSourceSupplier : IDataSourceSupplier
    {
        public IEnumerable<TrainingElement> GetTrainingSet()
        { 
            throw new NotImplementedException();
        }
    }
}
