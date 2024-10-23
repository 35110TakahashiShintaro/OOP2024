using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            //var value = (int)rSlider.Value;
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void StockButton_Click(object sender, RoutedEventArgs e) {
            string colorInfo = $"R: {(byte)rSlider.Value}, G: {(byte)gSlider.Value}, B: {(byte)bSlider.Value}";
            LB.Items.Add(colorInfo);
        }

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (LB.SelectedItem is string selectedColorInfo) {
                var values = selectedColorInfo.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                byte r = byte.Parse(values[1]);
                byte g = byte.Parse(values[3]);
                byte b = byte.Parse(values[5]);

                colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            }
        }
    }
}
