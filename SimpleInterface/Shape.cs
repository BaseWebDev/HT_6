namespace SimpleInterface {
    abstract class Shape : IShape {
        public int X { get; set; }
        public int Y { get; set; }
        public int CountTurn { get; set; }
        public abstract void Draw(IRender render);
        public Shape(int x, int y) {
            this.X = x;
            this.Y = y;
            this.CountTurn = 0;
        }
        public Shape(int x, int y, int z) {
            this.X = x;
            this.Y = y;
            this.CountTurn = z;
        }
    }
}
