namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDateClick(object sender, EventArgs e) {

            var today = DateTime.Today;
            TimeSpan diff = today - dtpBirthday.Value;
            tbDisp.Text = (diff.Days + 1) + "“ú–Ú";
        }

        private void btDayBefore_Click(object sender, EventArgs e) {
            var before = dtpBirthday.Value.AddDays(-(double)nudDay.Value);
            tbDisp.Text = before + "“ú‘O";
        }        

        private void btDayAfter_Click(object sender, EventArgs e) {
            var after = dtpBirthday.Value.AddDays((double)nudDay.Value);
            tbDisp.Text = after + "“úŒã";
        }
    }
}
