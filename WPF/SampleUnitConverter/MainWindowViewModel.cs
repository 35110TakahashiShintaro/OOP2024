using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    internal class MainWindowViewModel : ViewModel {
        private double metricValue, imperialValue;

        // ▲ボタンで呼ばれるコマンド (Command called when the ▲ button is pressed)
        public ICommand ImperialUnitToMetric { get; private set; }

        // ▼ボタンで呼ばれるコマンド (Command called when the ▼ button is pressed)
        public ICommand MetricToImperialUnit { get; private set; }

        // 上のcomboBoxで選択されている値 (Value selected in the upper comboBox)
        public MetricUnit CurrentMetricUnit { get; set; }

        // 下のcomboBoxで選択されている値 (Value selected in the lower comboBox)
        public ImperialUnit CurrentImperialUnit { get; set; }

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

        //コンストラクタ
        public MainWindowViewModel() {
            this.CurrentMetricUnit = MetricUnit.Units.First();
            this.CurrentImperialUnit = ImperialUnit.Units.First();

            this.MetricToImperialUnit = new DelegateCommand( () => 
                            this.ImperialValue = this.CurrentImperialUnit.FromMetricUnit(this.CurrentMetricUnit, this.MetricValue)
            );
            this.ImperialUnitToMetric = new DelegateCommand( () => 
                            this.MetricValue = this.CurrentMetricUnit.FromImperialUnit(this.CurrentImperialUnit, this.ImperialValue)
            );
        }
    }
}