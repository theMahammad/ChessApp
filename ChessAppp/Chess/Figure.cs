using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Chess
{
    abstract class Figure:Button
    {   public Team Team { get; set; }
        public Image Image { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public abstract List<Coordinate> ShowMoveOptions(int row, int column, Check[,] buttons);
        public abstract void Move(Check button);
        public abstract void CaptureOppositeFigure();
        public abstract void CapturedByOppositeFigure();
        public Figure(string name,Image bgImg)
        {
            this.Name = name;
            this.BackgroundImage = bgImg;
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
