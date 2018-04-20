using System;

namespace SimpleInterface {
    /// <summary>
    /// Тетрис, фигура Т
    /// </summary>
    class FigurT : Shape {
        public ConsoleColor Color { get; set; }
        public FigurT(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            render.SetPixel(X, Y, Color);
            if (CountTurn % 4 == 0) { // горизонтально
                Height = 2; Width = 3;
                render.SetPixel(X - 1, Y, Color);
                render.SetPixel(X + 1, Y, Color);
                render.SetPixel(X, Y + 1, Color);
            } else if (CountTurn % 4 == 1) {
                Height = 3; Width = 2;
                render.SetPixel(X, Y - 1, Color);
                render.SetPixel(X, Y + 1, Color);
                render.SetPixel(X - 1, Y, Color);
            } else if (CountTurn % 4 == 2) {
                Height = 2; Width = 3;
                render.SetPixel(X - 1, Y, Color);
                render.SetPixel(X, Y - 1, Color);
                render.SetPixel(X + 1, Y, Color);
            } else if (CountTurn % 4 == 3) {
                Height = 3; Width = 2;
                render.SetPixel(X, Y - 1, Color);
                render.SetPixel(X + 1, Y, Color);
                render.SetPixel(X, Y + 1, Color);
            }
        }
    }
}
