using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    public abstract class Figure
    {
        // Метод визуализации фигуры
        public abstract void Fill(Graphics g);
        //Метод выделения фигуры
        public abstract bool ThisFigure(int mX, int mY);
        // Метод плоскопараллельного перемещения
        public abstract void Move(int dx, int dy);
        // Метод поворота фигуры относительно начала координат
        public abstract void Turn(Point p, float angle);
        // Метод масштабирования фигуры относительно начала координат
        public abstract void Scale(float x, float y, int pbx, int pby, Point p);
        // Метод для нахождения всех координат X для конкретной строки Y
        public abstract List<int> Borders(int Y);
    }
}
