using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfOverlayPen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Info3Register.RegisterRule reg = new Info3Register.RegisterRule("AAACgACc+lEc6YzClUOUBFJC3mINQglzimzw65EEeQWTtJzcjihSTKWyRktpJ5aosU5lbjk4QR6QZUihN3erIJ6nxZQE5pDl+66arTnt84HeIqhg7odRdhfZR1gJaffcBIoJn5dmKfp0HWGZSej8QjTdh0hwdbLhNfpFqOWVaPoda1EWAwMAAQAB");

        List<StrokeCollection> history = new List<StrokeCollection>();
        List<Stroke> history2 = new List<Stroke>();
        List<Rectangle> listelements = new List<Rectangle>();
        DispatcherTimer t = new DispatcherTimer();
        Enumaction action;

        Point initialP;
        bool desenhando;
        Color atualcolor;
        double atualespessura;
        double atualopacidade;

        object imgpadrao;
        object imgatual;

        double angulo = 0;
        double distencia = 100;

        enum Enumaction { livre, quadrado, circulo, linha }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        

        public MainWindow()
        {
            //Licenciamento();

            InitializeComponent();
            Loaded += MainWindow_Loaded;
            atualcolor = Colors.Black;
            Closing += MainWindow_Closing;
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (!fechar)
            //    e.Cancel = true;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnlivre.MouseLeftButtonUp += Btn_Click;
            btnapagar.MouseLeftButtonUp += Btn_Click;
            btnvoltar.MouseLeftButtonUp += Btn_Click;
            btnquadrado.MouseLeftButtonUp += Btn_Click;
            btncirculo.MouseLeftButtonUp += Btn_Click;
            btnLine.MouseLeftButtonUp += Btn_Click;
            btnconfig.MouseLeftButtonUp += Btn_Click;
            btnSair.MouseLeftButtonUp += Btn_Click;

            btnlivre.StylusSystemGesture += Btn_StylusSystemGesture;
            btnapagar.StylusSystemGesture += Btn_StylusSystemGesture;
            btnvoltar.StylusSystemGesture += Btn_StylusSystemGesture;
            btnquadrado.StylusSystemGesture += Btn_StylusSystemGesture;
            btncirculo.StylusSystemGesture += Btn_StylusSystemGesture;
            btnLine.StylusSystemGesture += Btn_StylusSystemGesture;
            btnconfig.StylusSystemGesture += Btn_StylusSystemGesture;
            btnSair.StylusSystemGesture += Btn_StylusSystemGesture;

            paintboard.MouseUp += Paintboard_MousenUp;
            paintboard.MouseDown += Paintboard_MouseDown;

            MouseMove += MainWindow_MouseMove;
            StylusMove += MainWindow_StylusMove;
            paintboard.StrokeCollected += Paintboard_StrokeCollected;
            paintboard.DefaultDrawingAttributes.FitToCurve = true;

            btnactv.MouseLeftButtonDown += Btnactv_MouseDown;
            btnactv.MouseUp += Btnactv_MouseUp;

            moveElements.AddRange(new List<MoveData>() { new MoveData(btnlivre), new MoveData(btnLine), new MoveData(btnquadrado), new MoveData(btncirculo), new MoveData(btnconfig), new MoveData(btnapagar), new MoveData(btnvoltar), new MoveData(btnSair) });
            t.Interval = new TimeSpan(300);
            t.Tick += T_Tick;
            t.Start();

            this.Top = System.Windows.SystemParameters.PrimaryScreenHeight - 150;
            this.Left = System.Windows.SystemParameters.PrimaryScreenWidth - 130;
            imgpadrao = btnactv.Fill;
            imgatual = imgpadrao;

            atualespessura = 10;
            atualopacidade = 254;
            Modificarconfig(0, 0);

            Setcolor();
            SelecionarFerramenta(btnPreto);

            btnactv.StylusSystemGesture += Btnactv_StylusSystemGesture;
            btnactv.StylusUp += Btnactv_StylusUp;
            paintboard.StylusSystemGesture += Paintboard_StylusSystemGesture;
            paintboard.StylusUp += Paintboard_StylusUp;

        }

        void Paintboard_StylusUp(object sender, StylusEventArgs e)
        {
            desenhando = false;
        }

        void Paintboard_StylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            if (e.SystemGesture == SystemGesture.Drag)
            {
                if (action == Enumaction.quadrado)
                {
                    initialP = e.GetPosition(null);
                    paintboard.Strokes.Add(NewRectangle(initialP.X, initialP.Y, 0, 0));
                    desenhando = true;
                }
                if (action == Enumaction.circulo)
                {
                    initialP = e.GetPosition(null);
                    paintboard.Strokes.Add(NewCircle(initialP.X, initialP.Y, 0));
                    desenhando = true;

                }
                if (action == Enumaction.linha)
                {
                    initialP = e.GetPosition(null);
                    paintboard.Strokes.Add(NewLine(initialP.X, initialP.Y, initialP.X, initialP.Y));
                    desenhando = true;
                }
                FecharMenu();
            }
        }

        void Btnactv_StylusUp(object sender, StylusEventArgs e)
        {
            movebtn = false;

        }

        void MainWindow_StylusMove(object sender, StylusEventArgs e)
        {
            ActionMove(MouseButtonState.Pressed, e.GetPosition(null));

        }

        void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            ActionMove(e.LeftButton, e.GetPosition(null));
        }

        void Btn_Click(object sender, RoutedEventArgs e)
        {
            ActionButton(sender);
        }

        void Btn_StylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            if (e.SystemGesture == SystemGesture.Tap)
            {
                ActionButton(sender);
            }
        }

        void Btnactv_StylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            switch (e.SystemGesture)
            {
                case SystemGesture.Tap:
                    //abrir desenhador se tiver fechado
                    AbrirDesenhador();
                    break;

                case SystemGesture.RightTap:
                    // abrir menu
                    AbrirMenu();
                    break;

                case SystemGesture.Drag:
                    //mover janela ou botão
                    MoverBotao();
                    MoverJanela();
                    break;
            }
        }

        void AbrirDesenhador()
        {
            if (this.WindowState != System.Windows.WindowState.Maximized)
            {
                Point pFinal = new Point(this.Left, this.Top);

                this.WindowState = System.Windows.WindowState.Maximized;
                btnactv.Margin = new Thickness(pFinal.X, pFinal.Y, 0, 0);
                btnactv.Fill = imgatual as Brush;
            }
        }

        void AbrirMenu()
        {

            angulo = 0;
            foreach (var item in moveElements)
            {
                Point position = Calculaposicao(new Point(btnactv.Margin.Left, btnactv.Margin.Top), angulo, distencia);
                angulo += (360 / moveElements.Count);
                item.MoveTo(new Point(btnactv.Margin.Left, btnactv.Margin.Top), position);
            }
            MenuOpen = true;
        }

        bool MenuOpen = false;
        void FecharMenu()
        {
            moveElements.ForEach(o => o.Hidden());
            MenuOpen = false;
        }

        void MoverBotao()
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                movebtn = true;
            }
        }

        void MoverJanela()
        {
            if (this.WindowState != System.Windows.WindowState.Maximized)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(new System.Windows.Interop.WindowInteropHelper(this).Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }

        Point menuPt = new Point();
        void Btnactv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (this.WindowState != System.Windows.WindowState.Maximized)
                {
                    winpos = new Point(this.Left, this.Top);

                    this.DragMove();
                }
                else
                {
                    movebtn = true;
                    menuPt = new Point(btnactv.Margin.Left, btnactv.Margin.Top);
                }
                
            }
        }

        void Btnactv_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point pFinal = new Point(this.Left, this.Top);
            if (e.ChangedButton == MouseButton.Left)
            {
                //Point pFinal = new Point(this.Left, this.Top);
                if (this.WindowState != System.Windows.WindowState.Maximized && Point.Subtract(winpos, pFinal).Length < 20.0)
                {
                    this.WindowState = System.Windows.WindowState.Maximized;
                    btnactv.Margin = new Thickness(pFinal.X, pFinal.Y, 0, 0);
                    btnactv.Fill = imgatual as Brush;

                }
                else
                {
                    //}
                    //if (e.ChangedButton == MouseButton.Right)
                    //{
                    if (this.WindowState == System.Windows.WindowState.Maximized && Point.Subtract(menuPt, new Point(btnactv.Margin.Left, btnactv.Margin.Top)).Length < 10.0)
                    {
                        if (MenuOpen)
                            FecharMenu();
                        else
                            AbrirMenu();
                        //angulo = 0;
                        //foreach (var item in moveElements)
                        //{
                        //    Point position = calculaposicao(new Point(btnactv.Margin.Left, btnactv.Margin.Top), angulo, distencia);
                        //    angulo += (360 / moveElements.Count);
                        //    item.MoveTo(new Point(btnactv.Margin.Left, btnactv.Margin.Top), position);
                        //}
                    }
                }
            }

            movebtn = false;
        }

        void Paintboard_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            FecharMenu();
            configwin.Visibility = System.Windows.Visibility.Hidden;
        }

        void ActionMove(MouseButtonState e, Point position)
        {
            if (e == MouseButtonState.Pressed)
            {
                if (movebtn)
                {
                    btnactv.Margin = new Thickness(position.X - btnactv.Width / 2, position.Y - btnactv.Height / 2, 0, 0);
                    FecharMenu();

                }
                else

                    if (desenhando)
                    {
                        if (action == Enumaction.quadrado)
                        {

                            paintboard.Strokes[paintboard.Strokes.Count - 1] = NewRectangle(initialP.X, initialP.Y, position.X - initialP.X, position.Y - initialP.Y);
                        }
                        if (action == Enumaction.circulo)
                        {
                            double distancia = Math.Sqrt(Math.Pow(initialP.X - position.X, 2) + Math.Pow(initialP.Y - position.Y, 2));
                            paintboard.Strokes[paintboard.Strokes.Count - 1] = NewCircle(initialP.X, initialP.Y, distancia);
                        }
                        if (action == Enumaction.linha)
                        {
                            paintboard.Strokes[paintboard.Strokes.Count - 1] = NewLine(initialP.X, initialP.Y, position.X, position.Y);
                        }
                    }
            }
        }

        void ActionButton(object obj)
        {
            if (obj == btnquadrado)
            {
                paintboard.EditingMode = InkCanvasEditingMode.None;
                action = Enumaction.quadrado;
                FecharMenu();
                imgatual = (obj as Rectangle).Fill;
                btnactv.Fill = imgatual as Brush;
            }
            if (obj == btncirculo)
            {
                paintboard.EditingMode = InkCanvasEditingMode.None;
                action = Enumaction.circulo;
                FecharMenu();
                imgatual = (obj as Rectangle).Fill;
                btnactv.Fill = imgatual as Brush;
            }
            if (obj == btnLine)
            {
                paintboard.EditingMode = InkCanvasEditingMode.None;
                action = Enumaction.linha;
                FecharMenu();
                imgatual = (obj as Rectangle).Fill;
                btnactv.Fill = imgatual as Brush;
            }

            if (obj == btnlivre)
            {
                paintboard.EditingMode = InkCanvasEditingMode.Ink;
                action = Enumaction.livre;
                FecharMenu();
                imgatual = (obj as Rectangle).Fill;
                btnactv.Fill = imgatual as Brush;
            }
            if (obj == btnSair)
            {
                if (this.WindowState == System.Windows.WindowState.Maximized)
                {
                    this.WindowState = System.Windows.WindowState.Normal;
                    this.Left = btnactv.Margin.Left;
                    this.Top = btnactv.Margin.Top;
                    btnactv.Margin = new Thickness(0, 0, 0, 0);
                    //novo
                    paintboard.Strokes.Clear();
                    FecharMenu();
                    btnactv.Fill = imgpadrao as Brush;
                }
            }
            if (obj == btnvoltar)
            {
                if (paintboard.Strokes.Count > 0)
                    paintboard.Strokes.RemoveAt(paintboard.Strokes.Count - 1);
            }
            if (obj == btnapagar)
            {
                paintboard.Strokes.Clear();

                FecharMenu();
            }
            if (obj == btnconfig)
            {
                configwin.Margin = new Thickness(paintboard.ActualWidth / 2 - configwin.Width / 2, paintboard.ActualHeight / 2 - configwin.Height / 2, 0, 0);
                configwin.Visibility = configwin.Visibility == System.Windows.Visibility.Visible ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible;
                FecharMenu();
            }

        }

        bool movebtn = false;
        Point winpos;



        void Paintboard_MousenUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                desenhando = false;
        }

        void Paintboard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (action == Enumaction.quadrado)
                {
                    initialP = e.GetPosition(null);
                    paintboard.Strokes.Add(NewRectangle(initialP.X, initialP.Y, 0, 0));
                    desenhando = true;
                }
                if (action == Enumaction.circulo)
                {
                    initialP = e.GetPosition(null);
                    paintboard.Strokes.Add(NewCircle(initialP.X, initialP.Y, 0));
                    desenhando = true;

                }
                if (action == Enumaction.linha)
                {
                    initialP = e.GetPosition(null);
                    paintboard.Strokes.Add(NewLine(initialP.X, initialP.Y, initialP.X, initialP.Y));
                    desenhando = true;
                }
                FecharMenu();
            }

        }

        #region metodos desenho

        public void CloseDraw()
        {
            this.Close();
        }

        private Stroke NewLine(double x1, double y1, double x2, double y2)
        {

            StylusPointCollection strokePoints = new StylusPointCollection
            {
                new StylusPoint(x1, y1),
                new StylusPoint(x2, y2)
            };

            Stroke newStroke = new Stroke(strokePoints);

            newStroke.DrawingAttributes.Color = atualcolor;
            newStroke.DrawingAttributes.Width = atualespessura;
            newStroke.DrawingAttributes.Height = atualespessura;

            return newStroke;
        }

        private Stroke NewRectangle(double dLeft, double dTop, double dWidth, double dHeight)
        {
            double T = dTop;
            double L = dLeft;
            double W = dWidth;
            double H = dHeight;

            StylusPointCollection strokePoints = new StylusPointCollection
            {
                new StylusPoint(L, T),
                new StylusPoint(L + W, T),
                new StylusPoint(L + W, T + H),
                new StylusPoint(L, T + H),
                new StylusPoint(L, T)
            };

            Stroke newStroke = new Stroke(strokePoints);

            newStroke.DrawingAttributes.Color = atualcolor;
            newStroke.DrawingAttributes.Width = atualespessura;
            newStroke.DrawingAttributes.Height = atualespessura;

            return newStroke;
        }

        private Stroke NewCircle(double dLeft, double dTop, double dRadius)
        {
            double T = dTop;
            double L = dLeft;
            double R = dRadius;
            StylusPoint point;

            StylusPointCollection strokePoints = new StylusPointCollection();
            for (float i = 0; i < 6.5f; i += 0.1f)
            {
                point = new StylusPoint(L + R * Math.Sin(i), T + R * Math.Cos(i));
                strokePoints.Add(point);
            }
            Stroke newStroke = new Stroke(strokePoints);

            newStroke.DrawingAttributes.Color = atualcolor;
            newStroke.DrawingAttributes.Width = atualespessura;
            newStroke.DrawingAttributes.Height = atualespessura;

            return newStroke;
        }

        private void Ellipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            atualcolor = ((System.Windows.Media.SolidColorBrush)((sender as Ellipse).Fill)).Color;
            Setcolor();
            configwin.Visibility = System.Windows.Visibility.Hidden;
            SelecionarFerramenta(sender as Ellipse);

        }

        Point Calculaposicao(Point posInicial, double angulo, double distancia)
        {
            Point pontoinicial = posInicial;

            double angle = DegreeToRadian(angulo);

            double seno = Math.Sin(angle);
            double cos = Math.Cos(angle);
            double x1 = (distancia * cos);
            double y1 = (distancia * seno);

            Point pontofinal = new Point(pontoinicial.X + x1, pontoinicial.Y + y1);
            return pontofinal;
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private double RadianToDegree(double angle)
        {
            return Math.PI * angle * 180.0;
        }

        class MoveData
        {
            float startX, startY, endX, endY;
            Rectangle moverec;
            float distance;
            float directionX;
            float directionY;
            public bool moveing;

            public MoveData(Rectangle el)
            {
                moverec = el;
                moveing = false;

            }

            public void MoveTo(Point start, Point end)
            {

                startX = (float)start.X;
                startY = (float)start.Y;
                endX = (float)end.X;
                endY = (float)end.Y;

                distance = (float)Math.Sqrt(Math.Pow(endX - startX, 2) + Math.Pow(endY - startY, 2));
                directionX = (endX - startX) / distance;
                directionY = (endY - startY) / distance;

                moverec.Visibility = Visibility.Visible;
                moverec.Margin = new Thickness(startX, startY, 0, 0);
                moveing = true;

            }

            public void Hidden()
            {
                moverec.Visibility = Visibility.Hidden;
            }

            public void Update()
            {
                var x = moverec.Margin.Left + directionX;
                var y = moverec.Margin.Top + directionY;

                moverec.Margin = new Thickness(x, y, 0, 0);

                if (Math.Sqrt(Math.Pow(moverec.Margin.Left - startX, 2) + Math.Pow(moverec.Margin.Top - startY, 2)) >= distance)
                {
                    moverec.Margin = new Thickness(endX, endY, 0, 0);
                    moveing = false;
                }
            }
        }

        List<MoveData> moveElements = new List<MoveData>();
        void T_Tick(object sender, EventArgs e)
        {
            foreach (var item in moveElements)
            {
                if (item.moveing)
                    item.Update();
            }
        }

        void Setcolor()
        {
            atualcolor = Color.FromArgb((byte)atualopacidade, atualcolor.R, atualcolor.G, atualcolor.B);
            paintboard.DefaultDrawingAttributes.Color = atualcolor;
            paintboard.DefaultDrawingAttributes.Width = atualespessura;
            paintboard.DefaultDrawingAttributes.Height = atualespessura;
        }

        void SelecionarFerramenta(Ellipse obj)
        {
            btnAmarelo.Stroke = null;
            btnPreto.Stroke = null;
            btnAzul.Stroke = null;
            btnVerde.Stroke = null;
            btnVermelho.Stroke = null;

            obj.Stroke = Brushes.White;

        }

        private void Ellipse_StylusUp(object sender, StylusEventArgs e)
        {
            Ellipse_MouseLeftButtonUp(sender, null);
        }

        private void Btnplusopacidade_Click(object sender, RoutedEventArgs e)
        {
            Modificarconfig(0, 10);
        }

        private void Btnplusespessura_Click(object sender, RoutedEventArgs e)
        {
            Modificarconfig(1, 10);
        }

        private void Minusopacidade_Click(object sender, RoutedEventArgs e)
        {
            Modificarconfig(0, -10);
        }

        private void Minusespessura_Click(object sender, RoutedEventArgs e)
        {
            Modificarconfig(1, -10);

        }

        void Modificarconfig(int op, int val)
        {
            if (op == 0)
            {
                atualopacidade += atualopacidade + val < 255 && atualopacidade + val > 0 ? val : 0;
            }
            else
            {
                atualespessura += atualespessura + val < 100 && atualespessura + val > 0 ? val : 0;
            }


            Setcolor();

            demoball.Height = atualespessura;
            demoball.Width = atualespessura;
            demoball.Fill = new SolidColorBrush(atualcolor);

        }

        private void Btnplusopacidade_StylusDown(object sender, StylusDownEventArgs e)
        {
            Btnplusopacidade_Click(sender, null);
        }

        private void Minusopacidade_StylusDown(object sender, StylusDownEventArgs e)
        {
            Minusopacidade_Click(sender, null);
        }

        private void Minusespessura_StylusDown(object sender, StylusDownEventArgs e)
        {
            Minusespessura_Click(sender, null);
        }

        private void Btnplusespessura_StylusDown(object sender, StylusDownEventArgs e)
        {
            Btnplusespessura_Click(sender, null);
        }

        void Licenciamento()
        {
            if (!reg.isRegister())
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        #endregion
    }
}
