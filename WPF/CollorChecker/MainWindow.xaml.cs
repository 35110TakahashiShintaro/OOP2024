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
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            MyColor myColor = new MyColor {
                Color = Color.FromRgb(r, g, b),
                Name = $"R: {r}, G: {g}, B: {b}"
            };

            LB.Items.Add(myColor);
        }

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (LB.SelectedItem is MyColor selectedColor) {
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
            }
        }
    }
}
