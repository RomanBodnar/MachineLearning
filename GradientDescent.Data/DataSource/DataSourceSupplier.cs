using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GradientDescent.Data.DataSource.Contracts;
using GradientDescent.Data.Models.LinearRegression;

namespace GradientDescent.Data.DataSource
{
    public class DataSourceSupplier : IDataSourceSupplier
    {
        public IEnumerable<TrainingElement> GetTrainingSet()
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string filePath = @"DataSets\ex1data2.txt";
            string fullPath = Path.Combine(projectPath, filePath);

            var resultList = new List<TrainingElement>();

            try
            {
                using (StreamReader streamReader = new StreamReader(fullPath))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        var line = streamReader.ReadLine();
                        var numbers = this.SplitString(line).ToList();
                        resultList.Add(new TrainingElement
                        {
                            Features = this.GetFeatures(numbers),
                            Result = this.GetResult(numbers)
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            return resultList;
        }
        
        private IEnumerable<double> SplitString(string inputString)
        {
            var split = inputString.Split(',');
            return split.Select(double.Parse);
        }

        private List<double> GetFeatures(List<double> inputValues)
        {
            inputValues.Insert(0, 1);
            return inputValues.Take(inputValues.Count - 1).ToList();
        }

        private double GetResult(List<double> inputValues)
        {
            return inputValues[inputValues.Count - 1];
        }
    }
}
