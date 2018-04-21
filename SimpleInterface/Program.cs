using System;
using System.Collections.Generic;

namespace SimpleInterface {
    class Program {
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        const int widthField = 10;
        /// <summary>
        /// Высота игрового поля
        /// </summary>
        const int heightField = 20;
        static void Main(string[] args) {
            /*
            var shapes = new List<IShape>();
            int middleField = widthField / 2;
            shapes.Add(new FigurT(middleField, 4,ConsoleColor.Yellow));
            shapes.Add(new FigurQ(middleField, 4, ConsoleColor.Yellow));
            shapes.Add(new FigurI(middleField, 4, ConsoleColor.Yellow));
            shapes.Add(new FigurZ(middleField, 4, ConsoleColor.Yellow));
            shapes.Add(new FigurS(middleField, 4, ConsoleColor.Yellow));
            shapes.Add(new FigurJ(middleField, 4, ConsoleColor.Yellow));
            shapes.Add(new FigurL(middleField, 4, ConsoleColor.Yellow));
            */
            var Figures = new List<IFigure>();
            int middleField = widthField / 2;
            Figures.Add(new FactoryFigure(middleField, 4, ConsoleColor.Yellow, "T"));
            Figures.Add(new FactoryFigure(middleField, 4, ConsoleColor.Yellow, "Q"));
            Figures.Add(new FactoryFigure(middleField, 4, ConsoleColor.Yellow, "I"));
            Figures.Add(new FactoryFigure(middleField, 4, ConsoleColor.Yellow, "S"));
            Figures.Add(new FactoryFigure(middleField, 4, ConsoleColor.Yellow, "Z"));
            Figures.Add(new FactoryFigure(middleField, 4, ConsoleColor.Yellow, "J"));
            Figures.Add(new FactoryFigure(middleField, 4, ConsoleColor.Yellow, "L"));
            var engine = new Render(widthField,heightField);
            engine.Draw(Figures);
            // engine.Draw(shapes);

            Console.ReadKey();
        }
    }
}
