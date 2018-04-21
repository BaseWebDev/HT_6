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
        public int DeleteLine {get;set;}
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
            this.DeleteLine = line;
            this.Points.RemoveAll(WholeLine);
        }
        private bool WholeLine(Point point) {
            return point.Y == DeleteLine;
        }
        public void MoveDown() {
            foreach (var point in Points) {
                ++point.Y;
            }
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