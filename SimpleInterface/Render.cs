using System;
using System.Collections.Generic;
using System.Threading;

namespace SimpleInterface
{

    class Render : IRender {
        /// <summary>
        /// Минимальные и максимальные значения игрового поля
        /// </summary>
        private int minX;
        // private int minY;  
        private int maxX;
        private int maxY;
        /// <summary>
        /// Толщина стенок изображения "Стакан" по X
        /// </summary>
        const int dX = 2;
        /// <summary>
        /// Толщина стенок изображения "Стакан" по Y
        /// </summary>
        const int dY = 1;
        /// <summary>
        /// Расположение табло счета
        /// </summary>
        const int scoreX = 20;
        const int scoreY = 5;
        /// <summary>
        /// Кол-во удаленных строк
        /// </summary>
        public int CountDeleteLine { get; private set; }
        public int WidthField { get; private set;}
        /// <summary>
        /// Задержка изменения кадра (чем выше, тем движенее медленнее)
        /// </summary>
        public int TimeFrame { get; private set; } 
        const int minTimeFrame = 100;
        const int maxTimeFrame = 250;
        private Canvas canvas;
        private Heap heap;
        public int Frame { get; private set; }

        private void PrepareEnv() {
            Console.CursorVisible = false;
        }
        public Render():this (10,20) { }
        public Render(int widthField, int heightField) {
            // Размер игрового поля и изображения "Стакан" не совпадает, поэтому
            // + 1 по вертикали
            // + 2 по горизонтали
            canvas = new Canvas(widthField+dX, heightField+dY);   // по идее dX и dY должно возвращаться из Canvas 
            heap = new Heap(widthField, heightField);
            this.minX = canvas.X+(dX / 2);
            //this.minY = 0;
            this.maxX = widthField+canvas.X + (dX / 2);
            this.maxY = heightField-canvas.Y;
            WidthField=widthField;
            TimeFrame = maxTimeFrame;
        }
        public void Draw(IEnumerable<IFigure> figures) {
            this.PrepareEnv();
            this.Clear(); 
            foreach (var figure in figures) {
                while (true) {
                    TimeFrame = maxTimeFrame;
                    Clear();
                    figure.Draw(this);
                    if (!DownMove(figure)) {
                        heap.Add(figure);
                        break;
                    }                  
                    if (Console.KeyAvailable == true) { // Управление
                        switch (Console.ReadKey(true).Key) {
                            case ConsoleKey.DownArrow:
                                TimeFrame = minTimeFrame;
                                break;
                            case ConsoleKey.UpArrow:
                                figure.CountTurn++;
                                break;
                            case ConsoleKey.RightArrow:
                                RightMove(figure);
                                break;
                            case ConsoleKey.LeftArrow:
                                LeftMove(figure);
                                break;
                        }                       
                    }
                    canvas.Draw(this);  // Рисуем "Стакан"
                    heap.Draw(this);    // Рисуем "Кучу" внизу
                    DeleteLine();
                    ScoreDraw();
                    Wait();                   
                    this.Frame++;
                }
            }
            Console.WriteLine("GAME OVER");
        }
        private void Wait() {
            Thread.Sleep(TimeFrame);
        }
        private void Clear() {
            Console.Clear();
        }      
        public void SetPixel(List<Point> points) {
            foreach (var point in points) {
                if ((point.X < 0 || point.Y < 0) || (point.X >= Console.WindowWidth || point.Y >= Console.WindowHeight)) {
                    return;
                }
                Console.SetCursorPosition(point.X, point.Y);
                Console.ForegroundColor = point.Color;
                Console.Write("■");
            }
        }
        /// <summary>
        /// Поворот фигуры по часовой стрелке
        /// </summary>
        private void Turn(IFigure figure) {
            foreach (var point in canvas) {
                foreach (var pointFig in figure) {
                    if (pointFig.X + figure.Height == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            foreach (var point in heap) {
                foreach (var pointFig in figure) {
                    if (pointFig.X + figure.Height == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            figure.CountTurn++;
        }
        /// <summary>
        /// Движение фигуры вниз с постоянной скоростью
        /// </summary>
        private bool DownMove(IFigure figure) {
            foreach (var point in canvas) {
                foreach (var pointFig in figure) {
                    if (pointFig.X == point.X & pointFig.Y+1 == point.Y) {
                        return false;
                    }
                }
            }
            foreach (var point in heap) {
                foreach (var pointFig in figure) {
                    if (pointFig.X == point.X & pointFig.Y+1 == point.Y) {
                        return false;
                    }
                }
            }
            ++figure.Y;
            return true;
        }
        /// <summary>
        /// Движение фигуры вправо
        /// </summary>
        private void RightMove(IFigure figure) {
            foreach (var point in canvas) {
                foreach (var pointFig in figure) {
                    if (pointFig.X + 1 == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            foreach (var point in heap) {
                foreach (var pointFig in figure) {
                    if (pointFig.X + 1 == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            ++figure.X;
        }
        /// <summary>
        /// Движение фигуры влево
        /// </summary>
        private void LeftMove(IFigure figure) {
            foreach (var point in canvas) {
                foreach (var pointFig in figure) {
                    if (pointFig.X - 1 == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            foreach (var point in heap) {
                foreach (var pointFig in figure) {
                    if (pointFig.X - 1 == point.X & pointFig.Y == point.Y) {
                        return;
                    }
                }
            }
            --figure.X;
        }
        private void DeleteLine() {
            heap.Sort(); // Сортируем по Y
            int countY = 0;
            int lastY = -1;
            List<int> deleteLines = new List<int>();
            foreach (var point in heap) {
                if (point.Y == lastY || lastY == -1) {
                    ++countY;
                } else {
                    countY=1;
                }               
                if (countY == WidthField) {
                    deleteLines.Add(point.Y);
                }
                lastY = point.Y;
            }
            foreach (var line in deleteLines) { // Делаем так чтоб не использовать IEnumerable<Point> вызывает ошибку
                heap.Remove(line);
                heap.MoveDown(line);
                ++CountDeleteLine;
            }
            heap.Draw(this);

        }
        private void ScoreDraw (){
            Console.SetCursorPosition(scoreX, scoreY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Счет: "+ CountDeleteLine);
        }
    }
}
