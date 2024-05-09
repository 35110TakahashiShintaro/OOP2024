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

            MoveX = rand1.Next(-50, 50); 
            MoveY = rand1.Next(-50, 50);

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
