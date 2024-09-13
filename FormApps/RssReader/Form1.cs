using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        List<ItemDate> items;
        private List<ItemDate> filteredItems;
        List<KeyValuePair<string, string>> favoriteCategories = new List<KeyValuePair<string, string>>();

        public Form1() {
            InitializeComponent();
            InitializeWebView2Async();
            LoadFavorites();
            UpdateCategoryList();
            this.Resize += new EventHandler(this.Form_Resize);
            btGet.Click += new EventHandler(this.btGet_Click);
            lbRssTitle.SelectedIndexChanged += new EventHandler(this.lbRssTitle_SelectedIndexChanged);
            tbRssUrl.TextChanged += new EventHandler(this.lbRssTitle_SelectedIndexChanged);
            btSearch.Click += new EventHandler(this.btSearch_Click);
            cbCategory.SelectedIndexChanged += new EventHandler(this.cbCategory_SelectedIndexChanged);

            
        }

        private void UpdateCategoryList() {
            cbCategory.Items.Clear();

            cbCategory.DisplayMember = "Key";

            cbCategory.Items.Add(new KeyValuePair<string, string>("主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml"));
            cbCategory.Items.Add(new KeyValuePair<string, string>("国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml"));
            cbCategory.Items.Add(new KeyValuePair<string, string>("国際", "https://news.yahoo.co.jp/rss/topics/world.xml"));
            cbCategory.Items.Add(new KeyValuePair<string, string>("経済", "https://news.yahoo.co.jp/rss/topics/business.xml"));
            cbCategory.Items.Add(new KeyValuePair<string, string>("エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml"));
            cbCategory.Items.Add(new KeyValuePair<string, string>("スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml"));
            cbCategory.Items.Add(new KeyValuePair<string, string>("IT", "https://news.yahoo.co.jp/rss/topics/it.xml"));
            cbCategory.Items.Add(new KeyValuePair<string, string>("科学", "https://news.yahoo.co.jp/rss/topics/science.xml"));
            cbCategory.Items.Add(new KeyValuePair<string, string>("地域", "https://news.yahoo.co.jp/rss/topics/local.xml"));

            if (favoriteCategories.Any()) {
                cbCategory.Items.Add(new KeyValuePair<string, string>("--- お気に入り ---", "")); // 区切り
                foreach (var favorite in favoriteCategories) {
                    cbCategory.Items.Add(favorite);
                }
            }

            //// 初期選択
            //if (cbCategory.Items.Count > 0) {
            //    cbCategory.SelectedIndex = 0;
            //}
        }

        private async void InitializeWebView2Async() {
            await webView21.EnsureCoreWebView2Async(null);
        }



        private void btGet_Click(object sender, EventArgs e) {
            try {
                using (var wc = new WebClient()) {

                    var url = wc.OpenRead(tbRssUrl.Text);
                    var xdoc = XDocument.Load(url);
                    items = xdoc.Descendants("item")
                                 .Select(item => new ItemDate {
                                     Title = item.Element("title").Value,
                                     Link = item.Element("link").Value,
                                 }).ToList();
                    //DisplayItems(items);
                    lbRssTitle.Items.Clear();
                    foreach (var item in items) {
                        lbRssTitle.Items.Add(item.Title);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"RSS フィードの読み込み中にエラーが発生しました: {ex.Message}");
            }
        }




        private void Form_Resize(object sender, EventArgs e) {
            // サイズ変更時の処理をここに追加
        }

        private void btSearch_Click(object sender, EventArgs e) {
            if (items == null || !items.Any()) return;
            var searchText = tbRssSearch.Text.ToLower();
            filteredItems = items
                .Where(item => item.Title.ToLower().Contains(searchText))
                .ToList();
            DisplayItems(filteredItems);
            if (!filteredItems.Any()) {
                lbRssTitle.Items.Clear();
                lbRssTitle.Items.Add("該当する記事がありません");
            }
        }
        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex >= 0) {
                var selectedIndex = lbRssTitle.SelectedIndex;

                // filteredItems がnullまたは空の場合、itemsを使用する
                var itemList = (filteredItems != null && filteredItems.Any()) ? filteredItems : items;

                if (itemList != null && selectedIndex >= 0 && selectedIndex < itemList.Count) {
                    var selectedItem = itemList[selectedIndex];
                    webView21.CoreWebView2.Navigate(selectedItem.Link);
                }
            }

        }
        private void DisplayItems(List<ItemDate> itemsToDisplay) {
            lbRssTitle.Items.Clear();
            if (itemsToDisplay == null || itemsToDisplay.Count == 0) {
                lbRssTitle.Items.Add("該当する記事がありません");
                return;
            }
            foreach (var item in itemsToDisplay) {
                lbRssTitle.Items.Add(item.Title);
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbCategory.SelectedItem is KeyValuePair<string, string> selectedCategory) {
                tbRssUrl.Text = selectedCategory.Value; // URLをテキストボックスにセットする
                btGet.PerformClick(); // "取得"ボタンをプログラムからクリックする
            }
        }

        private void btOkini_Click(object sender, EventArgs e) {
            if (cbCategory.SelectedItem is KeyValuePair<string, string> selectedCategory &&
                !favoriteCategories.Any(c => c.Key == selectedCategory.Key)) {
                favoriteCategories.Add(selectedCategory);
                SaveFavorites(); // お気に入りを保存
                UpdateCategoryList();
                MessageBox.Show($"{selectedCategory.Key} がお気に入りに追加されました！");
            } else {
                MessageBox.Show("すでにお気に入りに登録されています。");
            }
        }
        private void SaveFavorites() {
            var favoriteData = favoriteCategories.Select(c => $"{c.Key},{c.Value}").ToList();
            System.IO.File.WriteAllLines("favorites.txt", favoriteData);
        }

        private void LoadFavorites() {
            if (System.IO.File.Exists("favorites.txt")) {
                favoriteCategories = System.IO.File.ReadAllLines("favorites.txt")
                    .Select(line => line.Split(','))
                    .Select(parts => new KeyValuePair<string, string>(parts[0], parts[1]))
                    .ToList();
            }
        }

        
    }

    public class ItemDate {
        public string Title { get; set; }
        public string Link { get; set; }
    }


    
}

