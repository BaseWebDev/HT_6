using System;
using System.Collections.Generic;

namespace SimpleInterface {
    abstract class Figure :Image, IFigure {
        /// <summary>
        /// Счетчик поворотов
        /// </summary>
        public int CountTurn { get; set; }
        public ConsoleColor Color { get; set; }
        public List<Point> Points { get; set; }

        public Figure(int x, int y):this(x,y,0) {
        }
        public Figure(int x, int y, int turn):base(x,y) {
            this.CountTurn = turn;
        }
    }
}
