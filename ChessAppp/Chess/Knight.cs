﻿using System;
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

        public override void CaptureOppositeFigure()
        {
            throw new NotImplementedException();
        }

        public override void Move(Check button)
        {
            throw new NotImplementedException();
        }
        public override List<Coordinate> ShowMoveOptions(int row, int column, Check[,] buttons)
        {
            return null;
        }
    }
}
