using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    public partial class Form1 : Form
    {
        Bitmap myBitmap;
        Graphics g;
        Pen DrawPen = new Pen(Color.DarkOliveGreen, 1);
        List<Point> VertexList = new List<Point>();//массив точек для временного хранения координат для рисования кривой Эрмита
        int CountPoints = 0; // Счетчик точек
        int Operation = 1; // тип операции
        bool checkPgn = false; //показывает, выделена фигура или нет
        Point pictureBoxMousePos = new Point();//положение курсора до начала преобразований
        List<Figure> FigureList = new List<Figure>();//список всех фигур
        Point centr = new Point();//центр, относительно которого производится масштабирование
        int work = -1, work2 = -1;//номер фигуры в списке фигур, с которой сейчас работают
        bool forSTO = false;//показывает, выделены ли фигуры для ТМО
        int STO = 0;//номер операции ТМО


        //Инициализация элементов окна
        public Form1()
        {
            InitializeComponent();
            myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(myBitmap);
        }

        // Обработчик события выбора цвета
        private void cbLineColor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (LineColor.SelectedIndex) // выбор цвета
            {
                case 0:
                    DrawPen.Color = Color.Black;
                    break;
                case 1:
                    DrawPen.Color = Color.DarkRed;
                    break;
                case 2:
                    DrawPen.Color = Color.DarkOliveGreen;
                    break;
                case 3:
                    DrawPen.Color = Color.CadetBlue;
                    break;
            }
        }



        // Очистка окна
        private void Clean_Click(object sender, EventArgs e)
        {
            pictureBox.Image = myBitmap;
            g.Clear(pictureBox.BackColor);
            Operation = 1;
            CountPoints = 0;
            VertexList.Clear();
            FigureList.Clear();
        }



        //Обработчик события нажатия на мышь
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {

            pictureBoxMousePos = e.Location;
            try
            {
                switch (Operation)
                {
                    case 2:
                        {
                            g.DrawEllipse(DrawPen, e.X - 2, e.Y - 2, 5, 5);
                            switch (CountPoints)
                            {
                                case 3: // второй вектор
                                    {
                                        VertexList.Add(pictureBoxMousePos);
                                        Spline NewSpline = new Spline(VertexList, DrawPen.Color);
                                        FigureList.Add(NewSpline);
                                        NewSpline.Fill(g);
                                        VertexList.Clear();
                                        CountPoints = 0;
                                    }
                                    break;
                                default:
                                    CountPoints++; VertexList.Add(pictureBoxMousePos); // иначе
                                    break;
                            }
                        }
                        break;
                    case 3:
                        {
                            g.DrawEllipse(DrawPen, e.X - 2, e.Y - 2, 5, 5);
                            Cross NewCross = new Cross(pictureBoxMousePos, DrawPen.Color);
                            FigureList.Add(NewCross);
                            NewCross.Fill(g);
                            break;
                        }
                    case 4:
                        {
                            g.DrawEllipse(DrawPen, e.X - 2, e.Y - 2, 5, 5);
                            Arrow NewArrow = new Arrow(pictureBoxMousePos, DrawPen.Color);
                            FigureList.Add(NewArrow);
                            NewArrow.Fill(g);
                            break;
                        }
                    case 5:
                        {
                            for (int i = 0; i < FigureList.Count; ++i)
                            {
                                if (FigureList[i].ThisFigure(e.X, e.Y))
                                {
                                    checkPgn = true;
                                    work = i;
                                    break;
                                }
                                else
                                {
                                    checkPgn = false;
                                }
                            }
                        }
                        break;
                    case 6:
                        {
                            for (int i = 0; i < FigureList.Count; ++i)
                            {
                                if (FigureList[i].ThisFigure(e.X, e.Y))
                                {
                                    g.Clear(pictureBox.BackColor);
                                    g.DrawEllipse(new Pen(Color.YellowGreen, 2), centr.X - 2, centr.Y - 2, 5, 5);
                                    for (int j = 0; j < FigureList.Count; ++j)
                                    {
                                        FigureList[j].Fill(g);
                                        pictureBox.Image = myBitmap;
                                    }
                                    g.DrawEllipse(new Pen(Color.YellowGreen, 2), e.X - 2, e.Y - 2, 5, 5);
                                    checkPgn = true;
                                    work = i;
                                    break;
                                }
                                else
                                {
                                    checkPgn = false;
                                }
                            }
                            break;
                        }
                    case 7:
                        {
                            for (int i = 0; i < FigureList.Count; ++i)
                            {
                                if (FigureList[i].ThisFigure(e.X, e.Y))
                                {
                                    checkPgn = true;
                                    work = i;
                                    break;
                                }
                                else
                                {
                                    checkPgn = false;
                                }
                            }
                            if (!checkPgn)
                            {
                                centr = e.Location;
                                Console.WriteLine(centr);
                                g.Clear(pictureBox.BackColor);
                                g.DrawEllipse(new Pen(Color.YellowGreen, 2), centr.X - 2, centr.Y - 2, 5, 5);
                                for (int j = 0; j < FigureList.Count; ++j)
                                {
                                    FigureList[j].Fill(g);
                                    pictureBox.Image = myBitmap;
                                }
                            }
                            break;
                        }
                    case 8:
                        {
                            if (FigureList.Count >= 2)
                            {
                                for (int i = 0; i < FigureList.Count; ++i)
                                {
                                    if (FigureList[i].ThisFigure(e.X, e.Y))
                                    {
                                        if (forSTO)
                                        {
                                            g.DrawEllipse(new Pen(Color.YellowGreen), e.X - 2, e.Y - 2, 5, 5);
                                            work = i;
                                            forSTO = false;
                                            List<PointF>[] a = SetTeoreticOperations(DrawPen, FigureList[work], FigureList[work2], STO);
                                            DerivedFigure NewDerivedFigure = new DerivedFigure(a, DrawPen.Color);
                                            FigureList.Add(NewDerivedFigure);
                                            NewDerivedFigure.Fill(g);
                                            FigureList.Remove(FigureList[work]);
                                            FigureList.Remove(FigureList[work2]);

                                            g.Clear(pictureBox.BackColor);
                                            g.DrawEllipse(new Pen(Color.YellowGreen, 2), centr.X - 2, centr.Y - 2, 5, 5);
                                            for (int j = 0; j < FigureList.Count; ++j)
                                            {
                                                FigureList[j].Fill(g);
                                                pictureBox.Image = myBitmap;
                                            }
                                            work = -1;
                                            work2 = -1;
                                            break;
                                        }
                                        else
                                        {
                                            g.DrawEllipse(new Pen(Color.YellowGreen), e.X - 2, e.Y - 2, 5, 5);
                                            forSTO = true;
                                            work2 = i;
                                            break;
                                        }
                                    }
                                    else checkPgn = false;
                                }
                            }
                            else
                            { MessageBox.Show("Пожалуйста, нарисуйте еще что-нибудь", "Слишком мало фигур"); forSTO = false; work = -1; work2 = -1; }
                        }
                        break;
                    case 9:
                        {
                            for (int i = 0; i < FigureList.Count; ++i)
                            {
                                if (FigureList[i].ThisFigure(e.X, e.Y))
                                {
                                    g.DrawEllipse(new Pen(Color.YellowGreen), e.X - 2, e.Y - 2, 5, 5);
                                    work = i;
                                    FigureList.Remove(FigureList[work]);
                                    g.Clear(pictureBox.BackColor);
                                    g.DrawEllipse(new Pen(Color.YellowGreen, 2), centr.X - 2, centr.Y - 2, 5, 5);
                                    for (int j = 0; j < FigureList.Count; ++j)
                                    {
                                        FigureList[j].Fill(g);
                                        pictureBox.Image = myBitmap;
                                    }
                                    work = -1;
                                    break;
                                }
                                else checkPgn = false;
                            }
                        }
                        break;
                }
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Эта операция не поддерживается", "Так нельзя");
                work = -1;
                work2 = -1;
            }
            pictureBox.Image = myBitmap;
        }


        // Обработчик события движения мыши
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (checkPgn)
                {
                    switch (Operation)
                    {
                        case 5:
                            {
                                FigureList[work].Move(e.X - pictureBoxMousePos.X, e.Y - pictureBoxMousePos.Y);
                                g.Clear(pictureBox.BackColor);
                                g.DrawEllipse(new Pen(Color.YellowGreen, 2), centr.X - 2, centr.Y - 2, 5, 5);
                                for (int i = 0; i < FigureList.Count; ++i)
                                {
                                    FigureList[i].Fill(g);
                                    pictureBox.Image = myBitmap;
                                }
                                pictureBoxMousePos = e.Location;
                            }
                            break;
                        case 7:
                            {
                                try
                                {
                                    FigureList[work].Scale(e.X, e.Y, pictureBox.Width, pictureBox.Height, centr);
                                    g.Clear(pictureBox.BackColor);
                                    g.DrawEllipse(new Pen(Color.YellowGreen, 2), centr.X - 2, centr.Y - 2, 5, 5);
                                    for (int i = 0; i < FigureList.Count; ++i)
                                    {
                                        FigureList[i].Fill(g);
                                        pictureBox.Image = myBitmap;
                                    }
                                    pictureBoxMousePos = e.Location;
                                }
                                catch (NotSupportedException)
                                {
                                    MessageBox.Show("Эта операция не поддерживается", "Так нельзя");
                                    work = -1;
                                    work2 = -1;
                                }
                            }
                            break;
                    }
                }
            }
        }


        //Обработчики событий нажатия на кнопки
        private void btCubeSpline_Click(object sender, EventArgs e)
        {
            Operation = 2;
        }

        private void btCross_Click(object sender, EventArgs e)
        {
            Operation = 3;
        }

        private void btArrow_Click(object sender, EventArgs e)
        {
            Operation = 4;
        }

        private void btMove_Click(object sender, EventArgs e)
        {
            Operation = 5;
        }

        private void btTurn_Click(object sender, EventArgs e)
        {
            if (checkPgn && Operation == 6)
            {
                try
                {
                    string anglestr = textAngle.Text;
                    float angle = 0;
                    if (float.TryParse(textAngle.Text, out angle))
                    {
                        angle = float.Parse(textAngle.Text) % 360;
                    }
                    FigureList[work].Turn(pictureBoxMousePos, angle);

                    g.Clear(pictureBox.BackColor);
                    for (int i = 0; i < FigureList.Count; ++i)
                    {
                        FigureList[i].Fill(g);
                        pictureBox.Image = myBitmap;
                    }
                    g.DrawEllipse(new Pen(Color.YellowGreen, 2), centr.X - 2, centr.Y - 2, 5, 5);
                    g.DrawEllipse(new Pen(Color.YellowGreen, 2), pictureBoxMousePos.X, pictureBoxMousePos.Y, 5, 5);
                }
                catch (NotSupportedException)
                {
                    MessageBox.Show("Эта операция не поддерживается", "Так нельзя");
                    work = -1;
                    work2 = -1;
                }
            }
            else
            {
                Operation = 6;
            }
        }

        private void btScale_Click(object sender, EventArgs e)
        {
            Operation = 7;
        }

        private void Intersection_Click(object sender, EventArgs e)
        {
            Operation = 8;
            STO = 2;
        }

        private void Disjoint_Click(object sender, EventArgs e)
        {
            Operation = 8;
            STO = 3;
        }
        private void btRemove_Click(object sender, EventArgs e)
        {
            Operation = 9;
        }

        //Метод для выполнения ТМО
        public List<PointF>[] SetTeoreticOperations(Pen DrawPen, Figure figure1, Figure figure2, int STO)
        {
            int h = 0, g = 0;
            List<Data> M = new List<Data>();
            List<PointF> Xrl = new List<PointF>();
            List<PointF> Xrr = new List<PointF>();
            int Xemin = 0;
            int Xemax = pictureBox.Size.Height;

            switch (STO)
            {
                case 2: // пересечение
                    h = 3; g = 3;
                    break;
                case 3: // сим. разность
                    h = 1; g = 2;
                    break;
            }

            List<int> Xal = new List<int>();
            List<int> Xar = new List<int>();
            List<int> Xbl = new List<int>();
            List<int> Xbr = new List<int>();
            int Ymin2 = 0;
            int Ymax2 = pictureBox.Height;


            List<int> X = new List<int>();

            for (int Y = Ymin2; Y != Ymax2; ++Y)
            {
                M.Clear();
                X.Clear();
                Xal.Clear();
                Xar.Clear();
                Xbl.Clear();
                Xbr.Clear();
                X = figure1.Borders(Y);
                for (int i = 0; i < X.Count - 1; i = i + 2)
                {
                    Xal.Add(X[i]);
                    Xar.Add(X[i + 1]);
                }

                X.Clear();
                X = figure2.Borders(Y);
                for (int i = 0; i < X.Count - 1; i = i + 2)
                {
                    Xbl.Add(X[i]);
                    Xbr.Add(X[i + 1]);
                }


                int n = Xal.Count;
                for (int i = 0; i < n; ++i)
                {
                    M.Add(new Data(Xal[i], 2));
                }
                int nM = n;
                n = Xar.Count;
                for (int i = 0; i < n; ++i)
                {
                    M.Add(new Data(Xar[i], -2));
                }
                nM = nM + n;
                n = Xbl.Count;
                for (int i = 0; i < n; ++i)
                {
                    M.Add(new Data(Xbl[i], 1));
                }
                nM = nM + n;
                n = Xbr.Count;
                for (int i = 0; i < n; ++i)
                {
                    M.Add(new Data(Xbr[i], -1));
                }
                nM = nM + n; // общее число элементов в массиве M
                M.Sort((x1, x2) => x1.x.CompareTo(x2.x));
                int Q = 0;
                if (M.Count != 0)
                {
                    if ((M[0].x >= Xemin) && (M[0].dQ < 0))
                    {
                        Xrl.Add(new Point(Xemin, Y));
                        Q = -1 * M[0].dQ;
                    }
                    for (int i = 0; i < nM; ++i)
                    {
                        int x = M[i].x;
                        int Qnew = Q + M[i].dQ;
                        if (!(Q >= h && Q <= g) && (Qnew >= h && Qnew <= g))
                        {
                            Xrl.Add(new Point(x, Y));
                        }
                        if ((Q >= h && Q <= g) && !(Qnew >= h && Qnew <= g))
                        {
                            Xrr.Add(new Point(x, Y));
                        }
                        Q = Qnew;
                    }
                    if ((Q >= h) && (Q <= g))
                    {
                        Xrr.Add(new Point(Xemax, Y));
                    }
                }
            }
            return new[] { Xrl, Xrr };
        }

        //Класс для метода ТМО
        class Data
        {
            public int x { get; set; }
            public int dQ { get; set; }

            public Data(int x, int dQ)
            {
                this.x = x;
                this.dQ = dQ;
            }
        }
    }
}
