namespace GradientDescent.Core.LinearRegression.Contracts
{
    public interface IGradientDescentCalculator
    {
        double CalculateNewTheta(double[] theta, double alpha, int featureNumber);
        double[] Descent(double[] theta, double alpha, int numberOfFeatures);
    }
}
