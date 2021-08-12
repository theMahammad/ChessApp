using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen : Figure
    {

        public override object Clone()
        {
            return MemberwiseClone();
        }
        public Queen(string name, Image bgImg) : base(name, bgImg)
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
           //Fil kimi hərəkət özəlliyi
            if (row + 1 <= buttons.GetUpperBound(0))
            {
                bool stoppedForRightBottom = false;
                bool stoppedForLeftBottom = false;
                int count = 1;

                for (int i = row + 1; i <= buttons.GetUpperBound(0); i++)
                {
                    //Aşağı sola doğru
                    while (column - count >= buttons.GetLowerBound(0) && !stoppedForLeftBottom)
                    {
                        int j = column - count;
                        if (!buttons[i, j].isFull)
                        {
                            availableCoordinates.Add(new Coordinate(i, j));
                        }
                        else
                        {
                            if ((buttons[i, j].Controls[0] as Figure).Team != this.Team)
                            {
                                availableCoordinates.Add(new Coordinate(i, j));
                            }
                            stoppedForLeftBottom = true;
                            break;



                        }
                        break;

                    }
                    //Aşağı sağa doğru
                    while (column + count <= buttons.GetUpperBound(0) && !stoppedForRightBottom)
                    {
                        int j = column + count;
                        if (!buttons[i, j].isFull)
                        {
                            availableCoordinates.Add(new Coordinate(i, j));
                        }
                        else
                        {
                            if ((buttons[i, j].Controls[0] as Figure).Team != this.Team)
                            {
                                availableCoordinates.Add(new Coordinate(i, j));
                            }
                            stoppedForRightBottom = true;
                            break;



                        }
                        break;
                    }
                    count++;

                }
            }
            //Yuxarıya doğru hərəkət
            if (row - 1 >= buttons.GetLowerBound(0))
            {
                bool stoppedForRightTop = false;
                bool stoppedForLeftTop = false;
                int count = 1;

                for (int i = row - 1; i >= buttons.GetLowerBound(0); i--)
                {
                    //Yuxarı sola doğru
                    while (column - count >= buttons.GetLowerBound(1) && !stoppedForLeftTop)
                    {
                        int j = column - count;
                        if (!buttons[i, j].isFull)
                        {
                            availableCoordinates.Add(new Coordinate(i, j));
                        }
                        else
                        {
                            if ((buttons[i, j].Controls[0] as Figure).Team != this.Team)
                            {
                                availableCoordinates.Add(new Coordinate(i, j));
                            }
                            stoppedForLeftTop = true;
                            break;



                        }
                        break;

                    }
                    //Yuxarı sağa doğru
                    while (column + count <= buttons.GetUpperBound(0) && !stoppedForRightTop)
                    {
                        int j = column + count;
                        if (!buttons[i, j].isFull)
                        {
                            availableCoordinates.Add(new Coordinate(i, j));
                        }
                        else
                        {
                            if ((buttons[i, j].Controls[0] as Figure).Team != this.Team)
                            {
                                availableCoordinates.Add(new Coordinate(i, j));
                            }
                            stoppedForRightTop = true;
                            break;



                        }
                        break;
                    }
                    count++;

                }
            }
            //Top kimi hərəkət özəlliyi
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
            if (row <= 6)
            {

                for (int i = row + 1; i <= buttons.GetUpperBound(1); i++)
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
