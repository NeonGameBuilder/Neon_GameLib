
namespace NeonDX
{
    /**
     * ２Dベクトル
     */
    public sealed class NDX_Vector2D : NDX_Object
    {
        private double _x;
        private double _y;

        /**
         * X座標方向成分
         */
        public double X
        {
            get { return _x; }
            set { _x = value; IsModified = true; }
        }

        /**
         * Y座標方向成分
         */
        public double Y
        {
            get { return _y; }
            set { _y = value; IsModified = true; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Vector2D()
        {
            _x = 0;
            _y = 0;
        }
        public NDX_Vector2D(NDX_Vector2D vec)
        {
            _x = vec.X;
            _y = vec.Y;
        }
        public NDX_Vector2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

    }
}
