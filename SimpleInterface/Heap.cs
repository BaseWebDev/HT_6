using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleInterface {
    /// <summary>
    /// "Нагромождение фигур"
    /// </summary>
    class Heap : Image, IEnumerable<Point> {
        private List<Point> Points;
        public Heap(int w, int h) : this(0, 0, w, h) {
        }

        public Heap(int x, int y, int w, int h) : base(x, y, w, h) {
            Points = new List<Point>();
        }
        public int DelLine {get;set;}

        /// <summary>
        /// Добавляем фигуры в наш стакан
        /// с преобразованием
        /// </summary>
        /// <param name="figure">сами фигуры</param>  
        public void Add(IFigure figure) {
            Points.AddRange(figure.Points);
        }

        public void Sort() {
            Points.Sort();
        }

        public void Remove(int line) {
            this.DelLine = line;
            this.Points.RemoveAll(WholeLine);
        }
        private bool WholeLine(Point point) {
            return point.Y == DelLine;
        }
        public void MoveDown(int line) {
            foreach (var point in Points) {
                if (point.Y < line) { // Чтоб небыло разрывов
                    ++point.Y;
                }
            }
        }

        public int DeleteLine() {
            int countDeleteLine = 0;
            Points.Sort(); // Сортируем по Y
            int countY = 0;
            int lastY = -1;
            List<int> deleteLines = new List<int>();          
            foreach (var point in Points.ToArray()) {  // Правда м.б косяки в связи с удалением нескольких линий 
                if (point.Y == lastY || lastY == -1) {
                    ++countY;
                } else {
                    countY = 1;
                }
                if (countY == Width) {
                    Remove(point.Y);
                    MoveDown(point.Y);
                    ++countDeleteLine;
                }
                lastY = point.Y;
            }
            return countDeleteLine;
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