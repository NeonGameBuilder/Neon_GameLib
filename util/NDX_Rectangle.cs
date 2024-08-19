
namespace NeonDX
{
    /**
     * 長方形領域
     */
    public sealed class NDX_Rectangle: NDX_Object
    {
        private NDX_Position2D _posLeftTop;
        private NDX_Size2D _size;

        /**
         * 左上のX座標
         */
        public int Left
        {
            get { return _posLeftTop.X; }
            set { _posLeftTop.X = value; IsModified = true; }
        }

        /**
         * 左上のY座標
         */
        public int Top
        {
            get { return _posLeftTop.Y; }
            set { _posLeftTop.Y = value; IsModified = true; }
        }

        /**
         * 幅
         */
        public int Width
        {
            get { return _size.Width; }
            set { _size.Width = value; IsModified = true; }
        }

        /**
         * 高さ
         */
        public int Height
        {
            get { return _size.Height; }
            set { _size.Height = value; IsModified = true; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Rectangle()
        {
            _posLeftTop = new NDX_Position2D();
            _size = new NDX_Size2D();
        }
        public NDX_Rectangle(int x, int y, int width, int height)
        {
            _posLeftTop = new NDX_Position2D(x, y);
            _size = new NDX_Size2D(width, height);
        }

    }
}
