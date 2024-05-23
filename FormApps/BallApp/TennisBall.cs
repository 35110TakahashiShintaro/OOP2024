using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BallApp {
    internal class TennisBall : Obj {

        public static int Count { get; set; }

        public TennisBall(double xp, double yp)
            : base(xp - 25, yp - 25, @"Picture\tennis_ball.png") {

            var rand1 = new Random();

            MoveX = rand1.Next(-25, 25); 
            MoveY = rand1.Next(-25, 25);

            Count++;
        }              

        //戻り値：１…移動OK、　２…落下した、　３…バーに当たった
        public override int Move(PictureBox pbBar, PictureBox pbBall) {
            int ret = 1;

            Rectangle rBar = new Rectangle(pbBar.Location.X, pbBar.Location.Y,
                                                     pbBar.Width, pbBar.Height);

            Rectangle rBall = new Rectangle(pbBall.Location.X, pbBall.Location.Y,
                                                     pbBall.Width, pbBall.Height);

            if (PosX > 750 || PosX < 0) {
                MoveX = -MoveX;
            }
            if (PosY < 0) {
                MoveY = -MoveY;
            }

            if (rBar.IntersectsWith(rBall)) {
                MoveY = -MoveY;
                ret = 3;
            }

            PosX += MoveX;
            PosY += MoveY;
            
            //下に落下したか
            if (PosY > 600) {
                ret = 2;
            }

            return ret;            
        }

        public override bool Move(Keys direction) {
            return true;
        }
    }
}
