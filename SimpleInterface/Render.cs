using System;
using System.Collections.Generic;
using System.Threading;

namespace SimpleInterface
{

    class Render : IRender {
        const int maxY = 20;
        const int maxX = 40;
        const int timeFrame = 100;
        public int Frame { get; private set; }
        /// <summary>
        /// Нажатая клавиша
        /// </summary>
        public ConsoleKey Keystroke { get; set; }
        private void PrepareEnv() {
            Console.CursorVisible = false;
        }
        /// <summary>
        /// Движение фигуры вниз с постоянной скоростью
        /// </summary>
        public bool VertMove(IShape shape) {
            if (shape.Y < maxY) {
                ++shape.Y;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Движение фигуры в право и лево
        /// </summary>
        /// <param name="key">Нажатая клавиша</param>
        public void HorizMove(IShape shape, ConsoleKey key) {
            if (key == ConsoleKey.LeftArrow & shape.X > 0) {
                --shape.X;
            } else if (key == ConsoleKey.RightArrow & shape.X <= maxX) {
                ++shape.X;
            }
        }
        public void Draw(IEnumerable<IShape> shapes) {
            this.PrepareEnv();
            foreach (var shape in shapes) {
                while (true) {
                    shape.Draw(this);
                    if (!VertMove(shape)) {
                        break;
                    }
                    Wait();
                    Clear();
                    this.Frame++;
                    if (Console.KeyAvailable == true) {
                        Keystroke = Console.ReadKey(true).Key;
                        HorizMove(shape, Keystroke);
                        if (Keystroke == ConsoleKey.UpArrow) {
                            shape.CountTurn++;
                            Keystroke = 0;
                        }
                    }
                    // }
                }
            }
        }
        private void Wait() {
            Thread.Sleep(timeFrame);
        }
        private void Clear() {
            Console.Clear();
        }
        public void SetPixel(int x, int y, ConsoleColor color) {
            if ((x < 0 || y < 0) || (x >= Console.WindowWidth || y >= Console.WindowHeight)) {
                return;
            }
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write("■");
        }
    }
}
