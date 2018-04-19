using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInterface
{
    /// <summary>
    /// Тетрис, фигура I
    /// </summary>
    class FigurI : Shape {
        public ConsoleColor Color { get; set; }
        public FigurI(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            if (CountTurn % 2 == 0) { // вертикально
                render.SetPixel(X, Y - 1, Color);
                render.SetPixel(X, Y + 1, Color);
                render.SetPixel(X, Y + 2, Color);
            } else {
                render.SetPixel(X - 1, Y, Color);
                render.SetPixel(X + 1, Y, Color);
                render.SetPixel(X + 2, Y, Color);
            }
        }
    }
}
