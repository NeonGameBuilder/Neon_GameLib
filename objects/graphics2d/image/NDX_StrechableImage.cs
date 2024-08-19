

namespace NeonDX.Graphics2D.Image
{
    /**
     * 拡大縮小可能な画像
     * 
     */
    public sealed class NDX_StretchableImage : NDX_Image
    {
        private double _scale_X;
        private double _scale_Y;

        /**
         * X軸方向の拡大率
         */
        public double ScaleX
        {
            get { return _scale_X; }
            set { _scale_X = value; IsModified = true; }
        }

        /**
         * Y軸方向の拡大率
         */
        public double ScaleY
        {
            get { return _scale_Y; }
            set { _scale_Y = value; IsModified = true; }
        }

        /**
         * コンストラクタ
         */
        public NDX_StretchableImage(NDX_Handle handle) : base(handle)
        {
            _scale_X = _scale_Y = 1.0f;
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            int x1 = Position.X;
            int y1 = Position.Y;
            int x2 = x1 + (int)(Size.Width * _scale_X);
            int y2 = y1 + (int)(Size.Height * _scale_Y);

            NDX_API_Graphics2D.DrawExtendGraph(x1, y1, x2, y2, Handle, true);
        }

        /**
         * 更新
         */
        public override void Update()
        {
        }
    }
}
