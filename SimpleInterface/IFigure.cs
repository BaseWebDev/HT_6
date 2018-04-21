using System.Collections.Generic;

namespace SimpleInterface {
    interface IFigure: IEnumerable<Point> {
        int X { get; set; }
        int Y { get; set; }
        /// <summary>
        /// Ширина (Х)
        /// </summary>
        int Width { get; set; }
        /// <summary>
        /// Высота (Y)
        /// </summary>
        int Height { get; set; }
        List<Point> Points { get; set; }
        /// <summary>
        /// Поворот по часовой стрелке
        /// </summary>
        int CountTurn { get; set; }
        void Draw(IRender render);
    }
}
