using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const int scount = 8;   // Ships count
        public Graphics dc, dc1;
        private Bitmap fon;
        private Bitmap fon1;
        protected Ship[] ships = new Ship[scount];
        protected HealthLine[] healthLines = new HealthLine[scount];
        protected List<Bullet> Bullets;
        int pX = 200, pY = 500, pSize = 100, pHp = 100, pDmg = 20; // Player settings
        int eX = 100, eY = 100, eSize = 100, eHp = 100, eDmg = 20, eSpeed = 3, eDir = 1; // Enemy settings
        public Form1()
        {
            InitializeComponent();
            dc = CreateGraphics();
            ships[0] = new Player(pX, pY, pSize, pHp, eDmg, 0, 0);  // Player
            ships[1] = new Enemy(eX, eY, eSize, eHp, pDmg, eSpeed, 0); // Main Enemy
            Random r = new Random();
            for (int i = 2; i < scount; i++)
            {
                int enbrndX = r.Next(40, 800);
                ships[i] = new EnemyNoBrain(enbrndX, eY, eSize, eHp, pDmg, eSpeed, eDir); // Other Enemies
            }
            for (int i = 1; i < scount; i++)
                if (ships[i] != null)
                    healthLines[i] = new HealthLine(ships[i].X, ships[i].Y, ships[i].Size, ships[i].Hp, ships[i].Hp); // Health Line
            fon = new Bitmap(WindowsFormsApp1.Resource1.background);
            fon1 = new Bitmap(WindowsFormsApp1.Resource1.background);
            dc1 = Graphics.FromImage(fon1);
            Bullets = new List<Bullet>(1);
        }

        void ShowPaint() // Paint of Objects
        {
            dc.DrawImage(fon1, 0, 0);
            dc1.DrawImage(fon, 0, 0);
            for (int i = 0; i < scount; i++)
                if (ships[i] != null)
                    ships[i].Show(dc1);
            for (int i = 1; i < scount; i++)
                if (ships[i] != null)
                    healthLines[i].Show(dc1);
            for (int i = 0; i < Bullets.Count; i++)
                Bullets[i].Show(dc1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ships[0].Move(this, e.X, e.Y, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowPaint();
            for (int i = 1; i < scount; i++)
                if (ships[i] != null)
                    ships[i].Move(this, ships[0].X, 0, eDir);

            for (int j = 0; j < scount; j++)
            {
                for (int i = 0; i < Bullets.Count; i++)
                {
                    Bullets[i].Move();
                    if (ships[j] != null && ships[j].Iterection(Bullets[i].X, Bullets[i].Y) == true)
                    {
                        Bullets.Remove(Bullets[i]); // if iterection then reemove
                        if (j != 0 && ships[j].Hp <= 0)
                            ships[j] = null;
                    }
                }
            }
            for (int i = 1; i < scount; i++)
                if (ships[i] != null)
                    healthLines[i].LineSize(ships[i].X - 50, ships[i].Y - 65, ships[i].Size, ships[i].Hp, eHp); // paint of health line

            int ecommonhp = 0;
            for (int i = 1; i < scount; i++)
                if (ships[i] != null)
                    ecommonhp += ships[i].Hp;

            playerHP.Text = Convert.ToString("Player HP: " + ships[0].Hp);
            enemyHP.Text = Convert.ToString("Enemy HP: " + ecommonhp);


            for (int i = 0; i < Bullets.Count; i++)  // БЫЛ ДОБАВЛЕН ЭТОТ ЦИКЛ!!!!!!!!!!!!!!
            {
                if (Bullets[i].Y < 0 || Bullets[i].Y > 630 || Bullets[i].X == -30) // Bullets Remove
                    Bullets.Remove(Bullets[i]);
            }


            if (ships[0].Hp <= 0 && Bullets.Count == 0)
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("You lose");
            }
            if (ecommonhp == 0 && Bullets.Count == 0)
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("You win");
            }
            if (ecommonhp == 0 || ships[0].Hp <= 0) // if last enemy than bullets go to left side of Form И БЫЛО ДОБАВЛЕНО ВОТ ЭТО!!!!!!!!!!
            {
                for (int i = 0; i < Bullets.Count; i++)
                    if (Bullets[i].Y > 0 && Bullets[i].Y < 630)
                        Bullets[i].X = -30;
            }
             if(ships[0].Hp <= 0)
            {
                for(int i = 0; i < scount; i++)
                {
                    if(ships[i] != null)
                    {
                        ships[i].X = -50;
                    }
                }
            }

        }

        private void playerHP_Click(object sender, EventArgs e)
        {

        }

        private void enemyHP_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Bullet bPlayer = new Bullet(e.X - 5, ships[0].Y - 50, 10, -3);
            Bullets.Add(bPlayer);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < scount; i++)
            {
                Random r = new Random();
                timer2.Interval = r.Next(500, 1000);
                if (ships[i] != null)
                {
                    Bullet bEnemy = new Bullet(ships[i].X - 5, ships[i].Y + 50, 10, 3);
                    Bullets.Add(bEnemy);
                }

            }

        }
    }
}
