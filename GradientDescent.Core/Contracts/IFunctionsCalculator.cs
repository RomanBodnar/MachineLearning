namespace GradientDescent.Core.Contracts
{
    public interface IFunctionsCalculator
    {
        double Hypothesis(double[] features, double[] theta);

        double CostFuction(double[] theta);
    }
}
