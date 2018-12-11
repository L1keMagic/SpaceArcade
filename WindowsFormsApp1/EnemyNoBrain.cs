using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace WindowsFormsApp1
{
    public class EnemyNoBrain : Enemy
    {
        public EnemyNoBrain(int x, int y, int size, int hp, int dmg, int speed, int edir) : base(x, y, size, hp, dmg, speed, edir)
        {
            Speed = 3;
            Size = 30;
            Hp = 30;
        }
        public override void Move(Form1 f, int x, int y, int edir)
        {
            if (this.X > 900 || this.X < 60) eDir = -eDir;
            this.X = X + eDir * (Speed);
            var Position = new Rectangle(X, Y, Size, Size);
        }
        
    }
}
