using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleInterface
{   
    /// <summary>
    /// "Стакан"
    /// </summary>
    class Canvas : Image, IEnumerable<Point> {
        public ConsoleColor Color { get; set; }
        private List<Point> Points;
        public Canvas(int w, int h):this(0,0,w,h, ConsoleColor.White) {
        }

        public Canvas(int x, int y, int w, int h, ConsoleColor col) : base(x, y, w, h) {
            this.Color = col;
            this.Points=Allocation();
        }
        /// <summary>
        /// Позиционируем все точки, рисуем "Стакан"
        /// </summary>
        /// <param name="x">Начальное расположение по X</param>
        /// <param name="y">Начальное расположение по Y</param>
        /// <param name="w">Width</param>
        /// <param name="h">Heigth</param>
        private List<Point> Allocation() {
            List<Point> points = new List<Point>();
            for (int i=0; i<Width; i++) {
                for (int j = 0; j < Height; j++) {
                    if (i == 0 || i == (Width - 1)||j==(Height-1)) {
                        points.Add(new Point(i, j, Color));
                    }
                }
            }
            return points;
        }
        public override void Draw(IRender render) {
            render.SetPixel(Points);
  
        }

        public IEnumerator<Point> GetEnumerator() {
            return Points.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Points.GetEnumerator();
        }
    }
}