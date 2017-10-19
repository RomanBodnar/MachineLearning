using System.Collections.Generic;

namespace GradientDescent.Core.LinearRegression.Contracts
{
    public interface IValuesNormalizer
    {
        double FeatureScaling(double min, double max, double value);

        double MeanNormalization(double min, double max, double avg, double value);

        double GetAverage(IEnumerable<double> valueVector);
    }
}
