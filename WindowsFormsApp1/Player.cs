using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace WindowsFormsApp1
{
    public class Player : Ship
    {
        public Player(int x, int y, int size, int hp, int dmg, int speed, int edir) : base(x, y, size, hp, dmg, speed, edir)
        {
            Bmp = new Bitmap(WindowsFormsApp1.Resource1.playerimg);
        }

        public override void Move(Form1 f, int x, int y, int edir)
        {
            this.Speed = 0;
            this.X = x;
            this.Y = y;
            if (Y < 400)
                Y = 400;
            var Position = new Rectangle(X, Y, Size, Size);
        }

        public override bool Iterection(int x, int y)
        {
            if (!((x < X - Size / 2) || (x > X + Size / 2) || (y < Y - Size / 2) || (y > Y + Size / 2)))
            {
                Hp -= Dmg;
                return true;
            }
            else return false;
        }


    }
}
