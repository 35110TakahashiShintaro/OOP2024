using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            var sur = today.ToString("g");
            var str = today.ToString("yyyy”NMMŒŽdd“ú HHŽžmm•ªss•b");

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var wa = today.ToString("ggyy”NMŒŽd“úhŽžm•ªs•b", culture);

            tbDisp.Text += sur + "\r\n";
            tbDisp.Text += str + "\r\n";
            tbDisp.Text += wa + "\r\n";

            
        }

        private void btEx8_2_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            
            DateTime nextWeek = NextDay(today, DayOfWeek.Monday);
        }
        public static DateTime NextDay(DateTime today, DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(today.DayOfWeek);
            if (days <= 0) {
                days += 7;
            }
            return today.AddDays(days);
        }
    }
}
