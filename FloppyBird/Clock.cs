using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloppyBird
{
    public partial class Clock : UserControl
    {
        public Timer timer=new Timer();

       // public event EventHandler<DateTime> getTime;

        public Clock()
        {
            InitializeComponent();
            timer.Interval = 1000;
            DoubleBuffered = true;
            timer.Tick += tick;
            timer.Start();
        }

        private void tick(object sender,EventArgs e)
        {
          //  getTime.Invoke(this, DateTime.Now);
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int SemiMajorAxis = Width - 3;
            int SemiMinorAxis = Height - 3;
            Rectangle rec = new Rectangle(0, 0, SemiMajorAxis, SemiMinorAxis);
            g.DrawEllipse(new Pen(Brushes.Black, 3), rec);
            int centerX = rec.Width / 2 - 10;
            int centerY =  rec.Height / 2-10;

            for (int i = 1; i <= 12; i++)
            {
                double angle = 30 ;
                float x = (float)(centerX + (SemiMajorAxis / 2.25f) * Math.Cos(((i*angle)-90) * Math.PI /180));
                float y = (float)(centerY + (SemiMinorAxis / 2.25f )* Math.Sin(((i * angle)-90)* Math.PI / 180));
                PointF textPosition = new PointF(x, y);
                g.DrawString(i.ToString(), new Font("Arial", Height/14.285F), Brushes.Black, textPosition);
                DateTime now = DateTime.Now;
                DrawClockHand(g, centerX, centerY, (SemiMajorAxis/2)*0.5, now.Hour * 30 + now.Minute * 0.5, Pens.Black, 6); // Hour hand
                DrawClockHand(g, centerX, centerY, (SemiMajorAxis/2)*0.7, now.Minute * 6, Pens.Black, 4); // Minute hand
                DrawClockHand(g, centerX, centerY, (SemiMajorAxis/2)*0.75, now.Second * 6, Pens.Red, 2); // Second hand
                
            }
        }
        private void DrawClockHand(Graphics g, int centerX, int centerY, double length, double angleDegrees, Pen pen, float thickness)
        {
            
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            double angleRadians = angleDegrees * Math.PI / 180;
            int x = (int)(centerX + length * Math.Sin(angleRadians));
            int y = (int)(centerY - length * Math.Cos(angleRadians));
            g.DrawLine(new Pen(pen.Color, thickness), centerX, centerY, x, y);
            
        }
    }
}
