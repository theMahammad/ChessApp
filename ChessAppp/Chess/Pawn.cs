using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    class Pawn : Figure
    { public bool usedAlreadyItsFirstRight { get; set; } = false;
        public bool isSelected { get; set; }= false;
        public Pawn(string name,Image bgImg) : base(name,bgImg)
        {
            
        }

        public override void CapturedByOppositeFigure()
        {
            throw new NotImplementedException();
        }

        public override void CaptureOppositeFigure(Figure attackerFigure, Figure capturedFigure)
        {
            Check check = new();
            Check checkAttacker = new();
            checkAttacker.isFull = false;
            check.Controls.Add(attackerFigure);
            check.Controls.Remove(capturedFigure);

        }

        public override void Move(Check button)
        {
            usedAlreadyItsFirstRight = true;
            (this.Parent as Check).isFull = false;
            button.Controls.Clear();
            
            button.Controls.Add(this);
            button.isFull = true;





        }


        public override List<Coordinate> ShowMoveOptions(int row, int column, Check[,] buttons)
        {
            List<Coordinate> availableCoordinates = new();
            int limit = 0;
            if (usedAlreadyItsFirstRight)
            {
                limit = 1;

            }
            else
            {
                limit = 2;
            }
            if (this.Team == Team.Black)
            {
                if (row == 7)
                {
                    limit = 0;
                }
                //Normal gediş
                for (int i = row + 1; i <= row + limit; i++)
                {
                    if (buttons[i, column].isFull == false)
                    {
                        availableCoordinates.Add(new(i, column));
                    }
                    else
                    {
                        break;
                    }
                }

                //Rəqibin daşını yemək üçün 
                if (row < 7)
                {
                    for (int i = row + 1; i <= row + 1; i++)
                    {

                        int colLimit = column < 7 ? column + 1 : column;
                        for (int j = column > 0 ? column - 1 : column + 1; j <= colLimit; j += 2)
                        {


                            if (buttons[i, j].isFull)
                            {
                                Figure figure = (Figure)buttons[i, j].Controls[0];
                                if (figure.Team != this.Team)
                                {
                                    availableCoordinates.Add(new Coordinate(i, j));
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }
                    }
                }
          



            }

            else
            {
                if (row == 0)
                {
                    limit = 0;
                }
                for (int i = row - 1; i >= row - limit; i--)
                {
                    if (buttons[i, column].isFull == false)
                    {
                        availableCoordinates.Add(new(i, column));

                    }
                    else
                    {
                        break;
                    }
                }
                //Rəqibin daşını yemək üçün 

                if (row > 0)
                {
                    for (int i = row - 1; i >=row - 1; i--)
                    {
                        for (int j = column > 0 ? column - 1 : column+1; j <= (column < 7 ? column + 1 : column); j+=2)
                        {
                            if (buttons[i, j].isFull)
                            {
                                Figure oppositeFigure = (Figure)buttons[i, j].Controls[0];
                                if (oppositeFigure.Team != this.Team)
                                {
                                    availableCoordinates.Add(new Coordinate(i, j));
                                }
                            }
                        }
                    }

                }

               
            }
            return availableCoordinates;
        }
        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}
