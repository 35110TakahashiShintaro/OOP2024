using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls.Primitives;
using static System.Windows.Forms.LinkLabel;

namespace RssReader {

    public partial class Form1 : Form {
        List<ItemDate> items;

        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbRssUrl.Text);
                var xdoc = XDocument.Load(url);

                items = xdoc.Descendants("item")
                                 .Select(item => new ItemDate{
                                     Title = item.Element("title").Value,
                                     Link = item.Element("link").Value,
                                 }).ToList();

                foreach (var item in items) {
                    lbRssTitle.Items.Add(item.Title); 
                }
            }
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            webView1.Navigate(items[lbRssTitle.SelectedIndex].Link);
        }
    }
    public class ItemDate {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}