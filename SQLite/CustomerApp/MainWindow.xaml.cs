using CustomerApp.Objects;
using SQLite;
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

namespace CustomerApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        List<Customer> _customers;
        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
        }
        private byte[] _selectedImageData;
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImageData = _selectedImageData // 画像データを保存
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            _selectedImageData = null; // 保存後に画像データをクリア
            ReadDatabase();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer == null) {
                MessageBox.Show("アップデートする行を選択してください");
                return;
            }

            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;

            if (_selectedImageData != null) {
                selectedCustomer.ImageData = _selectedImageData;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Update(selectedCustomer);
            }
            _selectedImageData = null;
            ReadDatabase();
        }

        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();

                CustomerListView.ItemsSource = _customers;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var FilterList = _customers.Where(x=>x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = FilterList;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var Item = CustomerListView.SelectedItem as Customer;
            if (Item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(Item);
                ReadDatabase(); // ListView表示
            }
            CustomerImage.Source = null; 

        }
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;

                
                if (selectedCustomer.ImageData != null) {
                    using (var stream = new System.IO.MemoryStream(selectedCustomer.ImageData)) {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        CustomerImage.Source = bitmap;
                    }
                } else {
                    CustomerImage.Source = null;
                }
            }
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e) {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";

            if (openFileDialog.ShowDialog() == true) {
                var bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                CustomerImage.Source = bitmap;

                using (var stream = new System.IO.MemoryStream()) {
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmap));
                    encoder.Save(stream);
                    _selectedImageData = stream.ToArray(); 
                }
            }
        }
    }
    
}


