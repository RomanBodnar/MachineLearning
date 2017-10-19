using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GradientDescent.Core.LinearRegression.Contracts;

namespace GradientDescent.Core.LinearRegression.Services
{
    public class ValueNormalizer : IValuesNormalizer
    {
        public double FeatureScaling(double min, double max, double value)
        {
            return value / (max - min);
        }

        public double MeanNormalization(double min, double max, double avg, double value)
        {
            return (value - avg) / (max - min);
        }

        public double GetAverage(IEnumerable<double> valueVector)
        {
            return valueVector.Average();
        }
    }
}
