using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CollorChecker {
    public partial class MainWindow : Window {
        MyColor currentColor;

        public MainWindow() {
            InitializeComponent();
            currentColor = new MyColor();
            DataContext = GetColorList();
            currentColor.Color = Color.FromArgb(255, 0, 0, 0);
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
        .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name })
        .ToArray();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(currentColor.Color);

            var matchedColor = ((MyColor[])DataContext).FirstOrDefault(c => c.Color == currentColor.Color);
            currentColor.Name = matchedColor.Name ?? $"R: {currentColor.Color.R}, G: {currentColor.Color.G}, B: {currentColor.Color.B}";
        }

        private void StockButton_Click(object sender, RoutedEventArgs e) {
            var colorName = currentColor.Name ?? $"{currentColor.Color}";
            var colorExists = LB.Items.OfType<MyColor>().Any(color => color.Color == currentColor.Color);

            if (!colorExists) {
                LB.Items.Insert(0, new MyColor { Color = currentColor.Color, Name = colorName });
            } else {
                MessageBox.Show("この色は追加済です。");
            }
        }

        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (LB.SelectedIndex >= 0) {
                MyColor selectedColor = (MyColor)LB.Items[LB.SelectedIndex];
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
                rSlider.Value = selectedColor.Color.R;
                gSlider.Value = selectedColor.Color.G;
                bSlider.Value = selectedColor.Color.B;
            }

        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorSelectComboBox.SelectedItem != null) {
                MyColor selectedColor = (MyColor)colorSelectComboBox.SelectedItem;

                colorArea.Background = new SolidColorBrush(selectedColor.Color);

                rSlider.Value = selectedColor.Color.R;
                gSlider.Value = selectedColor.Color.G;
                bSlider.Value = selectedColor.Color.B;
            }

        }

        private void DropButton_Click(object sender, RoutedEventArgs e) {
            if (LB.SelectedItem != null) {
                LB.Items.Remove(LB.SelectedItem);
            } else {
                MessageBox.Show("削除する色を選択してください。");
            }
        }
    }
}
