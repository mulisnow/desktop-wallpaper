using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 壁纸
{
    internal class 星空
    {
        private const int MAXSTAR = 700;
        private Star[] stars = new Star[MAXSTAR];
        Random rand = new Random();
            public 星空(int width, int height)
        {
            InitStars(width, height);
        }

        public void InitStars(int width, int height)
        {


            double[] step = new double[11];
            Color[] color = new Color[11];
            for (int i = 0; i < MAXSTAR; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (rand.NextDouble() * 10 + 1 < 2)

                        color[j] = Color.FromArgb(255, 255, 255);
                    else if (rand.NextDouble() * 10 + 1 < 3)
                        color[j] = Color.FromArgb(240, 240, 240);
                    else if (rand.NextDouble() * 10 + 1 < 4)
                        color[j] = Color.FromArgb(230, 230, 230);
                    else if (rand.NextDouble() * 10 + 1 < 5)
                        color[j] = Color.FromArgb(210, 210, 210);
                    else if (rand.NextDouble() * 10 + 1 < 4)
                        color[j] = Color.FromArgb(190, 190, 190);
                    else if (rand.NextDouble() * 10 + 1 < 5)
                        color[j] = Color.FromArgb(180, 180, 180);
                    else if (rand.NextDouble() * 10 + 1 < 6)
                        color[j] = Color.FromArgb(150, 150, 150);
                    else if (rand.NextDouble() * 10 + 1 < 7)
                        color[j] = Color.FromArgb(130, 130, 130);
                    else if (rand.NextDouble() * 10 + 1 < 8)
                        color[j] = Color.FromArgb(110, 110, 110);
                    else if (rand.NextDouble() * 10 + 1 < 9)
                        color[j] = Color.FromArgb(90, 90, 90);
                    else if (rand.NextDouble() * 10 + 1 < 10)
                        color[j] = Color.FromArgb(70, 70, 70);
                    else
                        color[j] = Color.FromArgb(50, 50, 50);


                    step[j] = rand.NextDouble() * 10 + 1;

                    stars[i] = new Star
                    {
                        x = rand.NextDouble() * width,
                        y = rand.Next(height),
                        step = step[j], // 调整速度范围
                        size = rand.NextDouble() * 5 + 1, // 添加大小属性
                        color = color[j],
                    };

                }
            }
        }



        public void DrawStars(Graphics g, int width, int height)
        {
            Pen p = new Pen(Color.Black, 1)
            {
                LineJoin = System.Drawing.Drawing2D.LineJoin.Round, // 设置线条连接处为圆角
                EndCap = System.Drawing.Drawing2D.LineCap.Round // 设置线条端点为圆形
            };

            /*foreach (var star in stars)
            {
                // 使用星星的颜色创建一个新的画笔
                using (SolidBrush brush = new SolidBrush(star.color))
                {
                    g.FillEllipse(brush, (float)star.x, star.y, (float)star.size, (float)star.size); // 擦除旧星星 // 擦除旧星星
                    star.x += star.step;
                    if (star.x > width)
                    {
                        star.x = 0;
                        star.y = rand.Next(height);
                    }
                    // 绘制星星，这里我们绘制一个圆形来表示星星
                    // star.x 和 star.y 表示星星的中心位置
                    // star.size 表示星星的直径
                    g.FillEllipse(brush, (float)star.x, star.y, (float)star.size, (float)star.size); // 擦除旧星星 // 擦除旧星星
                }
            }*/

            for (int i = 0; i < MAXSTAR; i++)
            {
                // 使用星星的大小绘制
                g.FillEllipse(new SolidBrush(stars[i].color), (float)stars[i].x, stars[i].y, (float)stars[i].size, (float)stars[i].size); // 擦除旧星星 // 擦除旧星星
                stars[i].x += stars[i].step;
                if (stars[i].x > width)
                {
                    stars[i].x = 0;
                    stars[i].y = rand.Next(height);
                }

                p.Dispose(); // 释放Pen资源
            }
        }
        private class Star
        {
            public double x;
            public int y;
            public double step;
            public double size; // 新增大小属性
            public Color color;
        }
    }
}
