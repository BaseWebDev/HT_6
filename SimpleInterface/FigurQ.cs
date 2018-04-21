using System;

namespace SimpleInterface {
    /// <summary>
    /// Тетрис, фигура Q
    /// </summary>
    class FigurQ : Shape {
       public FigurQ(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            Height = 2; Width = 2;
            render.SetPixel(X, Y, Color);
            render.SetPixel(X + 1, Y, Color);
            render.SetPixel(X, Y + 1, Color);
            render.SetPixel(X + 1, Y + 1, Color);
        }
    }
}
