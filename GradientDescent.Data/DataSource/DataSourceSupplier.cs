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
            
            try
            {
                using (StreamReader streamReader = new StreamReader(fullPath))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        var str = streamReader.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            throw new NotImplementedException();
        }

        private double[] SplitString(string inputString)
        {
            var split = inputString.Split(',');
            return split.Select(double.Parse).ToArray();
        }
    }
}
