using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class fmVersion : Form {
        public fmVersion() {
            InitializeComponent();

            // バージョン設定
            this.Load += new EventHandler(fmVersion_Load);

            //label2.Text = $"Ver: {Assembly.GetExecutingAssembly().GetName().Version}";;
        }

        private void btVersionOK_Click(object sender, EventArgs e) {
            Close();
        }

        private void fmVersion_Load(object sender, EventArgs e) {
            // バージョン取得
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyVer = assembly.GetName().Version;

            var fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
            var company = fileVersion.CompanyName;
            label3.Text = company;

            // バージョン表示
            label2.Text = $"Ver: {assemblyVer}";
            label3.Text = $"会社名: {company}";

        }

        
    }
}
