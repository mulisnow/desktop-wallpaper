using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Runtime.InteropServices;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace 壁纸
{
    public partial class Form1 : Form
    {
        private 星空 starField;
        private Timer timer = new Timer();
        private 窗口 窗口;
        private 球 球;
        private bool bb;
        public Form1( )
        {
            //初始化
            InitializeComponent();
            窗口=new 窗口();
            窗口.EmbedToDesktop(this.Handle);
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            DateTime d = DateTime.Now;
            String c = d.ToString("M");
            bb = c[2] % 2 == 1;
            if (bb )
            {
                // 防止闪烁
                starField = new 星空(this.Width, this.Height);

                this.SizeChanged += Form1_SizeChanged;
                timer.Interval = 20;
                timer.Tick += (sender, e) => { this.Invalidate(); }; // 定时重绘
                  timer.Start();
            }
            else 
            {
                球 = new 球();
                timer = new Timer();
                timer.Interval = 20; // Update every 20 milliseconds
                timer.Tick += Timer_Tick;
                timer.Start();
            }

           
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            球.angle++;
            if (球.angle >= 180) 球.angle = 0;
            this.Invalidate(); // Causes the form to be redrawn
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // 窗体大小改变时，重新初始化星星以适应新的尺寸
            starField.InitStars(this.ClientSize.Width, this.ClientSize.Height);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // 抗锯齿
            if(bb)
            starField.DrawStars(g, this.ClientSize.Width, this.ClientSize.Height);  
            else
         球.HideSphere(e.Graphics, this.Width,this.Height,600, 45 + 球.angle, 30 + 球.angle, 1);

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            
        }


    }
}