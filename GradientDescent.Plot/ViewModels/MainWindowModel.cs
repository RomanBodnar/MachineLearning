using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GradientDescent.Plot.Annotations;
using OxyPlot;

namespace GradientDescent.Plot.ViewModels
{
    public class MainWindowModel
    {
        public MainWindowModel()
        {
            this.Title = "Example 2";
            this.Points = new List<DataPoint>
            {
                new DataPoint(0, 4),
                new DataPoint(10, 13),
                new DataPoint(20, 15),
                new DataPoint(30, 16),
                new DataPoint(40, 12),
                new DataPoint(50, 12)
            };
        }

        public string Title { get; private set; }

        public IList<DataPoint> Points { get; private set; }
    }
}
