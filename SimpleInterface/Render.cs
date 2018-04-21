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
        private HeapFigur heapFigur;
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
            heapFigur = new HeapFigur(widthField, heightField);
            this.minX = canvas.X+(dX / 2);
            //this.minY = 0;
            this.maxX = widthField+canvas.X + (dX / 2);
            this.maxY = heightField-canvas.Y;
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
            if (key == ConsoleKey.LeftArrow) {
                if (shape.X > minX) { --shape.X; }      
            } else if (key == ConsoleKey.RightArrow) {
                if (shape.X < maxX) { ++shape.X; }
            }
        }
        public void Draw(IEnumerable<IShape> shapes) {
            this.PrepareEnv();
            foreach (var shape in shapes) {
                while (true) {
                    shape.Draw(this);
                    if (!VertMove(shape)) {
                        heapFigur.Add(shape);
                        break;
                    }
                    Wait();
                    Clear();
                    canvas.Draw(this);  // Рисуем "Стакан"
                    heapFigur.Draw(this);
                    
                    if (Console.KeyAvailable == true) {
                        Keystroke = Console.ReadKey(true).Key;
                        HorizMove(shape, Keystroke);
                        if (Keystroke == ConsoleKey.UpArrow) {
                            shape.CountTurn++;
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
    }
}
