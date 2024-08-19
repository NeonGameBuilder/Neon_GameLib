
namespace NeonDX.Graphics2D.Image
{
    /**
     * 画像
     * 
     */
    public class NDX_Image : NDX_GraphicalObject
    {
        private NDX_Position2D _pos = new NDX_Position2D();

        private NDX_Size2D _size;

        /**
         * 位置
         */
        public NDX_Position2D Position
        {
            get { return _pos; }
            set { _pos = value; IsModified = true; }
        }

        /**
         * サイズ
         */
        public NDX_Size2D Size
        {
            get { return _size; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Image(NDX_Handle handle) : base(handle) 
        {
            _size = NDX_API_Graphics2D.GetGraphSize(handle);
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            NDX_API_Graphics2D.DrawGraph(_pos.X, _pos.Y, Handle, true);
        }

        /**
         * 更新
         */
        public override void Update()
        {
        }
    }
}
