using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                                 });
                               

                foreach (var title in xitems) {
                    //if (title != null) {
                    lbRssTitle.Items.Add(title);
                    //}
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
