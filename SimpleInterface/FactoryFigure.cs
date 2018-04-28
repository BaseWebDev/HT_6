using System;
using System.Collections.Generic;
namespace SimpleInterface
{
    /// <summary>
    /// Тетрис, фигуры
    /// </summary>
    class FactoryFigure : Figure {

        public string TypeFigure { get; set; }
        public FactoryFigure(int x, int y, ConsoleColor color, string typeFigure) : base(x, y) {
            TypeFigure = typeFigure;
            Color = color;
            this.Points = new List<Point>();
            SetPoints();
        }
        private void SetPoints() {
            this.Points.Clear();
            switch (TypeFigure) {
                case "T":
                    FigureT();
                    break;
                case "Q":
                    FigureQ();
                    break;
                case "I":
                    FigureI();
                    break;
                case "S":
                    FigureS();
                    break;
                case "Z":
                    FigureZ();
                    break;
                case "J":
                    FigureJ();
                    break;
                case "L":
                    FigureL();
                    break;
            }           
        }

        public override void Draw(IRender render) {
            SetPoints();
            render.SetPixel(this.Points);
        }

        public void FigureT() {
            Points.Add(new Point(X, Y, Color));
            if (CountTurn % 4 == 0) { // горизонтально
                Height = 2; Width = 3;
                Points.Add(new Point(X - 1, Y, Color));
                Points.Add(new Point(X + 1, Y, Color));
                Points.Add(new Point(X, Y + 1, Color));
            } else if (CountTurn % 4 == 1) {
                Height = 3; Width = 2;
                Points.Add(new Point(X, Y - 1, Color));
                Points.Add(new Point(X, Y + 1, Color));
                Points.Add(new Point(X - 1, Y, Color));
            } else if (CountTurn % 4 == 2) {
                Height = 2; Width = 3;
                Points.Add(new Point(X - 1, Y, Color));
                Points.Add(new Point(X, Y - 1, Color));
                Points.Add(new Point(X + 1, Y, Color));
            } else if (CountTurn % 4 == 3) {
                Height = 3; Width = 2;
                Points.Add(new Point(X, Y - 1, Color));
                Points.Add(new Point(X + 1, Y, Color));
                Points.Add(new Point(X, Y + 1, Color));
            }
        }
        public void FigureQ() {
            Height = 2; Width = 2;
            Points.Add(new Point(X, Y, Color));
            Points.Add(new Point(X + 1, Y, Color));
            Points.Add(new Point(X, Y + 1, Color));
            Points.Add(new Point(X + 1, Y + 1, Color));
        }
        public void FigureI() {
            Points.Add(new Point(X, Y, Color));
            if (CountTurn % 2 == 0) { // вертикально
                Height = 4; Width = 1;
                Points.Add(new Point(X, Y - 1, Color));
                Points.Add(new Point(X, Y + 1, Color));
                Points.Add(new Point(X, Y + 2, Color));
            } else {
                Height = 1; Width = 4;
                Points.Add(new Point(X - 1, Y, Color));
                Points.Add(new Point(X + 1, Y, Color));
                Points.Add(new Point(X + 2, Y, Color));
            }
        }
        public void FigureS() {
            Points.Add(new Point(X, Y, Color));
            if (CountTurn % 2 == 0) { // Вертикально
                Height = 3; Width = 2;
                Points.Add(new Point(X - 1, Y - 1, Color));
                Points.Add(new Point(X - 1, Y, Color));
                Points.Add(new Point(X, Y + 1, Color));
            } else {
                Height = 2; Width = 3;
                Points.Add(new Point(X - 1, Y + 1, Color));
                Points.Add(new Point(X + 1, Y, Color));
                Points.Add(new Point(X, Y + 1, Color));
            }        
        }
        public void FigureZ() {
            Points.Add(new Point(X, Y, Color));
            if (CountTurn % 2 == 0) { // Вертикально
                Height = 3; Width = 2;
                Points.Add(new Point(X - 1, Y, Color));
                Points.Add(new Point(X - 1, Y + 1, Color));
                Points.Add(new Point(X, Y - 1, Color));
            } else {
                Height = 2; Width = 3;
                Points.Add(new Point(X - 1, Y, Color));
                Points.Add(new Point(X + 1, Y + 1, Color));
                Points.Add(new Point(X, Y + 1, Color));
            }
        }
        public void FigureJ() {
            Points.Add(new Point(X, Y, Color));
            if (CountTurn % 3 == 0) { // Вертикально
                Height = 3; Width = 2;
                Points.Add(new Point(X - 1, Y + 1, Color));
                Points.Add(new Point(X, Y - 1, Color));
                Points.Add(new Point(X, Y + 1, Color));
            } else if (CountTurn % 3 == 1) {
                Height = 2; Width = 3;
                Points.Add(new Point(X - 1, Y, Color));
                Points.Add(new Point(X - 1, Y - 1, Color));
                Points.Add(new Point(X + 1, Y, Color));
            } else if (CountTurn % 3 == 2) {
                Height = 3; Width = 2;
                Points.Add(new Point(X, Y-1, Color));
                Points.Add(new Point(X, Y+1, Color));
                Points.Add(new Point(X+1, Y-1, Color));
            } else {
                Height = 2; Width = 3;
                Points.Add(new Point(X + 1, Y, Color));
                Points.Add(new Point(X + 1, Y + 1, Color));
                Points.Add(new Point(X - 1, Y, Color));
            }
        }
        public void FigureL() {
            Points.Add(new Point(X, Y, Color));
            if (CountTurn % 3 == 0) { // Вертикально
                Height = 3; Width = 2;
                Points.Add(new Point(X, Y - 1, Color));
                Points.Add(new Point(X + 1, Y + 1, Color));
                Points.Add(new Point(X, Y + 1, Color));
            } else if (CountTurn % 3 == 1) {
                Height = 2; Width = 3;
                Points.Add(new Point(X - 1, Y + 1, Color));
                Points.Add(new Point(X - 1, Y, Color));
                Points.Add(new Point(X + 1, Y, Color));
            } else if (CountTurn % 3 == 2) {
                Height = 3; Width = 2;
                Points.Add(new Point(X - 1, Y - 1, Color));
                Points.Add(new Point(X, Y - 1, Color));
                Points.Add(new Point(X, Y + 1, Color));
            } else {
                Height = 2; Width = 3;
                Points.Add(new Point(X - 1, Y, Color));
                Points.Add(new Point(X + 1, Y, Color));
                Points.Add(new Point(X + 1, Y - 1, Color));
            }
        }
    }
}