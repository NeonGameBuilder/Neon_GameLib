using System;

namespace NeonDX.Graphics2D.Screen
{
    /**
     * 仮想画面
     * 
     */
    public sealed class NDX_VirtualScreen : NDX_Screen
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
        public NDX_VirtualScreen(NDX_Handle handle, int width, int height) : base(handle)
        {
            _size = new NDX_Size2D(width, height);
        }

        /**
         * 裏画面をキャプチャ
         */
        public void Capture(int x, int y, int width, int height)
        {
            NDX_API_Graphics2D.GetDrawScreenGraph(x, y, x + width, y + height, Handle);
        }
        public void Capture(NDX_Position2D pos, NDX_Size2D size)
        {
            NDX_API_Graphics2D.GetDrawScreenGraph(pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height, Handle);
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            NDX_API_Graphics2D.DrawGraph(_pos.X, _pos.Y, Handle, true);
        }

        /**
         * 解放
         */
        public override void Terminate()
        {
            if (Handle != null) { 
                NDX_API_Graphics2D.DeleteGraph(Handle);
            }

            base.Terminate();
        }
    }
}
