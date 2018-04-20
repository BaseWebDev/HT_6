namespace SimpleInterface {
    abstract class Shape :Image, IShape {
        /// <summary>
        /// Счетчик поворотов
        /// </summary>
        public int CountTurn { get; set; }
        public Shape(int x, int y):this(x,y,0) {
        }
        public Shape(int x, int y, int turn):base(x,y) {
            this.CountTurn = turn;
        }
    }
}
