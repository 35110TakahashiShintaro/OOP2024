using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    internal class GramUnit : WeightUnit {
        private static readonly List<GramUnit> units = new List<GramUnit> {
            new GramUnit { Name = "mg", Coefficient = 0.001 },   
            new GramUnit { Name = "g", Coefficient = 1 },         
            new GramUnit { Name = "kg", Coefficient = 1000 },     
            new GramUnit { Name = "ct", Coefficient = 0.2 },  
            
        };

        public static ICollection<GramUnit> Units { get { return units; } }

        public double FromImperialUnit(PoundUnit unit, double value) {
            return (value * unit.Coefficient) * 28.3495 / this.Coefficient;
        }
    }
}