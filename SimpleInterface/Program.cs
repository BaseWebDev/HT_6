using System;
using System.Collections.Generic;
using System.Threading;

namespace SimpleInterface {
    class Program {
        static void Main(string[] args) {
            var shapes = new List<IShape>();
        //    shapes.Add(new WhitePoint(10, 10));
        //    shapes.Add(new AniStar(34, 10, ConsoleColor.Green));
        //    shapes.Add(new MoveableStar(12, 20, ConsoleColor.Red));
            shapes.Add(new FigurT(20,1,ConsoleColor.Yellow));
            shapes.Add(new FigurQ(20, 4, ConsoleColor.Yellow));
            shapes.Add(new FigurI(20, 4, ConsoleColor.Yellow));
            shapes.Add(new FigurZ(20, 4, ConsoleColor.Yellow));
            shapes.Add(new FigurS(20, 4, ConsoleColor.Yellow));
            shapes.Add(new FigurJ(20, 4, ConsoleColor.Yellow));
            shapes.Add(new FigurL(20, 4, ConsoleColor.Yellow));

            var engine = new Render();
            engine.Draw(shapes);

            Console.ReadKey();
        }
    }
}
