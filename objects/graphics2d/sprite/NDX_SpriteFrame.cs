using System;

namespace NeonDX.Graphics2D.Sprite
{
    /**
     * スプライトフレーム
     * 
     * スプライトの１つのフレーム画像
     */
    public sealed class NDX_SpriteFrame
    {
        private NDX_Handle _handle;

        /**
         * ハンドル
         */
        public NDX_Handle Handle
        {
            get { return _handle; }
        }

        /**
         * コンストラクタ
         */
        public NDX_SpriteFrame(NDX_Handle handle)
        {
            _handle = handle;
        }

    }
}
