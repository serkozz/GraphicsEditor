using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    class Cross : Figure
    {
        PointF Centr;
        List<PointF> VertexList;
        private int Xmin, Xmax, Ymin, Ymax;
        Color color;

        //конструктор
        public Cross(Point e, Color color)
        {
            VertexList = new List<PointF>();
            Centr = e;
            VertexList.Add(new Point() { X = e.X - 15, Y = e.Y - 45 });
            VertexList.Add(new Point() { X = e.X + 15, Y = e.Y - 45 });
            VertexList.Add(new Point() { X = e.X + 15, Y = e.Y - 15 });
            VertexList.Add(new Point() { X = e.X + 45, Y = e.Y - 15 });
            VertexList.Add(new Point() { X = e.X + 45, Y = e.Y + 15 });
            VertexList.Add(new Point() { X = e.X + 15, Y = e.Y + 15 });
            VertexList.Add(new Point() { X = e.X + 15, Y = e.Y + 45 });
            VertexList.Add(new Point() { X = e.X - 15, Y = e.Y + 45 });
            VertexList.Add(new Point() { X = e.X - 15, Y = e.Y + 15 });
            VertexList.Add(new Point() { X = e.X - 45, Y = e.Y + 15 });
            VertexList.Add(new Point() { X = e.X - 45, Y = e.Y - 15 });
            VertexList.Add(new Point() { X = e.X - 15, Y = e.Y - 15 });
            this.color = color;
        }

        //возвращает список точек
        public override List<int> Borders(int Y)
        {
            List<int> X = new List<int>();
            int k = 0;

            for (int i = 0; i < VertexList.Count; ++i)
            {
                if (i < VertexList.Count - 1)
                {
                    k = i + 1;
                }
                else
                {
                    k = 0;
                }

                if (((VertexList[i].Y < Y) && (VertexList[k].Y >= Y)) || ((VertexList[i].Y >= Y) && (VertexList[k].Y < Y)))
                {
                    int x = (int)(((Y - VertexList[i].Y) * (VertexList[k].X - VertexList[i].X)) / (VertexList[k].Y - VertexList[i].Y) + VertexList[i].X); //вычисление границ закрашивания в данной строке
                    X.Add(x);
                }
            }
            X.Sort();
            return X;
        }

        //медод выделения фигуры
        public override bool ThisFigure(int mX, int mY)
        {
            // преобразование координат в int
            List<Point> PointL = new List<Point>();
            Point P1;
            P1 = new Point();
            int n = VertexList.Count() - 1, k = 0;
            int Y = mY, X;
            double x;
            List<int> Xb = new List<int>(); // буфер сегментов
            bool check = false;

            for (int i = 0; i <= n; i++)
            {
                P1.X = (int)Math.Round(VertexList[i].X);
                P1.Y = (int)Math.Round(VertexList[i].Y);
                PointL.Add(P1);
            }

            Xb.Clear();
            for (int i = 0; i <= n; i++)
            {
                if (i < n) k = i + 1; else k = 0;
                if ((PointL[i].Y < Y) & (PointL[k].Y >= Y) | (PointL[i].Y >= Y) & (PointL[k].Y < Y))
                {
                    x = (Y - PointL[i].Y) * (PointL[k].X - PointL[i].X) / (PointL[k].Y - PointL[i].Y) + PointL[i].X;
                    X = (int)Math.Round(x);
                    Xb.Add(X);
                }
            }
            if (Xb.Count() > 0)
            {
                Xb.Sort();  // по умолчанию по возрастанию
                for (int i = 0; i < Xb.Count; i = i + 2)
                {
                    if (mX >= Xb[i] & mX <= Xb[i + 1]) { check = true; break; }
                }
            }
            PointL.Clear();
            return check;
        }

        // визуализация креста
        public override void Fill(Graphics g)
        {
            // преобразование координат в int
            List<Point> PointL = new List<Point>();
            Point P1, P2;
            P1 = new Point();
            int n = VertexList.Count() - 1, k = 0;

            Xmin = (int)Math.Round(VertexList[0].X);
            Xmax = Xmin;
            for (int i = 0; i <= n; i++)
            {
                P1.X = (int)Math.Round(VertexList[i].X);
                P1.Y = (int)Math.Round(VertexList[i].Y);
                PointL.Add(P1);
                if (P1.X < Xmin) Xmin = P1.X;
                if (P1.X > Xmax) Xmax = P1.X;
            }
            Centr.X = ((Xmax - Xmin) / 2) + Xmin;

            Ymin = (int)Math.Round(VertexList[0].Y);
            Ymax = Ymin;
            int Y = 0, X;
            for (int i = 0; i <= n; i++)
            {
                P1.X = (int)Math.Round(VertexList[i].X);
                P1.Y = (int)Math.Round(VertexList[i].Y);
                PointL.Add(P1);
                if (P1.Y < Ymin) Ymin = P1.Y;
                if (P1.Y > Ymax) Ymax = P1.Y;
            }
            Centr.Y = ((Ymax - Ymin) / 2) + Ymin;

            List<int> Xb = new List<int>();
            double x;
            P1.X = 0; P1.Y = 0; P2 = P1;

            for (Y = Ymin; Y <= Ymax; Y++)
            {
                Xb.Clear();
                for (int i = 0; i <= n; i++)
                {
                    if (i < n) k = i + 1; else k = 0;
                    if ((PointL[i].Y < Y) & (PointL[k].Y >= Y) | (PointL[i].Y >= Y) & (PointL[k].Y < Y))
                    {
                        x = (Y - PointL[i].Y) * (PointL[k].X - PointL[i].X) / (PointL[k].Y - PointL[i].Y) + PointL[i].X;
                        X = (int)Math.Round(x);
                        Xb.Add(X);
                    }
                }
                Xb.Sort();  // по умолчанию по возрастанию
                for (int i = 0; i < Xb.Count; i = i + 2)
                {
                    P1.X = Xb[i]; P1.Y = Y;
                    P2.X = Xb[i + 1]; P2.Y = Y;

                    g.DrawLine(new Pen(color), P1, P2);
                }
            }
            PointL.Clear();
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

            if (x > p.X && Centr.X > p.X) mx = ( x + pbx) / (Xmax + pbx);
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
