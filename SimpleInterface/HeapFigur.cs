using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleInterface {
    /// <summary>
    /// "Нагромождение фигур"
    /// </summary>
    class HeapFigur : Image{
        private List<IShape> Shapes;
        public HeapFigur(int w, int h) : this(0, 0, w, h) {
        }

        public HeapFigur(int x, int y, int w, int h) : base(x, y, w, h) {
            Shapes = new List<IShape>();
        }
        /// <summary>
        /// Добавляем фигуры в наш стакан
        /// </summary>
        /// <param name="shape">сами фигуры</param>
       
        public void Add(IShape shape) {
            Shapes.Add(shape);
        }
        public override void Draw(IRender render) {
            foreach (var shape in Shapes) {
                shape.Draw(render);
            }
        }
        
    }
}