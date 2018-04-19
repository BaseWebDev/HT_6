using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInterface
{
    interface IShape {
        int X { get; set; }
        int Y { get; set; }
        /// <summary>
        /// Поворот по часовой стрелке
        /// </summary>
        int CountTurn { get; set; }
        void Draw(IRender render);
    }
}
