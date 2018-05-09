using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleInterface {
    abstract class Figure :Image, IFigure, IEnumerable<Point> {
        /// <summary>
        /// Счетчик поворотов
        /// </summary>
        public int CountTurn { get; set; }
        public ConsoleColor Color { get; set; }
        public List<Point> Points { get; set; }
        public Figure(int x, int y):base(x,y) {
            this.CountTurn = 0;
        }
        /// <summary>
        /// Поворот фигуры по часовой стрелке
        /// </summary>
        public void Turn(Canvas canvas, Heap heap) {
            foreach (var point in canvas) {
                foreach (var pointFig in Points) {
                    if (pointFig.X + this.Height == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            foreach (var point in heap) {
                foreach (var pointFig in Points) {
                    if (pointFig.X + this.Height == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            this.CountTurn++;
        }
        /// <summary>
        /// Движение фигуры вниз с постоянной скоростью
        /// </summary>
        public bool DownMove(Canvas canvas, Heap heap) {
            foreach (var point in canvas) {
                foreach (var pointFig in Points) {
                    if (pointFig.X == point.X & pointFig.Y + 1 == point.Y) {
                        return false;
                    }
                }
            }
            foreach (var point in heap) {
                foreach (var pointFig in Points) {
                    if (pointFig.X == point.X & pointFig.Y + 1 == point.Y) {
                        return false;
                    }
                }
            }
            ++this.Y;
            return true;
        }
        /// <summary>
        /// Движение фигуры вправо
        /// </summary>
        public void RightMove(Canvas canvas, Heap heap) {
            foreach (var point in canvas) {
                foreach (var pointFig in Points) {
                    if (pointFig.X + 1 == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            foreach (var point in heap) {
                foreach (var pointFig in Points) {
                    if (pointFig.X + 1 == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            ++this.X;
        }
        /// <summary>
        /// Движение фигуры влево
        /// </summary>
        public void LeftMove(Canvas canvas, Heap heap) {
            foreach (var point in canvas) {
                foreach (var pointFig in Points) {
                    if (pointFig.X - 1 == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            foreach (var point in heap) {
                foreach (var pointFig in Points) {
                    if (pointFig.X - 1 == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            --this.X;
        }

        public IEnumerator<Point> GetEnumerator() {
            return Points.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Points.GetEnumerator();
        }
    }
}
