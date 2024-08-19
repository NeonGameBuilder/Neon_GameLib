using System;

using NeonDX.Graphics2D.Sprite;

namespace NeonDX.Graphics.Font
{
    /**
     * システムフォント
     * 
     * 取得元： NDX_Graphics
     */
    public sealed class NDX_SystemFont : NDX_SpriteFont
    {
        /**
         * コンストラクタ
         */
        public NDX_SystemFont(NDX_SpriteSheet sheet, string font_chars)
            : base(sheet, font_chars)
        {
        }
    }
}
