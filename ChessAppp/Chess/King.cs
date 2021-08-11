using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class King : Figure
    {


        public King(string name, Image bgImg) : base(name, bgImg)
        {
        }

        public override void CapturedByOppositeFigure()
        {
            throw new NotImplementedException();
        }

        public override void CaptureOppositeFigure()
        {
            throw new NotImplementedException();
        }


        public override void Move(Check button)
        {
            (this.Parent as Check).isFull = false;
            button.Controls.Add(this);
            button.isFull = true;
        }
        public override object Clone()
        {
            return MemberwiseClone();
        }

        public override List<Coordinate> ShowMoveOptions(int row, int column, Check[,] buttons)
        {
            List<Coordinate> availableCoordinates = new();
            for(int i = (row - 1 >= buttons.GetLowerBound(0) ? row - 1 : row); i <= (row + 1 <= buttons.GetUpperBound(0) ? row + 1 : row); i++)
            {
                for(int j = (column-1>=buttons.GetLowerBound(1)?column-1:column); j <= (column + 1 <= buttons.GetUpperBound(1) ? column + 1 : column); j++)
                {
                    if (i == row && j == column)
                    {
                        continue;
                    }
                    else if (!buttons[i, j].isFull)
                    {
                        availableCoordinates.Add(new Coordinate(i, j));
                    }
                    else
                    {
                        if ((buttons[i, j].Controls[0] as Figure).Team != this.Team)
                        {
                            availableCoordinates.Add(new Coordinate(i, j));
                        }
                    }
                }
            }
            return availableCoordinates;
        }
    }
}
