using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
namespace WindowsFormsApp1
{
    public class Bullet
    {
        public int X, Y, Size, Speed, Dmg;
        public Bitmap Bmp;

        public Bullet(int x, int y, int size, int speed)
        {
            Bmp = new Bitmap(WindowsFormsApp1.Resource1.BulletOrrangeimg);
            this.X = x;
            this.Y = y;
            this.Size = size;
            this.Speed = speed;
        }

        public void Move()
        {
            Y += Speed;
        }
      

        public void Show(Graphics g)
        {
            g.DrawImage(Bmp, X, Y, Size, Size);
        }


    }
}