using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleWeightUnitConverter {
    internal class MainWindowViewModel : ViewModel {
        private double metricValue, imperialValue;

        public ICommand ImperialUnitToMetric { get; private set; }
        public ICommand MetricToImperialUnit { get; private set; }

        public GramUnit CurrentMetricUnit { get; set; }
        public PoundUnit CurrentImperialUnit { get; set; }

        public double MetricValue {
            get { return metricValue; }
            set {
                metricValue = value;
                OnPropertyChanged();
            }
        }

        public double ImperialValue {
            get { return imperialValue; }
            set {
                imperialValue = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel() {
            this.CurrentMetricUnit = GramUnit.Units.First();
            this.CurrentImperialUnit = PoundUnit.Units.First();

            this.MetricToImperialUnit = new DelegateCommand(
                () => this.ImperialValue = this.CurrentImperialUnit.FromMetricUnit(this.CurrentMetricUnit, this.MetricValue)
            );

            this.ImperialUnitToMetric = new DelegateCommand(
                () => this.MetricValue = this.CurrentMetricUnit.FromImperialUnit(this.CurrentImperialUnit, this.ImperialValue)
            );
        }
    }
}