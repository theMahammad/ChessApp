using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    struct Coordinate
    {
        public int Row;
        public int Column;
        public Coordinate(int row,int col)
        {
            this.Row = row;
            this.Column = col;
        }
    }
}
