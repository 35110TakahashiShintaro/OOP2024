using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CollorChecker {
    public partial class MainWindow : Window {
        MyColor currentColor;

        public MainWindow() {
            InitializeComponent();

            currentColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value); colorArea.Background = new SolidColorBrush(currentColor.Color);
            colorArea.Background = new SolidColorBrush(currentColor.Color);
            
        }

        private void StockButton_Click(object sender, RoutedEventArgs e) {
            if (LB.Items.OfType<MyColor>().Any(c => c.Color.Equals(currentColor.Color))) {
                MessageBox.Show("この色はすでに保存されています。");
                return;
            }
            LB.Items.Insert(0, new MyColor { Color = currentColor.Color });
        }

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            colorArea.Background = new SolidColorBrush(((MyColor)LB.Items[LB.SelectedIndex]).Color);
            rSlider.Value = ((MyColor)LB.Items[LB.SelectedIndex]).Color.R;
            gSlider.Value = ((MyColor)LB.Items[LB.SelectedIndex]).Color.G;
            bSlider.Value = ((MyColor)LB.Items[LB.SelectedIndex]).Color.B;

            
        }
    }
}
