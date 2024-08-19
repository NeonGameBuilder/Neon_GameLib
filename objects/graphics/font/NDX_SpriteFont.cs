using System;
using System.Collections.Generic;

using NeonDX.Graphics2D.Sprite;

namespace NeonDX.Graphics.Font
{
    /**
     * スプライトフォント
     * 
     * 取得元： NDX_Graphics
     */
    public class NDX_SpriteFont
    {
        private NDX_SpriteSheet _sheet;
        private Dictionary<char, NDX_SpriteFrame?> _char_frames = new Dictionary<char, NDX_SpriteFrame?>(256);

        /**
         * フォント文字
         */
        /*
        public string FontChars
        {
            get { return _font_chars; }
        }
        */

        /**
         * スプライトシート
         */
        public NDX_SpriteSheet SpriteSheet
        {
            get { return _sheet; }
        }

        /**
         * コンストラクタ
         */
        public NDX_SpriteFont(NDX_SpriteSheet sheet, string font_chars)
        {
            _sheet = sheet;
            MakeCharacterIndexes(font_chars);
        }

        /**
         * 文字とインデックスのマップを作る
         */
        private void MakeCharacterIndexes(string font_chars)
        {
            for(int i=0; i<font_chars.Length; i++)
            {
                char c = font_chars[i];
                _char_frames[c] = _sheet?.GetFrame(i);
            }
        }

        /**
         * 文字に対するインデックスを取得
         */
        public NDX_SpriteFrame? GetCharFrame(char c)
        {
            return _char_frames.ContainsKey(c) ? _char_frames[c] : null;
        }
    }
}
