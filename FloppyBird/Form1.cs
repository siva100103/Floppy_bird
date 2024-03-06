using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloppyBird
{
    public partial class Form1 : Form
    {
        private Point CurrentLocation;
        private Random random;
        private int OptWidth;
        private Timer timer;
        private List<Obstacle> obstacles=new List<Obstacle>();
        private Point PictureBoxLocation;
        private int score = 0;
        private bool will = true;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            HashSet<int> h = new HashSet<int>();
            h.Contains(1);
            CurrentLocation = new Point(200, 0);
            OptWidth = (Width-200) / 12;
            timer = new Timer();
            
            PictureBoxLocation = new Point(10, Height/2);
            DoubleBuffered = true;
            label1.Font = new Font("Arial",15);
            timer.Interval = 25;
            timer.Tick += Checker;
            CreateObst();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            pictureBox1.Location = PictureBoxLocation;
            Graphics g = e.Graphics;
            foreach (var a in obstacles)
            {
                g.FillRectangle(Brushes.Black, a.UpperRect);
                g.FillRectangle(Brushes.Black, a.LowerRect);
            }
            Bitmap bmp = new Bitmap(400, 400);
      
        }

        private void CreateObst()
        {
            while (CurrentLocation.X+OptWidth<Width)
            {
                Obstacle obstacle = new Obstacle
                {
                    TotalHeight = Height,
                    ObstHeight = random.Next(60, Height - 120),
                    ObstWidth = OptWidth,
                    ObstLocation = CurrentLocation
                };
                obstacles.Add(obstacle);
             CurrentLocation.X += (4 * OptWidth);
            }
            CurrentLocation.X = CurrentLocation.X - (4* OptWidth);
        }

        private void Checker(object sender,EventArgs e)
        {
            foreach(var obstacle in obstacles.ToList())
            {
                PictureBoxLocation.Y += 1;
                obstacle.ObstLocation = new Point(obstacle.ObstLocation.X-(OptWidth/30),obstacle.ObstLocation.Y);

                Obstacle ob = obstacles[0];
                if (ob.ObstLocation.X < 0)
                {
                    if (obstacles.Count == 3) CreateObst();
                    if (obstacle.ObstLocation.X < -OptWidth)
                    {
                        obstacles.Remove(obstacle);
                        will = true;
                    }
                }
                int gap = 0;
                if(GameOver(new Point(pictureBox1.Location.X-gap,pictureBox1.Location.Y-gap),ob.UpperRect)||GameOver(new Point(pictureBox1.Location.X+pictureBox1.Width-gap,pictureBox1.Location.Y-gap),ob.UpperRect)||GameOver(new Point(pictureBox1.Location.X,pictureBox1.Location.Y+pictureBox1.Height),ob.UpperRect)||GameOver(new Point(pictureBox1.Location.X + pictureBox1.Width, pictureBox1.Location.Y + pictureBox1.Height),ob.UpperRect)|| GameOver(pictureBox1.Location, ob.LowerRect) || GameOver(new Point(pictureBox1.Location.X + pictureBox1.Width, pictureBox1.Location.Y), ob.LowerRect) || GameOver(new Point(pictureBox1.Location.X, pictureBox1.Location.Y + pictureBox1.Height), ob.LowerRect) || GameOver(new Point(pictureBox1.Location.X + pictureBox1.Width, pictureBox1.Location.Y + pictureBox1.Height), ob.LowerRect))
                {
                    timer.Stop();
                    DialogResult dialog =  MessageBox.Show($"Game Over {score}");
                    if (dialog == DialogResult.OK)
                    {
                        Close();
                    }
                }
                if (pictureBox1.Location.X > ob.ObstLocation.X - (OptWidth / 30)+ob.ObstWidth && will)
                {
                    will = false;
                    score++;
                }
                label1.Text = "Score:" + score.ToString();
                Invalidate();
            }
        }

        private bool GameOver(Point p,Rectangle rect)
        {
           if(((p.X>=rect.X && p.X<=rect.X+rect.Width) && p.Y>=rect.Y && p.Y <= rect.Y + rect.Height) || pictureBox1.Location.Y<=0 ||pictureBox1.Location.Y+pictureBox1.Height>Height)
            {
                if (pictureBox1.Location.Y <= 0) pictureBox1.Location = new Point(pictureBox1.Location.X, 0);
                else if(pictureBox1.Location.Y + pictureBox1.Height > Height) pictureBox1.Location = new Point(pictureBox1.Location.X, Height-pictureBox1.Height);
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(button1);
            timer.Start();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar ==32)
            {
                PictureBoxLocation.Y -= 39;
            }
        }
    }

    class Obstacle
    {
        public int TotalHeight { get; set; }
        public int ObstHeight { get; set; }
        public int ObstWidth { get; set; }
        public Point ObstLocation { get; set; }
        public Rectangle UpperRect { get { return new Rectangle(ObstLocation, new Size(ObstWidth, ObstHeight)); } }
        public Rectangle LowerRect { get { return new Rectangle(ObstLocation.X, ObstLocation.Y + ObstHeight + 80, ObstWidth, TotalHeight - ObstHeight - 80); } }
    }
}
