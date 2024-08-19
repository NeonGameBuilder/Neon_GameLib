using System;

namespace NeonDX.Graphics.Font
{
    /**
     * フォント
     * 
     * 取得元： NDX_Graphics
     */
    public sealed class NDX_Font
    {
        private int _handle;

        /**
         * ハンドル
         */
        public int Handle
        {
            get { return _handle; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Font(int handle)
        {
            _handle = handle;
        }
    }
}
