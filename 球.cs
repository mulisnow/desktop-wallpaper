using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 壁纸
{
    internal class 球
    {
        private const double PI = Math.PI;

        public int angle;
        public void HideSphere(Graphics g,int width,int height, float R, int alfa, int beta, int HideFlag)
        {
            Pen pens = new Pen(Color.White, 1)
            {
                LineJoin = System.Drawing.Drawing2D.LineJoin.Round, // 设置线条连接处为圆角
                EndCap = System.Drawing.Drawing2D.LineCap.Round // 设置线条端点为圆形
            };
            float[] x = new float[4], y = new float[4], z = new float[4], x1 = new float[4], y1 = new float[4], z1 = new float[4], sx = new float[4], sy = new float[4];
            double a1, a2, b1, b2, c, d, xn, yn, zn, vn;
            c = alfa * PI / 180.0;
            d = beta * PI / 180.0;
            for (int j = 0; j < 180; j += 5)
            {
                a1 = j * PI / 180.0;
                a2 = (j + 5) * PI / 180.0;
                for (int i = 0; i < 360; i += 5)
                {
                    b1 = i * PI / 180.0;
                    b2 = (i + 5) * PI / 180.0;
                    x[0] = (float)(R * Math.Sin(a1) * Math.Cos(b1)); y[0] = (float)(R * Math.Sin(a1) * Math.Sin(b1)); z[0] = (float)(R * Math.Cos(a1));
                    x[1] = (float)(R * Math.Sin(a2) * Math.Cos(b1)); y[1] = (float)(R * Math.Sin(a2) * Math.Sin(b1)); z[1] = (float)(R * Math.Cos(a2));
                    x[2] = (float)(R * Math.Sin(a2) * Math.Cos(b2)); y[2] = (float)(R * Math.Sin(a2) * Math.Sin(b2)); z[2] = (float)(R * Math.Cos(a2));
                    x[3] = (float)(R * Math.Sin(a1) * Math.Cos(b2)); y[3] = (float)(R * Math.Sin(a1) * Math.Sin(b2)); z[3] = (float)(R * Math.Cos(a1));
                    for (int k = 0; k < 4; k++)
                    {
                        x1[k] = (float)(x[k] * Math.Cos(c) - y[k] * Math.Sin(c));
                        y1[k] = (float)(x[k] * Math.Sin(c) * Math.Cos(d) + y[k] * Math.Cos(c) * Math.Sin(d) + z[k] * Math.Sin(d));
                        z1[k] = (float)(-x[k] * Math.Sin(c) * Math.Sin(d) - y[k] * Math.Cos(c) * Math.Sin(d) + z[k] * Math.Cos(d));
                        // 调整坐标，使球体绘制在窗口中央
                        sx[k] = width / 2 + x1[k]; // 窗口宽度的一半加上变换后的 x 坐标
                        sy[k] = height / 2 - z1[k]; // 窗口高度的一半减去变换后的 z 坐标
                    }

                    xn = (y1[2] - y1[0]) * (z1[3] - z1[1]) - (y1[3] - y1[1]) * (z1[2] - z1[0]);
                    yn = -(x1[2] - x1[0]) * (z1[3] - z1[1]) + (x1[3] - x1[1]) * (z1[2] - z1[0]);
                    zn = (x1[2] - x1[0]) * (y1[3] - y1[1]) - (x1[3] - x1[1]) * (y1[2] - y1[0]);
                    vn = Math.Sqrt(xn * xn + yn * yn + zn * zn);
                    xn = xn / vn;
                    yn = yn / vn;
                    zn = zn / vn;
                    if (HideFlag == 0 || yn >= 0.0)
                    {
                        // 绘制四边形的四条边
                        for (int k = 0; k < 3; k++)
                        {
                            g.DrawLine(Pens.White, sx[k], sy[k], sx[k + 1], sy[k + 1]);
                        }
                        // 连接最后一点和起始点，闭合四边形
                        g.DrawLine(Pens.White, sx[3], sy[3], sx[0], sy[0]);
                    }
                }
            }

        }
    }
}
        
