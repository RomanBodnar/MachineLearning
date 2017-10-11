using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace GradientDescent.MultipleFeatures
{
    class Program
    {
        private static int NumberOfFeatures = 4 + 1;

        static void Main(string[] args)
        {
            Matrix<double> m = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                {1, 2},
                { 1, 2}
            });
            Matrix<double> v = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                {1, 2},
                { 1, 2}
            });
            var result = m.Multiply(v);
            var transposed = result.Transpose();
            Console.Read();
        }

        public static IEnumerable<House> GetSampleData()
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

        public static double[] GetThetas()
        {
            return new double[NumberOfFeatures];
        }

        public static double Hypothesis(House house)
        {
            var theta = GetThetas();
            var x = GetVector(house);


            double hypothesis = x[0] * theta[0] + x[1] * theta[1] + x[2] * theta[2] +
                                x[3] * theta[3] + x[4] * theta[4];
            return hypothesis;
        }

        public static int[] GetVector(House house)
        {
            return new int[]
            {
                1,
                house.Size,
                house.NumberOfBedrooms,
                house.NumberOfFloors,
                house.Age
            };
        }

        public double CostFuction(double[] theta, int[] x)
        {
            var houses = GetSampleData().ToList();
            double result = 0.0;
            for (int i = 1; i <= NumberOfFeatures; i++)
            {
                result += Math.Pow(Hypothesis(houses[i]) - houses[i].Price, 2);
            }
            return 1*result/(2*NumberOfFeatures);
        }

        public double CostFuctionDerivated(double[] theta, int[] x)
        {
            var houses = GetSampleData().ToList();
            
            double result = 0.0;
            for (int i = 1; i <= NumberOfFeatures; i++)
            {
                result += (Hypothesis(houses[i]) - houses[i].Price) * x[i];
            }
            return 1 * result / NumberOfFeatures;
        }

        public double[] GradientDescent(double[] theta, double alpha)
        {
            int[][] vectors = new int[]
            theta[0] = 
        }
    }
}
