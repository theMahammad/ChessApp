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
    public partial class ChessArena : Form
    {
        public ChessArena()
        {
            InitializeComponent();
            this.pnl_chess_arena.Anchor = AnchorStyles.None;
            Array.ForEach(blackFigures, figure => figure.Team = Team.Black);
            Array.ForEach(whiteFigures, figure => figure.Team = Team.White);



        }
        public static bool KingInDeep = false;
        Team CurrentSequence = Team.White;
        static Check[,] buttons = new Check[8, 8];
        static readonly Image blackBishop = Bitmap.FromFile(@"PNG\Black_TheBishop.png");
        static readonly Image blackRook = Bitmap.FromFile(@"PNG\Black_TheRook.png");
        static readonly Image blackKnight = Bitmap.FromFile(@"PNG\Black_TheKnight.png");
        static readonly Image blackPawn = Bitmap.FromFile(@"PNG\Black_ThePawn.png");
        static readonly Image blackQueen = Bitmap.FromFile(@"PNG\Black_TheQueen.png");
        static readonly Image blackKing = Bitmap.FromFile(@"PNG\Black_TheKing.png");


        Figure[] blackFigures = new Figure[] { new Rook("Top1", blackRook), new Knight("At1", blackKnight), new Bishop("Fil1", blackBishop), new Queen("Vəzir", blackQueen), new King("Şah", blackKing), new Bishop("Fil2", blackBishop), new Knight("At2", blackKnight), new Rook("Top2", blackRook), new Pawn("Piyada1", blackPawn), new Pawn("Piyada2", blackPawn), new Pawn("Piyada3", blackPawn), new Pawn("Piyada4", blackPawn), new Pawn("Piyada5", blackPawn), new Pawn("Piyada6", blackPawn), new Pawn("Piyada7", blackPawn), new Pawn("Piyada8", blackPawn) };

        static readonly Image whiteBishop = Bitmap.FromFile(@"PNG\White_TheBishop.png");
        static readonly Image whiteRook = Bitmap.FromFile(@"PNG\White_TheRook.png");
        static readonly Image whiteKnight = Bitmap.FromFile(@"PNG\White_TheKnight.png");
        static readonly Image whitePawn = Bitmap.FromFile(@"PNG\White_ThePawn.png");
        static readonly Image whiteQueen = Bitmap.FromFile(@"PNG\White_TheQueen.png");
        static readonly Image whiteKing = Bitmap.FromFile(@"PNG\White_TheKing.png");
        Figure focusedFigure = null;

        Figure[] whiteFigures = new Figure[] { new Rook("Top1", whiteRook), new Knight("At1", whiteKnight), new Bishop("Fil1", whiteBishop), new Queen("Vəzir", whiteQueen), new King("Şah", whiteKing), new Bishop("Fil2", whiteBishop), new Knight("At2", whiteKnight), new Rook("Top2", whiteRook), new Pawn("Piyada1", whitePawn), new Pawn("Piyada2", whitePawn), new Pawn("Piyada3", whitePawn), new Pawn("Piyada4", whitePawn), new Pawn("Piyada5", whitePawn), new Pawn("Piyada6", whitePawn), new Pawn("Piyada7", whitePawn), new Pawn("Piyada8", whitePawn) };

        List<Coordinate> indexesLastArea = new();
        List<Figure> capturedBlackFigures = new();
        List<Figure> capturedWhiteFigures = new();
        internal static bool CheckMateChance(int row,int column,Figure figure,Check[,] buttons)
        {
            List < Coordinate > availableCoordinates = figure.ShowMoveOptions(row, column, buttons); ;
            foreach(Coordinate coordinate in availableCoordinates) {
                Check button = buttons[coordinate.Row, coordinate.Column];
                if (button.Controls.Count > 0)
                {
                    if(button.Controls[0] is King)
                    {
                        (button.Controls[0] as King).InDeep = true;
                        return true;

                    }
                }
            }
            
            

            return false;
        }
        HashSet<Figure> availableFiguresForMoving = new();
        HashSet<Figure> attackersFigure = new();
        bool SaveKingFromOppositeChance(Figure attackerFigure, int row, int column, Check[,] buttons)
        {
            bool saveChance = false;
            List<Coordinate> availableCoordinates = attackerFigure.ShowMoveOptions(row, column, buttons);
            List<int> indexesOfAttackerFigureCheck = getCheckIndexes(attackerFigure.Parent);
            Dictionary<Figure, List<Coordinate>> allAvailableFigureCoordinates = new();
           

                foreach (Figure figure in (attackerFigure.Team is Team.White?blackFigures:whiteFigures))
                {
                    if (figure.IsCaptured)
                    {
                        continue;
                    }
                    List<int> indexes = getCheckIndexes(figure.Parent);
                    List<Coordinate> availableCoordinatesForThisFigure = figure.ShowMoveOptions(indexes[0], indexes[1], buttons);
                    allAvailableFigureCoordinates.Add(figure, availableCoordinatesForThisFigure);

                }


            

           
              

              
            
            foreach (Figure figure in allAvailableFigureCoordinates.Keys)
            {
                foreach (Coordinate coordinate in allAvailableFigureCoordinates[figure])
                {
                    if (coordinate.Row == indexesOfAttackerFigureCheck[0] && coordinate.Column == indexesOfAttackerFigureCheck[1])
                    {
                        saveChance = true;
                        availableFiguresForMoving.Add(figure);
                    }
                }
            }




            return saveChance;

        }
    
        
        
        void SetBlackFigureLocations()
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
       void SetLocationByItsTeam(Figure capturedFigure)
        {
            if (capturedFigure.Team == Team.Black)
            {
                capturedBlackFigures.Add(capturedFigure);
                
            }
            else
            {
                capturedWhiteFigures.Add(capturedFigure);
            }
            capturedFigure.Enabled=false;
            RefreshOutsideOfPanel();
                
                
           
        }
        void RefreshOutsideOfPanel()
        {
            int black_top = 0;
            int black_left = 0;
            int white_top = 0;
            int white_left = pnl_chess_arena.Right;
            foreach (Figure figure in capturedBlackFigures)
            {
                
                figure.Top = black_top;
                figure.Left =black_left ;
                black_left += 55;
                this.Controls.Add(figure);
                if (black_left > 110) {

                    black_top += 55;
                    black_left = 0;

                        }
                
            }
            foreach(Figure figure in capturedWhiteFigures)
            {
                figure.Top = white_top;
                figure.Left = white_left;
                white_left += 55;
                this.Controls.Add(figure);
                if (white_left > pnl_chess_arena.Right+110)
                {

                    white_top+= 55;
                    white_left = pnl_chess_arena.Right;

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
        bool IsThisCheckAvailableForSelectedFigure(Check button,List<Coordinate> availableCoordinates)
        {
            if(availableCoordinates is not null)
            {
                foreach (Coordinate element in availableCoordinates)
                {
                    if (buttons[element.Row, element.Column] == button)
                    {
                        return true;

                    }
                }
            }
            
            return false;
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
        List<Coordinate> availableCoordinates = null;
        public static List<int> getCheckIndexes(Control button)
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
                        break;
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
            SetBlackFigureLocations();
            SetWhiteFigureLocations();
            foreach (Figure figure in blackFigures.Concat(whiteFigures))
            {
                
                    figure.Click += (s, e) =>
                    {
                       
                        if (focusedFigure is  null || focusedFigure.Team == figure.Team)
                        {
                            SetToDefaultColor();

                            focusedFigure = figure;
                            lbl_focusedFigure.Text = focusedFigure.Team.ToString()+" "+focusedFigure.Name.ToString();

                            if (focusedFigure.Team == CurrentSequence)
                            {
                                if (KingInDeep)
                                {
                                    if(availableFiguresForMoving.Contains(focusedFigure)){
                                        List<int> indexes = getCheckIndexes(focusedFigure.Parent);
                                        availableCoordinates = focusedFigure.ShowMoveOptions(indexes[0], indexes[1], buttons);
                                        for (int i = 0; i < availableCoordinates.Count; i++)
                                        {
                                           
                                            int row = availableCoordinates[i].Row;
                                            int column = availableCoordinates[i].Column;
                                            buttons[row, column].BackColor = Color.GreenYellow;




                                            buttons[row, column].Click += (s, e) =>
                                            {

                                                if (focusedFigure is not null && focusedFigure.Team == CurrentSequence && IsThisCheckAvailableForSelectedFigure(buttons[row, column], availableCoordinates))
                                                {
                                                    ChessManager.Move(focusedFigure, buttons[row, column]);
                                                    KingInDeep = false;
                                                    if (CheckMateChance(row, column, focusedFigure, buttons))
                                                    {
                                                        MessageBox.Show("Şah!");
                                                        KingInDeep = true;
                                                        if (SaveKingFromOppositeChance(focusedFigure, row, column, buttons))
                                                        {
                                                            MessageBox.Show("Mat olmaram!");
                                                            foreach (Figure figure in availableFiguresForMoving)
                                                            {
                                                                figure.BackColor = Color.Red;
                                                            }

                                                        }
                                                    }

                                                    if (focusedFigure.Team == Team.White)
                                                    {
                                                        CurrentSequence = Team.Black;
                                                    }
                                                    else
                                                    {
                                                        CurrentSequence = Team.White;
                                                    }




                                                    SetToDefaultColor();
                                                    availableCoordinates.Clear();
                                                    focusedFigure = null;
                                                }





                                            };

                                        }
                                    }
                                }
                                else
                                {
                                    List<int> indexes = getCheckIndexes(focusedFigure.Parent);
                                  
                                   
                                        availableCoordinates = focusedFigure.ShowMoveOptions(indexes[0], indexes[1], buttons);

                                    

                                    for (int i = 0; i < availableCoordinates.Count; i++)
                                    {

                                        int row = availableCoordinates[i].Row;
                                        int column = availableCoordinates[i].Column;
                                        buttons[row, column].BackColor = Color.GreenYellow;




                                        buttons[row, column].Click += (s, e) =>
                                        {

                                            if (focusedFigure is not null && focusedFigure.Team == CurrentSequence && IsThisCheckAvailableForSelectedFigure(buttons[row, column], availableCoordinates))
                                            {
                                                ChessManager.Move(focusedFigure, buttons[row, column]);

                                                if (CheckMateChance(row, column, focusedFigure, buttons))
                                                {
                                                    MessageBox.Show("Şah!");
                                                    KingInDeep = true;
                                                    attackersFigure.Add(focusedFigure);
                                                    if (SaveKingFromOppositeChance(focusedFigure, row, column, buttons))
                                                    {
                                                        MessageBox.Show("Mat olmaram!");
                                                        foreach (Figure figure in availableFiguresForMoving)
                                                        {
                                                            figure.BackColor = Color.Red;
                                                        }

                                                    }
                                                }

                                                if (focusedFigure.Team == Team.White)
                                                {
                                                    CurrentSequence = Team.Black;
                                                }
                                                else
                                                {
                                                    CurrentSequence = Team.White;
                                                }




                                                SetToDefaultColor();
                                                availableCoordinates.Clear();
                                                focusedFigure = null;
                                            }





                                        };

                                    }
                                }
                               


                                
                            }
                        }
                        else if (focusedFigure.Team != figure.Team && IsThisCheckAvailableForSelectedFigure(figure.Parent as Check, availableCoordinates))
                        {
                            Figure oppositeFigure = figure;
                            List<int> indexes = getCheckIndexes(oppositeFigure.Parent);
                            int row = indexes[0];
                            int column = indexes[1];
                            ChessManager.Move(focusedFigure,(oppositeFigure.Parent as Check));
                            if (CheckMateChance(row, column, focusedFigure, buttons))
                            {
                                MessageBox.Show("Şah!");
                            }
                       
                            focusedFigure = null;
                            
                            SetLocationByItsTeam(oppositeFigure);
                            CurrentSequence = oppositeFigure.Team;
                            
                            SetToDefaultColor();
                            
                            availableCoordinates.Clear();
                            
                        }
                        else
                        {
                            focusedFigure = figure;
                        }
                       
                       



                    };

                        }
            foreach(Check button in buttons)
            {
                button.Click += (s, e) =>
                {
                    MessageBox.Show(button.isFull.ToString());
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
            SetBlackFigureLocations();
            SetWhiteFigureLocations();



        }
    }
}
