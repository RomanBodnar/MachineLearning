using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace GradientDescent.MultipleFeatures
{
    // Step 1: Measure how well hypothesis fits using cost function where all thetas are 0
    // Step 2: Update thetas with gradient descent
    // Step 3: Call cost function and see how hypothesis fits now (compare values: new value must be lesser than previous)
    // Step 4: If new value lesser - go to step 2; otherwise go to step 5
    // Step 5: Apply new thetas for predicting unknown value

    // should plot convergence OxyPlot
    class Program
    {
        private static int NumberOfFeatures = 4 + 1;

        static void Main(string[] args)
        {
            Console.Read();
        }

        public static void Converge()
        {
            var theta = GetInitialThetas();
            
            // learning rate
            double alpha = 0.01;
            
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

        public static double[] GetInitialThetas()
        {
            return new double[NumberOfFeatures];
        }

        public static double Hypothesis(int[] features, double[] theta)
        {
            double hypothesis = features[0] * theta[0] + features[1] * theta[1] + features[2] * theta[2] +
                                features[3] * theta[3] + features[4] * theta[4];
            return hypothesis;
        }

        public static int[] GetFeaturesVector(House house)
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

        public double CostFuction(double[] theta)
        {
            var houses = GetSampleData().ToList();
            var numberOfTrainingExamples = houses.Count;
            double result = 0.0;
            for (int i = 1; i <= numberOfTrainingExamples; i++)
            {
                var features = GetFeaturesVector(houses[i]);
                result += Math.Pow(Hypothesis(features, theta) - houses[i].Price, 2);
            }
            return 1 * result / (2 * numberOfTrainingExamples);
        }

        public double CostFuctionDerivated(double[] theta, double alpha, int featureNumber)
        {
            var houses = GetSampleData().ToList();
            var numberOfTrainingExamples = houses.Count;

            double result = 0.0;
            for (int i = 0; i < numberOfTrainingExamples; i++)
            {
                var features = GetFeaturesVector(houses[i]);
                result += (Hypothesis(features, theta) - houses[i].Price) * features[featureNumber];
            }
            return (1 * alpha * result) / numberOfTrainingExamples;
        }


        public double[] GradientDescent(double[] theta, double alpha)
        {
            List<double> newTheta = new List<double>();

            for (int i = 0; i < NumberOfFeatures; i++)
            {
                newTheta.Add(theta[i] - CostFuctionDerivated(theta, alpha, i));
            }

            return newTheta.ToArray();
        }

        public double ScaleFeature()
        {
            return 0;
        }
    }
}
