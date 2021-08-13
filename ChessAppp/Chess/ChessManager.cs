using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessManager
    {
        public static void Move(Figure figure,Check check)
        {
            if(figure is Pawn)
            {if((figure as Pawn).usedAlreadyItsFirstRight==false)
                (figure as Pawn).usedAlreadyItsFirstRight = true;
            }
            else if(figure is Rook)
            {
                if ((figure as Rook).Moved == false)
                    (figure as Rook).Moved = true;
            }
            
            (figure.Parent as Check).isFull = false;
            if (check.Controls.Count > 0)
            { Figure figureInThisCheck = (check.Controls[0] as Figure);
                if (figureInThisCheck.Team!=figure.Team)
                {
                    figureInThisCheck.IsCaptured = true;
                    check.Controls.Remove(figureInThisCheck);
                }
            }
         
                check.Controls.Add(figure);
                check.isFull = true;

            }

        }
        
    }

