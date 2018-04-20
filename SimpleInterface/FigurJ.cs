using System;

namespace SimpleInterface {
    /// <summary>
    /// Тетрис, фигура J
    /// </summary>
    class FigurJ : Shape {
        public ConsoleColor Color { get; set; }
        public int Turn { get; set; }
        public FigurJ(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            if (CountTurn % 3 == 0) { // Вертикально
                render.SetPixel(X - 1, Y + 1, Color);
                render.SetPixel(X, Y - 1, Color);
                render.SetPixel(X, Y + 1, Color);
            } else if (CountTurn % 3 == 1) {
                render.SetPixel(X - 1, Y, Color);
                render.SetPixel(X - 1, Y - 1, Color);
                render.SetPixel(X + 1, Y, Color);
            } else {
                render.SetPixel(X + 1, Y, Color);
                render.SetPixel(X + 1, Y + 1, Color);
                render.SetPixel(X - 1, Y, Color);
            }
        }
    }
}
