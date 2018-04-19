﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInterface
{
    /// <summary>
    /// Тетрис, фигура Q
    /// </summary>
    class FigurQ : Shape {
        public ConsoleColor Color { get; set; }
        public FigurQ(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            render.SetPixel(X + 1, Y, Color);
            render.SetPixel(X, Y + 1, Color);
            render.SetPixel(X + 1, Y + 1, Color);
        }
    }
}
