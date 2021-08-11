using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Chess
{
    abstract class Figure:Button,ICloneable
    {   public Team Team { get; set; }
        public  bool IsCaptured { get; protected set; } 
        public  new Image Image { get; set; }
        public string Color { get; set; }
        public new string Name { get; set; }
        public abstract List<Coordinate> ShowMoveOptions(int row, int column, Check[,] buttons);
        public new abstract void Move(Check button);
        public abstract void CaptureOppositeFigure(Figure attackerFigure,Figure capturedFigure);
        public abstract void CapturedByOppositeFigure();



        public abstract object Clone();

        public Figure(string name,Image bgImg)
        {
            this.Name = name;
            this.BackgroundImage = bgImg;
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
