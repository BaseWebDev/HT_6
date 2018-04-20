﻿using System;
namespace SimpleInterface
{
    class Point {
        public int X {get;set;}
        public int Y { get; set;}
        public ConsoleColor Color { get; set; }
        public Point(int x, int y, ConsoleColor col) {
            this.X = x;
            this.Y = y;
            this.Color = col;
        }
    }
}