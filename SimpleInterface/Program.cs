using System;
using System.Collections.Generic;
using System.Threading;

namespace SimpleInterface {
    class Program {
        static void Main(string[] args) {
            var shapes = new List<IShape>();
            shapes.Add(new WhitePoint(10, 10));
            shapes.Add(new AniStar(34, 10, ConsoleColor.Green));
            shapes.Add(new MoveableStar(12, 20, ConsoleColor.Red));
            shapes.Add(new FigurT(5,15,ConsoleColor.Yellow));
            shapes.Add(new FigurQ(5, 10, ConsoleColor.Yellow));
            shapes.Add(new FigurI(0, 0, ConsoleColor.Yellow));
            shapes.Add(new FigurZ(2, 0, ConsoleColor.Yellow));
            shapes.Add(new FigurS(6, 0, ConsoleColor.Yellow));
            shapes.Add(new FigurJ(9, 0, ConsoleColor.Yellow));
            shapes.Add(new FigurL(15, 0, ConsoleColor.Yellow));

            var engine = new Render();
            engine.Draw(shapes);

            Console.ReadKey();
        }
    }

    interface IRender {
        void Draw(IEnumerable<IShape> shapes);
        void SetPixel(int x, int y, ConsoleColor color);
        int Frame { get; }
    }

    class Render : IRender {
        public int Frame { get; private set; }
        private void PrepareEnv() {
            Console.CursorVisible = false;
        }
        public void Draw(IEnumerable<IShape> shapes) {
            this.PrepareEnv();
            while (true) {
                foreach (var shape in shapes) {
                    shape.Draw(this);
                }
                Wait();
                Clear();
                this.Frame++;
            }
        }
        private void Wait() {
            Thread.Sleep(100);
        }
        private void Clear() {
            Console.Clear();
        }
        public void SetPixel(int x, int y, ConsoleColor color) {
            if ((x < 0 || y < 0)||( x >= Console.WindowWidth || y >= Console.WindowHeight)) {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write("■");
        }
    }
    interface IShape {
        int X { get; set; }
        int Y { get; set; }
        void Draw(IRender render);
    }
    abstract class Shape : IShape {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract void Draw(IRender render);
        public Shape(int x, int y) {
            this.X = x;
            this.Y = y;
        }
    }
    class WhitePoint : Shape {
        public WhitePoint(int x, int y) : base(x, y) {
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, ConsoleColor.White);
        }
    }
    class Star : Shape {
        public ConsoleColor Color { get; set; }
        public Star(int x, int y, ConsoleColor color) : base(x, y) {
            this.Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            render.SetPixel(X - 1, Y, Color);
            render.SetPixel(X + 1, Y, Color);
            render.SetPixel(X, Y - 1, Color);
            render.SetPixel(X, Y + 1, Color);
        }
    }
    class AniStar : Shape {
        public ConsoleColor Color { get; set; }
        public AniStar(int x, int y, ConsoleColor color) : base(x, y) {
            this.Color = color;
        }
        private void Frame1(IRender render) {
            render.SetPixel(X, Y, Color);
            render.SetPixel(X - 1, Y, Color);
            render.SetPixel(X + 1, Y, Color);
            render.SetPixel(X, Y - 1, Color);
            render.SetPixel(X, Y + 1, Color);
        }
        private void Frame2(IRender render) {
            render.SetPixel(X, Y, Color);
            render.SetPixel(X - 1, Y - 1, Color);
            render.SetPixel(X - 1, Y + 1, Color);
            render.SetPixel(X + 1, Y - 1, Color);
            render.SetPixel(X + 1, Y + 1, Color);
        }
        public override void Draw(IRender render) {
            if (render.Frame % 2 == 0) {
                this.Frame1(render);
            } else {
                this.Frame2(render);
            }
        }
    }
    class MoveableStar : Star {
        public MoveableStar(int x, int y, ConsoleColor color) : base(x, y, color) {
        }
        public override void Draw(IRender render) {
            X = X % Console.WindowWidth + 1;
            base.Draw(render);
        }
    }
    /// <summary>
    /// Тетрис, фигура Т
    /// </summary>
    class FigurT : Shape {
        public ConsoleColor Color { get; set; }
        public FigurT(int x,int y, ConsoleColor color): base(x,y) {
            Color = color;   
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            render.SetPixel(X-1, Y, Color);
            render.SetPixel(X+1, Y, Color);
            render.SetPixel(X, Y+1, Color);
        }
    }
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
            render.SetPixel(X , Y+1, Color);
            render.SetPixel(X+1, Y + 1, Color);
        }
    }
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
            render.SetPixel(X, Y+1, Color);
            render.SetPixel(X, Y + 2, Color);
            render.SetPixel(X, Y + 3, Color);
        }
    }
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
            render.SetPixel(X+1, Y , Color);
            render.SetPixel(X+1, Y + 1, Color);
            render.SetPixel(X+2, Y + 1, Color);
        }
    }
    /// <summary>
    /// Тетрис, фигура S
    /// </summary>
    class FigurS : Shape {
        public ConsoleColor Color { get; set; }
        public FigurS(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            render.SetPixel(X + 1, Y, Color);
            render.SetPixel(X, Y + 1, Color);
            render.SetPixel(X - 1, Y + 1, Color);
        }
    }
    /// <summary>
    /// Тетрис, фигура J
    /// </summary>
    class FigurJ : Shape {
        public ConsoleColor Color { get; set; }
        public FigurJ(int x, int y, ConsoleColor color) : base(x, y) {
            Color = color;
        }
        public override void Draw(IRender render) {
            render.SetPixel(X, Y, Color);
            render.SetPixel(X, Y+1, Color);
            render.SetPixel(X, Y + 2, Color);
            render.SetPixel(X -1, Y + 2, Color);
        }
    }
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
            render.SetPixel(X, Y + 1, Color);
            render.SetPixel(X, Y + 2, Color);
            render.SetPixel(X + 1, Y + 2, Color);
        }
    }
}
