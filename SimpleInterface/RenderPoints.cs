using System;
using System.Collections.Generic;
using System.Threading;

namespace SimpleInterface
{
    class RenderPoints : IRender {
        public int Frame { get; set; }
        public List<Point> Points;
        public RenderPoints() {
            Points = new List<Point>();
        }
        public void Draw(IEnumerable<IShape> shapes) {
            
        }
        public void SetPixel(int x, int y, ConsoleColor color) {
            Points.Add( new Point( x,  y, color));
        }     
    }
}