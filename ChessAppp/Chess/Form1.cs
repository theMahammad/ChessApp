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

        }
        Check[,] buttons = new Check[8, 8];
        static Image blackBishop = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\Black_TheBishop.png");
        static Image blackRook = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\Black_TheRook.png");
        static Image blackKnight = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\Black_TheKnight.png");
        static Image blackPawn = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\Black_ThePawn.png");
        static Image blackQueen = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\Black_TheQueen.png");
        static Image blackKing = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\Black_TheKing.png");


        Figure[] blackFigures = new Figure[] { new Rook("Top1", blackRook), new Knight("At1", blackKnight), new Bishop("Fil1", blackBishop), new Queen("Vəzir", blackQueen), new King("Şah", blackKing), new Bishop("Fil2", blackBishop), new Knight("At2", blackKnight), new Rook("Top2", blackRook), new Pawn("Piyada1", blackPawn), new Pawn("Piyada2", blackPawn), new Pawn("Piyada3", blackPawn), new Pawn("Piyada4", blackPawn), new Pawn("Piyada5", blackPawn), new Pawn("Piyada6", blackPawn), new Pawn("Piyada7", blackPawn), new Pawn("Piyada8", blackPawn) };
        static Image whiteBishop = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\White_TheBishop.png");
        static Image whiteRook = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\White_TheRook.png");
        static Image whiteKnight = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\White_TheKnight.png");
        static Image whitePawn = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\White_ThePawn.png");
        static Image whiteQueen = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\White_TheQueen.png");
        static Image whiteKing = Bitmap.FromFile(@"C:\Users\hssjx\OneDrive\Masaüstü\PNG\White_TheKing.png");


        Figure[] whiteFigures = new Figure[] { new Rook("Top1", whiteRook), new Knight("At1", whiteKnight), new Bishop("Fil1", whiteBishop), new Queen("Vəzir", whiteQueen), new King("Şah", whiteKing), new Bishop("Fil2", whiteBishop), new Knight("At2", whiteKnight), new Rook("Top2", whiteRook), new Pawn("Piyada1", whitePawn), new Pawn("Piyada2", whitePawn), new Pawn("Piyada3", whitePawn), new Pawn("Piyada4", whitePawn), new Pawn("Piyada5", whitePawn), new Pawn("Piyada6", whitePawn), new Pawn("Piyada7", whitePawn), new Pawn("Piyada8", whitePawn) };


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



        private void Form1_Load(object sender, EventArgs e)
        {

            setButtonLocation();
            setBlackFigureLocations();
            SetWhiteFigureLocations();

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
