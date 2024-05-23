using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    internal class SoccerBall : Obj{
        

        public static int Count { get; set; }

        public SoccerBall(double xp, double yp)
            : base(xp - 25, yp - 25, @"Picture\soccer_ball.png"){
            var rand2 = new Random();

#if DEBUG
            MoveX = 5;
            MoveY = 5;
#else
            MoveX = rand2.Next(-25, 25); //移動量設定
            MoveY = rand2.Next(-25, 25);
#endif        
            

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

            //バーに当たったか
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

            //移動完了
            return ret;
        }

        public override bool Move(Keys direction) {
            return true;
        }
    }
}
