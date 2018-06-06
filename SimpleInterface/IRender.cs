using System;
using System.Collections.Generic;

namespace SimpleInterface {

    interface IRender {
        void Draw(IEnumerable<IFigure> figures);
        void SetPixel(List<Point> points);
        int Frame { get; }
    }
}
