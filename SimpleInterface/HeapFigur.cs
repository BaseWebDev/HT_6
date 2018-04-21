using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleInterface {
    /// <summary>
    /// "Нагромождение фигур"
    /// </summary>
    class HeapFigur : Image{
        public List<Point> Points;
        private RenderPoints renderPoints;
        public HeapFigur(int w, int h) : this(0, 0, w, h) {
        }

        public HeapFigur(int x, int y, int w, int h) : base(x, y, w, h) {
            renderPoints = new RenderPoints();
            Points = new List<Point>();
        }
        /// <summary>
        /// Добавляем фигуры в наш стакан
        /// с преобразованием
        /// </summary>
        /// <param name="shape">сами фигуры</param>
       
        public void Add(IShape shape) {
            shape.Draw(renderPoints); 
            Points.AddRange(renderPoints.Points);
            renderPoints.Points.Clear();
        }
        private void ConvertIShapeToPoints(IShape shape) {

            
        }
        public override void Draw(IRender render) {
            foreach (var point in Points) {
                render.SetPixel(point.X + this.X, point.Y + this.Y, point.Color);
            }
        }     
    }
}