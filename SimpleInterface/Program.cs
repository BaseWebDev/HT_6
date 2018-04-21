﻿using System;
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
        /// <summary>
        /// Максимальное кол-во фигур
        /// </summary>
        const int maxFigure = 1000;
        /// <summary>
        /// Минимальная высота начала движения фигуры по Y
        /// </summary>
        const int minY = 4;
        static void Main(string[] args) {
            string[] nameFigure = new string[] {"T","Q", "I", "S", "Z", "J", "L"};
            ConsoleColor[] consoleColor = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Blue };
            Random random = new Random();
            var Figures = new List<IFigure>();
            int middleField = widthField / 2;
            for (int i = 0; i < maxFigure; i++) {
                Figures.Add(new FactoryFigure(middleField, minY, consoleColor[random.Next(0,consoleColor.Length-1)], nameFigure[random.Next(0, nameFigure.Length-1)]));
            }
            var engine = new Render(widthField,heightField);
            Console.WriteLine("\tМиниТетрис");
            Console.WriteLine();
            Console.WriteLine(@"Стрелка""Вверх"" - перевернуть фигуру");
            Console.WriteLine(@"Стрелка""Вниз"" - ускорить падение");
            Console.WriteLine(@"Стрелка""Вправо""-""Влево"" - движение фигуры вправо и влево");
            Console.WriteLine();
            Console.WriteLine(@"Жми ""Enter"" для начала...");   
            Console.ReadKey();
            engine.Draw(Figures);
            Console.ReadKey();
        }
    }
}
