using System;
using System.Collections.Generic;

namespace SimpleInterface {

    interface IRender {
        void Draw(IEnumerable<IShape> shapes);
        void SetPixel(int x, int y, ConsoleColor color);
        int Frame { get; }
    }
}
