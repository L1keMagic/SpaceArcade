using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;
namespace WindowsFormsApp1
{
    public class Enemy : Ship
    {
        public Enemy(int x, int y, int size, int hp, int dmg, int speed, int edir) : base(x, y, size, hp, dmg, speed, edir)
        {
            Bmp = new Bitmap(WindowsFormsApp1.Resource1.enemyimg);
        }

        public override void Move(Form1 f, int x, int y, int edir)
        {
            this.Y = 100;
            int pdx = x;
            int dir;
            dir = (pdx - X);

            if (Math.Abs(dir) < Speed)
                dir = 0;

            if (dir < 0)
                dir = -1;
            if (dir > 0)
                dir = 1;

            this.X = X + dir * Speed;
            var Position = new Rectangle(X, Y, Size, Size);
        }

        public override bool Iterection( int x, int y)
        {
            if (!((x < X - Size / 2) || (x > X + Size / 2) || (y < Y - Size / 2) || (y > Y + Size / 2)))
            {
                Hp -= Dmg;
                return true;
            }
            else return false;         
        }

        //public void Healthline(int x, int y, int currentHP, int maxHP)
        //{
        //    Bitmap Greenline = new Bitmap(WindowsFormsApp1.Resource1.heathlinegreeen);
        //    int linelong = 100;
        //    int linePart = (currentHP / maxHP) * linelong;
        //}
    }
}
