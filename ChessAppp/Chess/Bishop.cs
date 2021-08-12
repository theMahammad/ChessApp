using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : Figure
    {
        
        public Bishop(string name, Image bgImg) : base(name, bgImg)
        {
        }

        public override void CapturedByOppositeFigure()
        {
            throw new NotImplementedException();
        }

        public override void CaptureOppositeFigure(Figure attackerFigure, Figure capturedFigure)
        {
            
        }

        public override object Clone()
        {
            return MemberwiseClone();
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
            //Aşağıya doğru hərəkət
        if(row + 1 <= buttons.GetUpperBound(0))
            {
                bool stoppedForRightBottom = false ;
                bool stoppedForLeftBottom = false;
                int count = 1;
                
                for (int i = row+1; i <= buttons.GetUpperBound(0); i++)
                {
                    //Aşağı sola doğru
                    while (column - count>=buttons.GetLowerBound(0) && !stoppedForLeftBottom)
                    {
                        int j = column - count;
                        if (!buttons[i, j].isFull)
                        {
                            availableCoordinates.Add(new Coordinate(i, j));
                        }
                        else
                        {
                            if((buttons[i,j].Controls[0] as Figure).Team != this.Team)
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
            return availableCoordinates;
           
        }
    }
}
