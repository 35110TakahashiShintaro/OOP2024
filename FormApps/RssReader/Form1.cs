using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbRssUrl.Text);
                var xdoc = XDocument.Load(url);

                var xitems = xdoc.Descendants("item")
                                 .Select(item => new {
                                     Title = item.Element("title").Value,
                                     Link = item.Element("link").Value,
                                 }).ToList();

                foreach (var item in xitems) {
                    lbRssTitle.Items.Add(item.Title); 
                }
            }
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedItem != null) {
                var selectedItem = (dynamic)lbRssTitle.SelectedItem;
                var link = (string)selectedItem.Link;
                webView1.Navigate(link);
            }
        }
    }
}