using System;
namespace SimpleInterface
{
    class Point:IComparable {
        public int X {get;set;}
        public int Y { get; set;}
        public ConsoleColor Color { get; set; }
        public Point(int x, int y, ConsoleColor col) {
            this.X = x;
            this.Y = y;
            this.Color = col;
        }

        public int CompareTo(object obj) {
            if (obj is Point) {
                Point temp = obj as Point;
                return this.Y- temp.Y;
            }
            return -1;
        }
    }
}