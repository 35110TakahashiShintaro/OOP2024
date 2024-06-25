namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDatecount_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            TimeSpan diff = today - dtpDate.Value;
            tbDisp.Text = (diff.Days + 1) + "����";
        }

        private void btDayBefore_Click(object sender, EventArgs e) {
            var before = dtpDate.Value.AddDays(-(double)nudDay.Value);
            tbDisp.Text = before + "���O";
        }

        private void btDayAfter_Click(object sender, EventArgs e) {
            var after = dtpDate.Value.AddDays((double)nudDay.Value);
            tbDisp.Text = after + "����";
        }

        private void btAge_Click(object sender, EventArgs e) {
            var birthday = dtpDate.Value;
            var today = DateTime.Today;
            var age = GetAge(birthday, today);
            tbDisp.Text = age + "�΂ł�";
        }

        private object GetAge(DateTime value, DateTime today) {
            var age = today.Year - value.Year;
            if(today < value.AddYears(age).AddDays(-1)) {
                age--;
            }
            return age;
        }
    }
}
