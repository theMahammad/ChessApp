using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.pnl_chess_arena.Anchor = System.Windows.Forms.AnchorStyles.None;
            Array.ForEach(blackFigures, figure => figure.Team = Team.Black);
            Array.ForEach(whiteFigures, figure => figure.Team = Team.White);



        }
        Check[,] buttons = new Check[8, 8];
        static Image blackBishop = Bitmap.FromFile(@"PNG\Black_TheBishop.png");
        static Image blackRook = Bitmap.FromFile(@"PNG\Black_TheRook.png");
        static Image blackKnight = Bitmap.FromFile(@"PNG\Black_TheKnight.png");
        static Image blackPawn = Bitmap.FromFile(@"PNG\Black_ThePawn.png");
        static Image blackQueen = Bitmap.FromFile(@"PNG\Black_TheQueen.png");
        static Image blackKing = Bitmap.FromFile(@"PNG\Black_TheKing.png");

        
        Figure[] blackFigures = new Figure[] { new Rook("Top1", blackRook), new Knight("At1", blackKnight), new Bishop("Fil1", blackBishop), new Queen("Vəzir", blackQueen), new King("Şah", blackKing), new Bishop("Fil2", blackBishop), new Knight("At2", blackKnight), new Rook("Top2", blackRook), new Pawn("Piyada1", blackPawn), new Pawn("Piyada2", blackPawn), new Pawn("Piyada3", blackPawn), new Pawn("Piyada4", blackPawn), new Pawn("Piyada5", blackPawn), new Pawn("Piyada6", blackPawn), new Pawn("Piyada7", blackPawn), new Pawn("Piyada8", blackPawn) };

        static Image whiteBishop = Bitmap.FromFile(@"PNG\White_TheBishop.png");
        static Image whiteRook = Bitmap.FromFile(@"PNG\White_TheRook.png");
        static Image whiteKnight = Bitmap.FromFile(@"PNG\White_TheKnight.png");
        static Image whitePawn = Bitmap.FromFile(@"PNG\White_ThePawn.png");
        static Image whiteQueen = Bitmap.FromFile(@"PNG\White_TheQueen.png");
        static Image whiteKing = Bitmap.FromFile(@"PNG\White_TheKing.png");
        Figure focusedFigure = null;

        Figure[] whiteFigures = new Figure[] { new Rook("Top1", whiteRook), new Knight("At1", whiteKnight), new Bishop("Fil1", whiteBishop), new Queen("Vəzir", whiteQueen), new King("Şah", whiteKing), new Bishop("Fil2", whiteBishop), new Knight("At2", whiteKnight), new Rook("Top2", whiteRook), new Pawn("Piyada1", whitePawn), new Pawn("Piyada2", whitePawn), new Pawn("Piyada3", whitePawn), new Pawn("Piyada4", whitePawn), new Pawn("Piyada5", whitePawn), new Pawn("Piyada6", whitePawn), new Pawn("Piyada7", whitePawn), new Pawn("Piyada8", whitePawn) };

        List<Coordinate> indexesLastArea = new();
        void setBlackFigureLocations()
        {
            int count = 0;
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                {
                    blackFigures[count].Height = buttons[i, j].Height;
                    blackFigures[count].Width = buttons[i, j].Width;
                    blackFigures[count].FlatAppearance.BorderSize = 0;


                    buttons[i, j].Controls.Add(blackFigures[count]);
                    buttons[i, j].isFull = true;

                    count++;
                }
            }
        }
       
        void SetWhiteFigureLocations()
        {
            int count = 0;
            for (int i = buttons.GetUpperBound(0); i > buttons.GetUpperBound(0) - 2; i--)
            {
                for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                {
                    whiteFigures[count].Height = buttons[i, j].Height;
                    whiteFigures[count].Width = buttons[i, j].Width;
                    whiteFigures[count].FlatAppearance.BorderSize = 0;


                    buttons[i, j].Controls.Add(whiteFigures[count]);
                    buttons[i, j].isFull = true;
                    count++;
                }
            }
        }
        void setButtonLocation()
        {
            pnl_chess_arena.Controls.Clear();
            pnl_chess_arena.Location = new Point(
            this.ClientSize.Width / 2 - pnl_chess_arena.Size.Width / 2,
            this.ClientSize.Height / 2 - pnl_chess_arena.Size.Height / 2);

            int top = 0;
            int left = 0;
            int heightOfArena = pnl_chess_arena.Height;
            int widthOfArena = pnl_chess_arena.Width;
            for (int row = 0; row <= buttons.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= buttons.GetUpperBound(1); col++)
                {
                    Check button = new Check();

                    button.Height = Convert.ToInt32(heightOfArena / 8);
                    button.Width = Convert.ToInt32(widthOfArena / 8);
                    button.Top = top;
                    button.Left = left;
                    left += 55;
                    buttons[row, col] = button;
                    pnl_chess_arena.Controls.Add(button);
                    if ((row + col) % 2 == 1)
                    {
                        button.BackColor = Color.Black;

                    }

                }
                left = 0;
                top += 50;

            }

        }
        void setDisabledOthers(List<Coordinate> coordinates)
        {
           for(int i = 0; i<coordinates.Count; i++)
            {
                int row = coordinates[i].Row;
                int column = coordinates[i].Column;
                for (int ii = 0; ii <= buttons.GetUpperBound(0); ii++)
                {
                    for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                    {
                        if (buttons[ii, j] != buttons[row, column] && buttons[ii, j].isFull == false && buttons[ii,j].BackColor!=Color.GreenYellow)
                        {
                            buttons[ii, j].Enabled = false;     
                        }
                    }
                }

            }
        }

        List<int> getCheckIndexes(Control button)
        {
            List<int> indexes = new();
            for (int row = 0; row <= buttons.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= buttons.GetUpperBound(1); column++)
                {
                    if (buttons[row, column] == button)
                    {
                        indexes.Add(row);
                        indexes.Add(column);
                    }
                }
            }
            return indexes;
        }
        public void SetToDefaultColor()
        {
            for (int row = 0; row <= buttons.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= buttons.GetUpperBound(1); col++)
                {
                    if ((row + col) % 2 == 1)
                    {
                        buttons[row, col].BackColor = Color.Black;

                    }
                    else
                    {
                        buttons[row, col].BackColor = Color.White;
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            setButtonLocation();
            setBlackFigureLocations();
            SetWhiteFigureLocations();
            foreach (Figure figure in blackFigures)
            {
                if (figure is Pawn)
                {
                    figure.GotFocus += (s, e) =>
                    {
                        Pawn pawnFigure = (Pawn)figure;


                        List<int> indexes = getCheckIndexes(pawnFigure.Parent);
                        List<Coordinate> coordinates = pawnFigure.ShowMoveOptions(indexes[0], indexes[1], buttons);
                        focusedFigure = pawnFigure;
                        
                        for (int i = 0; i < coordinates.Count; i++)
                        {
                            int row = coordinates[i].Row;
                            int column = coordinates[i].Column;
                            buttons[row, column].BackColor = Color.GreenYellow;
                            setDisabledOthers(coordinates);
                            buttons[row, column].Enabled = true;
                            if (buttons[row, column].Controls.Count > 0) {
                                if((buttons[row,column].Controls[0] as Figure).Team != figure.Team)
                                {
                                    buttons[row, column].Controls[0].Hide();
                                }
                                }
                            buttons[row, column].Click += (s, e) =>
                            {
                                MessageBox.Show(focusedFigure.GetType().ToString());
                                figure.Move(buttons[row, column]);
                                
                                
                            };
                            
                            

                           
                        };


                    };






                };
                figure.LostFocus += (s, e) =>
                {
                    SetToDefaultColor();
                   


                };
            }

        }
    


        
       

        private void Form1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

            pnl_chess_arena.Top = Convert.ToInt32(this.Height * 0.4);
            pnl_chess_arena.Left = Convert.ToInt32(this.Width * 0.4);
            setButtonLocation();
            setBlackFigureLocations();
            SetWhiteFigureLocations();



        }
    }
}
