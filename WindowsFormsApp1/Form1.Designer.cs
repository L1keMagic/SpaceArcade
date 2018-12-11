namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.playerHP = new System.Windows.Forms.Label();
            this.enemyHP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // playerHP
            // 
            this.playerHP.AutoSize = true;
            this.playerHP.Location = new System.Drawing.Point(867, 24);
            this.playerHP.Name = "playerHP";
            this.playerHP.Size = new System.Drawing.Size(50, 13);
            this.playerHP.TabIndex = 0;
            this.playerHP.Text = "playerHP";
            this.playerHP.Click += new System.EventHandler(this.playerHP_Click);
            // 
            // enemyHP
            // 
            this.enemyHP.AutoSize = true;
            this.enemyHP.Location = new System.Drawing.Point(783, 24);
            this.enemyHP.Name = "enemyHP";
            this.enemyHP.Size = new System.Drawing.Size(53, 13);
            this.enemyHP.TabIndex = 2;
            this.enemyHP.Text = "enemyHP";
            this.enemyHP.Click += new System.EventHandler(this.enemyHP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 622);
            this.Controls.Add(this.enemyHP);
            this.Controls.Add(this.playerHP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label playerHP;
        private System.Windows.Forms.Label enemyHP;
    }
}

