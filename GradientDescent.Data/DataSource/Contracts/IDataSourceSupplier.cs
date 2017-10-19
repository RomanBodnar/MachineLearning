using System.Collections;
using System.Collections.Generic;
using GradientDescent.Data.Models.LinearRegression;

namespace GradientDescent.Data.DataSource.Contracts
{
    public interface IDataSourceSupplier
    {
        IEnumerable<TrainingElement> GetTrainingSet();
    }
}
