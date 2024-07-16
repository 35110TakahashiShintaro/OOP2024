using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            label2.Text = $"Ver: {Assembly.GetExecutingAssembly().GetName().Version}";;
        }

        private void btVersionOK_Click(object sender, EventArgs e) {
            Close();
        }

        
    }
}
