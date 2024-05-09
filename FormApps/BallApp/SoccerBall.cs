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
 

            MoveX = rand2.Next(-50, 50); //移動量設定
            MoveY = rand2.Next(-50, 50);

            Count++;
        }

        public override bool Move() {
            if (PosX > 750 || PosX < 0) {
                MoveX = -MoveX;
            }
            if (PosY > 500 || PosY < 0) {
                MoveY = -MoveY;
            }
            PosX += MoveX; 
            PosY += MoveY;

            return true;
        }
    }
}
