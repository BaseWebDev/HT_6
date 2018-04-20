
namespace SimpleInterface
{
    abstract class Image
    {
        /// <summary>
        /// Положение по Х
        /// </summary>
        public int X { get; set; }
         /// <summary>
        /// Положение по Y
        /// </summary>
        public int Y { get; set; }      
        /// <summary>
        /// Ширина (Х)
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Высота (Y)
        /// </summary>
        public int Height { get; set; }
        public abstract void Draw(IRender render);
        public Image(int x, int y) {
            this.X = x;
            this.Y = y;
        }
        public Image(int x, int y, int w, int h) {
            this.X = x;
            this.Y = y;
            this.Width = w;
            this.Height = h;
        }
        
    }
}