namespace BallApp {
    public partial class Form1 : Form {
        PictureBox pb;
        //SoccerBall soccerBall;
        //TennisBall tennisBall;
        Obj obj;

        public Form1() {
            InitializeComponent();
        }

        //�t�H�[�����ŏ��Ƀ��[�h�����Ƃ���x�������s�����
        private void Form1_Load(object sender, EventArgs e) {
        }

        private void timer1_Tick(object sender, EventArgs e) {

            obj.Move();
            pb.Location = new Point((int)obj.PosX, (int)obj.PosY);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {

            pb = new PictureBox();  //�摜��\������R���g���[��

            if (e.Button == MouseButtons.Left) {
                obj = new SoccerBall(e.X, e.Y);
                pb.Size = new Size(50, 50);
            }else if (e.Button == MouseButtons.Right) {
                obj = new TennisBall(e.X, e.Y);
                pb.Size = new Size(25, 25);
            }
            pb.Image = obj.Image;
            pb.Location = new Point((int)obj.PosX, (int)obj.PosY);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Parent = this;

            timer1.Start();

        }
    }
}
