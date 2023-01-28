using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    class DerivedFigure : Figure
    {
        List<PointF> Left; //список левых границ фигуры
        List<PointF> Right; //список правых границ фигуры
        Color color; //цвет фигуры

        //конструктор
        public DerivedFigure(List<PointF>[] VertexList, Color color)
        {
            Left = VertexList[0];
            Right = VertexList[1];
            this.color = color;
        }

        public override List<int> Borders(int Y)
        {
            List<int> X = new List<int>();
            for (int i = 0; i < Left.Count; ++i)
            {
                if(Y == Left[i].Y) {X.Add((int)Left[i].X);}
                if(Y == Right[i].Y) {X.Add((int)Right[i].X);}
            }
            return X;
        }


        //метод рисования фигуры
        public override void Fill(Graphics g)
        {
            for (int i = 0; i < Left.Count; i++)
            {
                g.DrawLine(new Pen(color), Left[i], Right[i]);
            }
        }

        //метод выделения фигуры
        public override bool ThisFigure(int mX, int mY)
        {
            for (int i = 0; i < Left.Count; i++)
            {
                if (mX >= Left[i].X & mX <= Right[i].X && Left[i].Y == mY) { return true; }
            }
            return false;
        }


        // плоско-параллельное перемещение
        public override void Move(int dx, int dy)
        {
            int n = Left.Count() - 1;
            PointF fP = new PointF();
            for (int i = 0; i <= n; i++)
            {
                fP.X = Left[i].X + dx;
                fP.Y = Left[i].Y + dy;
                Left[i] = fP;
            }
            for (int i = 0; i <= n; i++)
            {
                fP.X = Right[i].X + dx;
                fP.Y = Right[i].Y + dy;
                Right[i] = fP;
            }
        }

        //поворот
        public override void Turn(Point p, float angle)
        {
            throw new NotSupportedException();//не нужен
        }

        //масштабирование
        public override void Scale(float x, float y, int dx, int dy, Point p)
        {
            throw new NotSupportedException();//не нужен
        }
    }
}
