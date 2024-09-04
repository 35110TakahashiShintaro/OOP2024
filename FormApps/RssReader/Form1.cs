using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        private dynamic xitems;

        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbRssUrl.Text);
                var xdoc = XDocument.Load(url);

                xitems = xdoc.Descendants("item")
                                 .Select(item => new {
                                     Title = item.Element("title").Value,
                                     Link = item.Element("link").Value,
                                 }).ToList();

                lbRssTitle.Items.Clear();
                foreach (var item in xitems) {
                    lbRssTitle.Items.Add(item.Title); 
                }
                lbRssTitle.Tag = xitems;
            }
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex != -1) {
                var selectedItem = xitems[lbRssTitle.SelectedIndex];
                var link = selectedItem.Link;
                webView1.Navigate(link);
            }
        }
    }
}