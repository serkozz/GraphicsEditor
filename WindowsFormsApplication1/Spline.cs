using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    class Spline : Figure
    {
        PointF Centr; //центр фигуры
        public List<PointF> VertexList;//список точек для векторов кривой
        private int Xmin, Xmax, Ymin, Ymax;//максимальные и минимальный значения кривой
        Color color;//цвет кривой

        //конструктор
        public Spline(List<Point> VertexList, Color color)
        {
            this.VertexList = new List<PointF>();
            for (int i = 0; i < VertexList.Count; ++i)
            {
                this.VertexList.Add(VertexList[i]);
            }
            this.color = color;
        }

        //список координат X для строки Y
        public override List<int> Borders(int Y)
        {
            throw new NotSupportedException();//не нужен
        }


        // визуализация кривой
        public override void Fill(Graphics g)
        {
            for (int i = 0; i < VertexList.Count; ++i)
            {
                g.DrawEllipse(new Pen(color), VertexList[i].X - 2, VertexList[i].Y - 2, 5, 5);
            }
            double dt = 0.01;
            double xT = VertexList[0].X;
            double yT = VertexList[0].Y;
            Xmin = (int)Math.Round(VertexList[0].X);
            Xmax = Xmin;
            Ymin = (int)Math.Round(VertexList[0].Y);
            Ymax = Ymin;
            for (double t = dt; t < 1 + dt / 2; t += dt)
            {
                double xt = 0;
                double yt = 0;
                int[] mas = new int[8];
                mas[0] = (int)(2 * VertexList[0].X - 2 * VertexList[2].X + (VertexList[1].X - VertexList[0].X) + (VertexList[3].X - VertexList[2].X));
                mas[1] = (int)(-3 * VertexList[0].X + 3 * VertexList[2].X - 2 * (VertexList[1].X - VertexList[0].X) - (VertexList[3].X - VertexList[2].X));
                mas[2] = (int)(VertexList[1].X - VertexList[0].X);
                mas[3] = (int)(VertexList[0].X);
                mas[4] = (int)(2 * VertexList[0].Y - 2 * VertexList[2].Y + (VertexList[1].Y - VertexList[0].Y) + (VertexList[3].Y - VertexList[2].Y));
                mas[5] = (int)(-3 * VertexList[0].Y + 3 * VertexList[2].Y - 2 * (VertexList[1].Y - VertexList[0].Y) - (VertexList[3].Y - VertexList[2].Y));
                mas[6] = (int)(VertexList[1].Y - VertexList[0].Y);
                mas[7] = (int)(VertexList[0].Y);
                xt = mas[0] * Math.Pow(t, 3) + mas[1] * Math.Pow(t, 2) + mas[2] * t + mas[3];
                yt = mas[4] * Math.Pow(t, 3) + mas[5] * Math.Pow(t, 2) + mas[6] * t + mas[7];
                g.DrawLine(new Pen(color, 1), (int)xT, (int)yT, (int)xt, (int)yt);
                if (xt < Xmin) Xmin = (int)xt;
                if (xt > Xmax) Xmax = (int)xt;
                if (yt < Ymin) Ymin = (int)yt;
                if (yt > Ymax) Ymax = (int)yt;
                if (t >= 0.5 - dt / 2 && t <= 0.5 + dt / 2) { Centr.X = (int)xt; Centr.Y = (int)yt; }
                xT = xt;
                yT = yt;
            }
        }


        //медод выделения сплайна
        public override bool ThisFigure(int mX, int mY)
        {
            bool check = false;
            double dt = 0.01;
            double xT = VertexList[0].X;
            double yT = VertexList[0].Y;
            for (double t = dt; t < 1 + dt / 2; t += dt)
            {
                double xt = 0;
                double yt = 0;
                int[] mas = new int[8];
                mas[0] = (int)(2 * VertexList[0].X - 2 * VertexList[2].X + (VertexList[1].X - VertexList[0].X) + (VertexList[3].X - VertexList[2].X));
                mas[1] = (int)(-3 * VertexList[0].X + 3 * VertexList[2].X - 2 * (VertexList[1].X - VertexList[0].X) - (VertexList[3].X - VertexList[2].X));
                mas[2] = (int)(VertexList[1].X - VertexList[0].X);
                mas[3] = (int)(VertexList[0].X);
                mas[4] = (int)(2 * VertexList[0].Y - 2 * VertexList[2].Y + (VertexList[1].Y - VertexList[0].Y) + (VertexList[3].Y - VertexList[2].Y));
                mas[5] = (int)(-3 * VertexList[0].Y + 3 * VertexList[2].Y - 2 * (VertexList[1].Y - VertexList[0].Y) - (VertexList[3].Y - VertexList[2].Y));
                mas[6] = (int)(VertexList[1].Y - VertexList[0].Y);
                mas[7] = (int)(VertexList[0].Y);
                xt += mas[0] * Math.Pow(t, 3) + mas[1] * Math.Pow(t, 2) + mas[2] * t + mas[3];
                yt += mas[4] * Math.Pow(t, 3) + mas[5] * Math.Pow(t, 2) + mas[6] * t + mas[7];
                if (mX > xT && mX < xt && mY > Ymin && mY < Ymax)
                {
                    check = true;
                }
                xT = xt;
                yT = yt;
            }
            return check;
        }



        // плоско-параллельное перемещение
        public override void Move(int dx, int dy)
        {
            int n = VertexList.Count() - 1;
            PointF fP = new PointF();
            for (int i = 0; i <= n; i++)
            {
                fP.X = VertexList[i].X + dx;
                fP.Y = VertexList[i].Y + dy;
                VertexList[i] = fP;
            }
        }

        //поворот
        public override void Turn(Point p, float angle)
        {
            int n = VertexList.Count() - 1;
            PointF fP = new PointF();

            double cos = Math.Cos(angle * Math.PI / 180);
            double sin = Math.Sin(angle * Math.PI / 180);

            for (int i = 0; i <= n; i++)
            {
                fP.X = p.X + (VertexList[i].X - p.X) * (float)cos - (VertexList[i].Y - p.Y) * (float)sin;
                fP.Y = p.Y + (VertexList[i].X - p.X) * (float)sin + (VertexList[i].Y - p.Y) * (float)cos;
                VertexList[i] = fP;
            }
        }

        //масштабирование
        public override void Scale(float x, float y, int pbx, int pby, Point p)
        {
            int n = VertexList.Count() - 1;
            PointF fP = new PointF();
            float mx = 1, my = 1;

            if (x > p.X && Centr.X > p.X) mx = (x + pbx) / (Xmax + pbx);
            if (x < p.X && Centr.X < p.X) mx = (Xmin + pbx) / (x + pbx);
            if (y > p.Y && Centr.Y > p.Y) my = (y + pby) / (Ymax + pby);
            if (y < p.Y && Centr.Y < p.Y) my = (Ymin + pby) / (y + pby);
            if (mx > 1 / (Xmax - Centr.X) && my > 1 / (Ymax - Centr.Y))
            {
                for (int i = 0; i <= n; i++)
                {
                    fP.X = VertexList[i].X * mx + (1 - mx) * p.X;
                    fP.Y = VertexList[i].Y * my + (1 - my) * p.Y;
                    VertexList[i] = fP;
                }
            }
        }
    }
}
