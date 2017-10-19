using System.Collections.Generic;

namespace GradientDescent.Data.Models.LinearRegression
{
    public class TrainingElement
    {
        public IEnumerable<double> Features { get; set; }

        public double Result { get; set; }
    }
}
