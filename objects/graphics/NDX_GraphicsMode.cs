using System;

namespace NeonDX.Graphics
{
    /**
     * グラフィックスモード
     */
    public sealed class NDX_GraphicsMode : NDX_Object
    {
        private const int DEFAULT_SCREEN_WIDTH = 640;
        private const int DEFAULT_SCREEN_HEIGHT = 480;

        private NDX_Size2D _size_screen = new NDX_Size2D(DEFAULT_SCREEN_WIDTH, DEFAULT_SCREEN_HEIGHT);
        private int _color_bits;

        /**
         * スクリーンサイズ
         */
        public NDX_Size2D ScreenSize
        {
            get { return _size_screen; }
            set { _size_screen = value; IsModified = true; }
        }

        /**
         * カラービット数
         */
        public int ColorBits
        {
            get { return _color_bits; }
            set { _color_bits = value; IsModified = true; }
        }

        /**
         * コンストラクタ
         */
        internal NDX_GraphicsMode()
        {
        }

        /**
         * 更新
         */
        public override void Update()
        {
            if (!IsModified && !_size_screen.IsModified) return;

            NeonDX.Graphics.SetGraphMode(this);
        }
    }
}
