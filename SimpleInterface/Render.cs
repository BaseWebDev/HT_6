using System;
using System.Collections.Generic;
using System.Threading;

namespace SimpleInterface
{

    class Render : IRender {
        /// <summary>
        /// Минимальные и максимальные значения игрового поля
        /// </summary>
        private int minX;
        // private int minY;  
        private int maxX;
        private int maxY;
        /// <summary>
        /// Толщина стенок изображения "Стакан" по X
        /// </summary>
        const int dX=2;
        /// <summary>
        /// Толщина стенок изображения "Стакан" по Y
        /// </summary>
        const int dY=1;

        const int timeFrame = 100;
        private Canvas canvas;
        private Heap heap;
        public int Frame { get; private set; }
        /// <summary>
        /// Нажатая клавиша
        /// </summary>
        public ConsoleKey Keystroke { get; set; }
        private void PrepareEnv() {
            Console.CursorVisible = false;
        }
        public Render():this (10,20) { }
        public Render(int widthField, int heightField) {
            // Размер игрового поля и изображения "Стакан" не совпадает, поэтому
            // + 1 по вертикали
            // + 2 по горизонтали
            canvas = new Canvas(widthField+dX, heightField+dY);   // по идее dX и dY должно возвращаться из Canvas 
            heap = new Heap(widthField, heightField);
            this.minX = canvas.X+(dX / 2);
            //this.minY = 0;
            this.maxX = widthField+canvas.X + (dX / 2);
            this.maxY = heightField-canvas.Y;
        }
        /// <summary>
        /// Движение фигуры вниз с постоянной скоростью
        /// </summary>
        public bool VertMove(IFigure shape) {
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
        public void HorizMove(IFigure figure, ConsoleKey key) {
            if (key == ConsoleKey.LeftArrow) {
                if (figure.X > minX) { --figure.X; }      
            } else if (key == ConsoleKey.RightArrow) {
                if (figure.X < maxX) { ++figure.X; }
            }
        }
        public void Draw(IEnumerable<IFigure> figures) {
            this.PrepareEnv();
            foreach (var figure in figures) {
                while (true) {
                    figure.Draw(this);
                    if (!VertMove(figure)) {
                        heap.Add(figure);
                        break;
                    }
                    Wait();
                    Clear();
                    canvas.Draw(this);  // Рисуем "Стакан"
                    heap.Draw(this);
                    
                    if (Console.KeyAvailable == true) {
                        Keystroke = Console.ReadKey(true).Key;
                        HorizMove(figure, Keystroke);
                        if (Keystroke == ConsoleKey.UpArrow) {
                            figure.CountTurn++;
                            Keystroke = 0;
                        }
                    }
                    this.Frame++;
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

        public void SetPixel(List<Point> points) {
            foreach (var point in points) {
                if ((point.X < 0 || point.Y < 0) || (point.X >= Console.WindowWidth || point.Y >= Console.WindowHeight)) {
                    return;
                }
                Console.SetCursorPosition(point.X, point.Y);
                Console.ForegroundColor = point.Color;
                Console.Write("■");
            }
        }
    }
}
