using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApp1
{
    abstract public class Ship
    {

        public Bitmap Bmp;
        public int X, Y, Size, Hp, Dmg, Speed, eDir;

        public Ship(int x, int y, int size, int hp, int dmg, int speed, int edir)
        {
            X = x;
            Y = y;
            Size = size;
            Hp = hp;
            Dmg = dmg;
            Speed = speed;
            eDir = edir;
        }
        abstract public void Move(Form1 f, int X, int Y, int eDir);
        public void Show(Graphics g)
        {
            g.DrawImage(Bmp, X - Size / 2, Y - Size / 2, Size, Size);
        }
        abstract public bool Iterection(int x, int y);






    }
}
