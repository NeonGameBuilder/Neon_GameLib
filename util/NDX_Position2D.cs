
namespace NeonDX
{
    /**
     * 位置
     */
    public sealed class NDX_Position2D : NDX_Object
    {
        private int _x;
        private int _y;

        /**
         * X座標
         */
        public int X
        {
            get { return _x; }
            set { _x = value; IsModified = true; }
        }

        /**
         * Y座標
         */
        public int Y
        {
            get { return _y; }
            set { _y = value; IsModified = true; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Position2D()
        {
            _x = 0;
            _y = 0;
        }
        public NDX_Position2D(NDX_Position2D pos)
        {
            _x = pos.X;
            _y = pos.Y;
        }
        public NDX_Position2D(int x, int y)
        {
            _x = x;
            _y = y;
        }

    }
}
