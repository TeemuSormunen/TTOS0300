using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace snake
{
    /// <summary>
    /// The classic old Snake game in WPF
    /// </summary>
    /// 
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
    public partial class Game : Window
    {
        // Variables and consts
        private const int minimi = 5;
        private const int maxHeight = 380;
        private const int maxWidth = 620;
        private int snakeWidth = 10;
        private int snakeLength = 100;
        private int easiness = 20; //timerin ajastin aika ms
        private int score = 0;
        private List<Point> bonusPoints = new List<Point>(); // omena kokoelma
        private const int bonusCount = 50;
        private List<Point> snakeParts = new List<Point>();
        private Point startingPoint = new Point(100, 100);
        private Point currentPosition = new Point();
        private Direction lastDirection = Direction.Right;
        private Direction currentDirection = Direction.Right;
        private Random rnd = new Random(); //pisteiden arvontaa varten
        private DispatcherTimer timer;
        public Game()
        {
            InitializeComponent();
            // tarvittavat alustukset
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
            timer.Tick += new EventHandler(timer_Tick);
            //Määritetään ikkunalle tapahtumakäsittelijä näppäimistön kuuntelua varten
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            //piirretään omenat ja käärme
            IniBonusPoints();
            PaintSnake(startingPoint);
            currentPosition = startingPoint;

            //start game
            timer.Start();
        }

        private void IniBonusPoints()
        {
            for (int n = 0; n < bonusCount; n++)
            {
                PaintBonus(n);
            }

        }
        private void PaintBonus(int index)
        {//arvotaan omenalle piste eli X ja Y koordinaatti
            Point point = new Point(rnd.Next(minimi, maxWidth),rnd.Next(minimi, maxHeight));
            //omenan piirto
            Ellipse omena = new Ellipse();
            omena.Fill = Brushes.Red;
            omena.Width = snakeWidth;
            omena.Height = snakeWidth;
            Canvas.SetTop(omena, point.Y);
            Canvas.SetLeft(omena, point.X);
            paintCanvas.Children.Insert(index, omena);
            bonusPoints.Insert(index, point);
        }
        private void PaintSnake(Point currentPoint)
        {
            Ellipse snake = new Ellipse();
            snake.Fill = Brushes.Green;
            snake.Width = snakeWidth;
            snake.Height = snakeWidth;
            Canvas.SetTop(snake, currentPoint.Y);
            Canvas.SetLeft(snake, currentPoint.X);
            int count = paintCanvas.Children.Count;
            paintCanvas.Children.Add(snake);
            snakeParts.Add(currentPosition);
            //rajoitetaan käärmeen pituutta
            if (count > snakeLength)
            {
                paintCanvas.Children.RemoveAt(count - snakeLength + (bonusCount - 1));
                snakeParts.RemoveAt(count - snakeLength);
            }
            //TODO

        }
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            //Muutetaan suuntaa näppäimistön painalluksen mukaan
            //mutta ei sallita 180asteen käännöstä
            switch (e.Key)
            {
                case Key.Escape:
                    if (timer.IsEnabled)
                       
                    GameOver();
                    break;
         
                case Key.Left:
                    if (lastDirection != Direction.Right)
                        currentDirection = Direction.Left;
                    break;
                case Key.Up:
                    if (lastDirection != Direction.Down)
                        currentDirection = Direction.Up;
                    break;
                case Key.Right:
                    if (lastDirection != Direction.Left)
                        currentDirection = Direction.Right; 
                    break;
                case Key.Down:
                    if (lastDirection != Direction.Up)
                        currentDirection = Direction.Down;
                    break;
               
                case Key.P:
                    if (timer.IsEnabled)
                        timer.Stop();
                    else
                        timer.Start();
                    break;
               
 
   
                default:
                    break;
            }
            lastDirection = currentDirection;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    currentPosition.Y -= 3;
                    break;
                case Direction.Right:
                    currentPosition.X += 3;
                    break;
                case Direction.Down:
                    currentPosition.Y += 3;
                    break;
                case Direction.Left:
                    currentPosition.X -= 3;
                    break;
                default:
                    break;
            }
            PaintSnake(currentPosition);
            //törmäys tarkastelut 1-3
            //TT#1 tarkastetaan onko canvaasilla
            if ((currentPosition.X > maxWidth) || (currentPosition.X < minimi) || (currentPosition.Y > maxHeight) || (currentPosition.Y < minimi))
                GameOver();

            //TT#2 tarkistetaan ettei pure omaa häntäänsä
            for (int i = 0; i < snakeParts.Count - snakeWidth * 2; i++)
            {
                Point p = new Point(snakeParts[i].X, snakeParts[i].Y);
                if ((Math.Abs(p.X - currentPosition.X) < snakeWidth) && (Math.Abs(p.Y - currentPosition.Y) < snakeWidth))
                    GameOver();
            }


            //TT#3 tarkastetaan osuuko omenaan

            int n = 0;
            foreach (Point point in bonusPoints)
            {
                if ((Math.Abs(point.X - currentPosition.X) < snakeWidth) &&
                    (Math.Abs(point.Y - currentPosition.Y) < snakeWidth))
                {
                    //syödään omena
                    score += 10;
                    snakeLength += 10;
                    //nopeutetaan peliä
                    if (easiness > 5)
                        easiness--;
                    timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
                    this.Title = "SnakeWPF your score: " + score;
                    bonusPoints.RemoveAt(n);
                    paintCanvas.Children.RemoveAt(n);
                    PaintBonus(n);
                    break;
                }
                n++;
                
            }
        }
        private void GameOver()
        {
            timer.Stop();
            MessageBox.Show("Your score: " + score);
            //this.Close();
            GameOverShow();
        }
        private void GameOverShow()
        {
            txtMessage.Text = "Your score:" + score + "\n press Esc to quit";
            paintCanvas.Children.Add(txtMessage);
            //animaatio joka siirtää kanvaasin
            var trs = new TranslateTransform();
            var anim = new DoubleAnimation(0, 620, TimeSpan.FromSeconds(15));
            trs.BeginAnimation(TranslateTransform.XProperty, anim);
            trs.BeginAnimation(TranslateTransform.YProperty, anim);
            paintCanvas.RenderTransform = trs;
        }


    }
}
