using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleInterface {
    /// <summary>
    /// "Нагромождение фигур"
    /// </summary>
    class Heap : Image, IEnumerable<Point>{
        public List<Point> Points;
        public Heap(int w, int h) : this(0, 0, w, h) {
        }

        public Heap(int x, int y, int w, int h) : base(x, y, w, h) {
           Points = new List<Point>();
        }
        /// <summary>
        /// Добавляем фигуры в наш стакан
        /// с преобразованием
        /// </summary>
        /// <param name="figure">сами фигуры</param>
       
        public void Add(IFigure figure) {
        //    shape.Draw(renderPoints); 
            Points.AddRange(figure.Points);
        //    renderPoints.Points.Clear();
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