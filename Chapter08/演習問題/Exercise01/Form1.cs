using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            var sur = today.ToString("g");
            var str = string.Format("{0}�N{1,2}��{2,2}�� {2,3}��{3,3}��{3,4}�b", today.Year, today.Month, today.Day, today.Hour, today.Minute, today.Second);

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var wa = today.ToString("ggyy�NM��d��h��m��s�b",culture); 

            tbDisp.Text += sur + "\r\n";
            tbDisp.Text += str + "\r\n";
            tbDisp.Text += wa + "\r\n";


        }
    }
}
