using System;

namespace NeonDX.Graphics
{
    /**
     * フォント情報
     * 
     * 取得元： NDX_Graphics
     */
    public sealed class NDX_FontInfo
    {
        private string _font_name;
        private int _size;
        private int _thickness;
        private EnumFontType _type;

        /**
         * フォント名
         */
        public string FontName
        {
            get { return _font_name; }
        }

        /**
         * サイズ
         */
        public int Size
        {
            get { return _size; }
        }

        /**
         * 太さ
         */
        public int Thickness
        {
            get { return _thickness; }
        }

        /**
         * フォントタイプ
         */
        public EnumFontType FontType
        {
            get { return _type; }
        }

        /**
         * コンストラクタ
         */
        public NDX_FontInfo(string font_name, int size, int thickness, EnumFontType type = EnumFontType.Normal)
        {
            _font_name = font_name;
            _size = size;
            _thickness = thickness;
            _type = type;
        }
    }
}
