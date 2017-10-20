using System.Collections.Generic;

namespace GradientDescent.Data.Models.LinearRegression
{
    public class TrainingElement
    {
        public List<double> Features { get; set; }

        public double Result { get; set; }
    }
}
