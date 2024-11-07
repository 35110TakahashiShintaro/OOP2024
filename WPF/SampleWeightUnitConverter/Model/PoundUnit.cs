using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    internal class PoundUnit : WeightUnit {
        private static readonly List<PoundUnit> units = new List<PoundUnit> {
            
            new PoundUnit { Name = "oz", Coefficient = 1 },          
            new PoundUnit { Name = "lb", Coefficient = 16 },       
            new PoundUnit { Name = "st", Coefficient = 224 },       
            
        };

        public static ICollection<PoundUnit> Units { get { return units; } }

        public double FromMetricUnit(GramUnit unit, double value) {
            return (value * unit.Coefficient) / 28.3495 / this.Coefficient;
        }
    }
}