using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloppyBird
{
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
