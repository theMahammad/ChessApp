using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Knight : Figure
    {

        public override object Clone()
        {
            return MemberwiseClone();
        }
        public Knight(string name, Image bgImg) : base(name, bgImg)
        {
        }

        public override void CapturedByOppositeFigure()
        {
            throw new NotImplementedException();
        }

        public override void CaptureOppositeFigure(Figure attackerFigure, Figure capturedFigure)
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
            //Aşağı doğru hərəkət
            if (row + 1 <= buttons.GetUpperBound(0))
            {
                for (int i =(row+2<=buttons.GetUpperBound(0)?row+2:row+1) ; i >= row + 1; i--)
                {
                    if (i == row + 2)
                    {
                        for (int j = (column - 1 >= buttons.GetLowerBound(1) ? column - 1 : column + 1); j <= (column + 1 <= buttons.GetUpperBound(1) ? column + 1 : column); j += 2)
                        {
                            if (buttons[i, j].isFull)
                            {
                                if ((buttons[i, j].Controls[0] as Figure).Team != this.Team)
                                {
                                    availableCoordinates.Add(new Coordinate(i, j));
                                }
                            }
                            else
                            {
                                availableCoordinates.Add(new Coordinate(i, j));
                            }
                        }
                    }
                    else if (i == row + 1)
                    {

                        for (int j = (column - 2 >= buttons.GetLowerBound(1) ? column - 2 : column + 2); j <= (column + 2 <= buttons.GetUpperBound(0) ? column + 2 : column); j += 4)
                        {
                            if (buttons[i, j].isFull)
                            {
                                if ((buttons[i, j].Controls[0] as Figure).Team != this.Team)
                                {
                                    availableCoordinates.Add(new Coordinate(i, j));
                                }
                            }
                            else
                            {
                                availableCoordinates.Add(new Coordinate(i, j));
                            }
                        }


                    }

                }
            }
             if (row - 1 >= buttons.GetLowerBound(0))
            {
                for (int i = (row - 2 >= buttons.GetLowerBound(0) ? row - 2 : row - 1); i<= row - 1; i++)
                {
                    if (i == row - 2)
                    {
                        for (int j = (column - 1 >= buttons.GetLowerBound(1) ? column - 1 : column + 1); j <= (column + 1 <= buttons.GetUpperBound(1) ? column + 1 : column); j += 2)
                        {
                            if (buttons[i, j].isFull)
                            {
                                if ((buttons[i, j].Controls[0] as Figure).Team != this.Team)
                                {
                                    availableCoordinates.Add(new Coordinate(i, j));
                                }
                            }
                            else
                            {
                                availableCoordinates.Add(new Coordinate(i, j));
                            }
                        }
                    }
                    else if (i == row - 1)
                    {

                        for (int j = (column - 2 >= buttons.GetLowerBound(1) ? column - 2 : column + 2); j <= (column + 2 <= buttons.GetUpperBound(0) ? column + 2 : column); j += 4)
                        {
                            if (buttons[i, j].isFull)
                            {
                                if ((buttons[i, j].Controls[0] as Figure).Team != this.Team)
                                {
                                    availableCoordinates.Add(new Coordinate(i, j));
                                }
                            }
                            else
                            {
                                availableCoordinates.Add(new Coordinate(i, j));
                            }
                        }


                    }

                }
            }
           
            return availableCoordinates;
        }
    }
}
