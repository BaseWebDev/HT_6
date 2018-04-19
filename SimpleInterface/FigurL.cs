using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInterface
{
    /// <summary>
    /// Тетрис, фигура L
    /// </summary>
    class FigurL : Shape {
        public ConsoleColor Color { get; set; }
        public FigurL(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            if (CountTurn % 3 == 0) { // Вертикально
                render.SetPixel(X, Y - 1, Color);
                render.SetPixel(X + 1, Y + 1, Color);
                render.SetPixel(X, Y + 1, Color);
            } else if (CountTurn % 3 == 1) {
                render.SetPixel(X - 1, Y + 1, Color);
                render.SetPixel(X - 1, Y, Color);
                render.SetPixel(X + 1, Y, Color);
            } else {
                render.SetPixel(X - 1, Y - 1, Color);
                render.SetPixel(X, Y - 1, Color);
                render.SetPixel(X, Y + 1, Color);
            }
        }
    }
}
