using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInterface
{
    /// <summary>
    /// Тетрис, фигура Z
    /// </summary>
    class FigurZ : Shape {
        public ConsoleColor Color { get; set; }
        public FigurZ(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            if (CountTurn % 2 == 0) { // Вертикально
                render.SetPixel(X - 1, Y, Color);
                render.SetPixel(X - 1, Y + 1, Color);
                render.SetPixel(X, Y - 1, Color);
            } else {
                render.SetPixel(X - 1, Y, Color);
                render.SetPixel(X + 1, Y + 1, Color);
                render.SetPixel(X, Y + 1, Color);
            }
        }
    }
}
