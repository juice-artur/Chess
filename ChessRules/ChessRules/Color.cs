using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessRules
{
    enum Color
    {
        none,
        white,
        black
    }
    static class ColorMethods
    {
        public static Color FlipColor(this Color color)
        {
            if (color == Color.black) return Color.white;
            if (color == Color.white) return Color.black;
            return color;
        }
    }
}
