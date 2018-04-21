using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleInterface {
    /// <summary>
    /// "Нагромождение фигур"
    /// </summary>
    class Heap : Image{
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
            foreach (var point in Points) {
                render.SetPixel(point.X + this.X, point.Y + this.Y, point.Color);
            }
        }     
    }
}