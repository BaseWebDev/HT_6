using System;

namespace SimpleInterface {
    /// <summary>
    /// Тетрис, фигура I
    /// </summary>
    class FigurI : Shape {
       public FigurI(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            if (CountTurn % 2 == 0) { // вертикально
                Height = 4; Width = 1;
                render.SetPixel(X, Y - 1, Color);
                render.SetPixel(X, Y + 1, Color);
                render.SetPixel(X, Y + 2, Color);
            } else {
                Height = 1; Width = 4;
                render.SetPixel(X - 1, Y, Color);
                render.SetPixel(X + 1, Y, Color);
                render.SetPixel(X + 2, Y, Color);
            }
        }
    }
}
