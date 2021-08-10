using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Rook : Figure
    {
        public override object Clone()
        {
            return MemberwiseClone();
        }

        public Rook(string name, Image bgImg) : base(name, bgImg)
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
            (button as Check).isFull = true;

        }

        public override List<Coordinate> ShowMoveOptions(int row, int column, Check[,] buttons)
        {

            List<Coordinate> availableCoordinates = new();
            //Sağa doğru
            if (column <= 6)
            {
                for (int i = column + 1; i <= buttons.GetUpperBound(1); i++)
                {
                    if (buttons[row, i].isFull == false)
                    {

                        availableCoordinates.Add(new Coordinate(row, i));
                    }
                    else if (buttons[row, i].isFull == true)
                    {
                        if ((buttons[row, i].Controls[0] as Figure).Team != this.Team)
                        {
                            availableCoordinates.Add(new Coordinate(row, i));

                        }
                        break;
                    }
                }

            }


            if (row > 0)
            {
                for (int i = row - 1; i >= buttons.GetLowerBound(0); i--)
                {
                    if (buttons[i, column].isFull == false)
                    {
                        availableCoordinates.Add(new Coordinate(i, column));
                    }
                    else if (buttons[i, column].isFull)
                    {
                        if ((buttons[i, column].Controls[0] as Figure).Team != this.Team)
                        {
                            availableCoordinates.Add(new Coordinate(i, column));

                        }
                        break;
                    }
                    //Sola doğru

                }
            }
            //Yuxarıya
            
            if (column > 0)
            {
                for (int i = column - 1; i >= buttons.GetLowerBound(1); i--)
                {
                    if (buttons[row, i].isFull == false)
                    {

                        availableCoordinates.Add(new Coordinate(row, i));
                    }
                    else if (buttons[row, i].isFull == true)
                    {
                        if ((buttons[row, i].Controls[0] as Figure).Team != this.Team)
                        {
                            availableCoordinates.Add(new Coordinate(row, i));

                        }
                        break;
                    }
                }
            }
            //Aşağıya doğru
            if (row <= 6) {
            
                for(int i = row + 1; i <= buttons.GetUpperBound(1); i++)
                {
                    if (buttons[i, column].isFull == false)
                    {
                        availableCoordinates.Add(new Coordinate(i, column));
                    }
                    else if (buttons[i, column].isFull)
                    {
                        if ((buttons[i, column].Controls[0] as Figure).Team != this.Team)
                        {
                            availableCoordinates.Add(new Coordinate(i, column));

                        }
                        break;
                    }

                }


            }
            
            return availableCoordinates;
        }
    }
}
