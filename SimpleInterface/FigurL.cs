using System;

namespace SimpleInterface {
    /// <summary>
    /// Тетрис, фигура L
    /// </summary>
    class FigurL : Shape {
       public FigurL(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            if (CountTurn % 3 == 0) { // Вертикально
                Height = 3; Width = 2;
                render.SetPixel(X, Y - 1, Color);
                render.SetPixel(X + 1, Y + 1, Color);
                render.SetPixel(X, Y + 1, Color);
            } else if (CountTurn % 3 == 1) {
                Height = 2; Width = 3;
                render.SetPixel(X - 1, Y + 1, Color);
                render.SetPixel(X - 1, Y, Color);
                render.SetPixel(X + 1, Y, Color);
            } else {
                Height = 3; Width = 2;
                render.SetPixel(X - 1, Y - 1, Color);
                render.SetPixel(X, Y - 1, Color);
                render.SetPixel(X, Y + 1, Color);
            }
        }
    }
}
