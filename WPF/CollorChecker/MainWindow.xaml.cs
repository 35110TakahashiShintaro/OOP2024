using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CollorChecker {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));

            rTextBox.Text = r.ToString();
            gTextBox.Text = g.ToString();
            bTextBox.Text = b.ToString();
        }

        private void StockButton_Click(object sender, RoutedEventArgs e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            if (LB.Items.OfType<MyColor>().Any(c => c.Color.Equals(Color.FromRgb(r, g, b)))) {
                MessageBox.Show("この色は登録されています");
                return;
            }

            MyColor newColor = new MyColor {
                Color = Color.FromRgb(r, g, b),
                Name = $"Color {LB.Items.Count + 1}"
            };

            LB.Items.Insert(0, newColor);
        }

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (LB.SelectedItem is MyColor selectedColor) {
                colorArea.Background = new SolidColorBrush(selectedColor.Color);

                rSlider.Value = selectedColor.Color.R;
                gSlider.Value = selectedColor.Color.G;
                bSlider.Value = selectedColor.Color.B;

                rTextBox.Text = selectedColor.Color.R.ToString();
                gTextBox.Text = selectedColor.Color.G.ToString();
                bTextBox.Text = selectedColor.Color.B.ToString();
            }
        }
    }
}
