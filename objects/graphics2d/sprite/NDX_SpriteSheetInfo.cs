
namespace NeonDX.Graphics2D.Sprite
{
    /**
     * スプライトシート情報
     * 
     */
    public sealed class NDX_SpriteSheetInfo
    {
        private string _filename = string.Empty;
        private int _width;
        private int _height;
        private int _h_cnt;
        private int _v_cnt;
        private int _total;

        /**
         * ファイル名
         */
        public string FileName
        {
            get { return _filename; }
            set { _filename = value; }
        }

        /**
         * スプライトサイズ（幅）
         */
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /**
         * スプライトサイズ（高さ）
         */
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /**
         * 水平方向フレーム数
         */
        public int HorzCount
        {
            get { return _h_cnt; }
            set { _h_cnt = value; }
        }

        /**
         * 垂直方向フレーム数
         */
        public int VertCount
        {
            get { return _v_cnt; }
            set { _v_cnt = value; }
        }

        /**
         * フレーム総数
         */
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
    }
}
