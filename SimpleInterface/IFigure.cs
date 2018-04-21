using System.Collections.Generic;

namespace SimpleInterface {
    interface IFigure {
        int X { get; set; }
        int Y { get; set; }

        List<Point> Points { get; set; }
        /// <summary>
        /// Поворот по часовой стрелке
        /// </summary>
        int CountTurn { get; set; }
        void Draw(IRender render);
    }
}
