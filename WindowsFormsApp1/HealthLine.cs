using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class HealthLine
    {
        public int X, Y, Size;
        public float CurrentHP, MaxHP, LinePart = 100;
        public Bitmap Bmp;

        public HealthLine(int x, int y, int size, float currentHP, float maxHP)
        {
            Bmp = new Bitmap(WindowsFormsApp1.Resource1.heathlinegreeen);
        }

        public void LineSize(int x, int y, int size, float currentHP, float maxHP)
        {
            this.X = x;
            this.Y = y;
            this.Size = size;
            this.CurrentHP = currentHP;
            this.MaxHP = maxHP;
            LinePart = (CurrentHP / MaxHP) * Size;
            if (LinePart < 0)
                LinePart = 0;
        }


        public void Show(Graphics g)
        {
            g.DrawImage(Bmp, X, Y, LinePart, 5);
        }



    }
}