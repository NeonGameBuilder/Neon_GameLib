
using NeonDX.Graphics.Font;
using NeonDX.Graphics2D.Screen;
using NeonDX.Graphics2D.Sprite;

namespace NeonDX.Graphics
{
    /**
     * グラフィックス
     * 
     * 取得元： NeonDX
     */
    public sealed class NDX_Graphics : NDX_GraphicalObject
    {
        private const string PATH_ASSET_FONT_SYSFONT = "_assets/sysfont.png";

        private NDX_FPS _fps = new NDX_FPS();

        private NDX_Size2D _screen_size = new NDX_Size2D();

        private NDX_SystemFont? _sys_font;

        private NDX_GraphicsMode _graph_mode = new NDX_GraphicsMode();

        /**
         * グラフィックスモード
         */
        public NDX_GraphicsMode Mode
        {
            get { return _graph_mode; }
        }

        /**
         * ロード済みグラフィック数
         */
        public int LoadedGraphCount
        {
            get { return NDX_API_Graphics2D.LoadedGraphCount; }
        }

        /**
         * 初期化
         */
        public override void Init()
        {
            _graph_mode.Init();

            // グラフィックスモードの変更
            SetGraphMode(_graph_mode);

            // システムフォントを作成
            var sheet = NeonDX.Graphics2D.CreateSpriteSheet(PATH_ASSET_FONT_SYSFONT, 8, 8, 64, 64, 90);
            string font_chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789+*-/=()|'""!@;:[]{}?<>,.$#&%abcdefghijklmnopqrstuvwxyz";
            _sys_font = new NDX_SystemFont(sheet, font_chars);
        }

        /**
         * 更新
         */
        public override void Update()
        {
            _graph_mode.Update();
        }

        /**
         * システムフォント
         */
        public NDX_SystemFont? SystemFont
        {
            get { return _sys_font; }
        }

        /**
         * FPS
         */
        public NDX_FPS Fps
        {
            get { return _fps; }
        }

        /**
         * 画面サイズ
         */
        public NDX_Size2D ScreenSize
        {
            get { return _screen_size; }
        }

        /**
         * 描画対象画面を指定（表画面or裏画面）
         */
        public void SetDrawScreen(EnumScreen screen)
        {
            NDX_API_Graphics2D.SetDrawScreen(screen);
        }

        /**
         * 描画対象画面を指定（仮想画面）
         */
        public void SetDrawScreen(NDX_VirtualScreen screen)
        {
            NDX_API_Graphics2D.SetDrawScreen(screen.Handle);
        }

        /**
         * 画面モードの変更
         */
        public void SetGraphMode(NDX_GraphicsMode mode)
        {
            SetGraphMode(mode.ScreenSize.Width, mode.ScreenSize.Height, mode.ColorBits);
        }
        public void SetGraphMode(int SizeX, int SizeY, int ColorBitNum)
        {
            NDX_API_Graphics2D.SetGraphMode(SizeX, SizeY, ColorBitNum);

            // サイズとビット深度を取得
            int cx, cy, colors;

            NDX_API_Graphics2D.GetScreenState(out cx, out cy, out colors);
            _screen_size.Width = cx;
            _screen_size.Height = cy;
        }

        /**
         * フォントを作成
         */
        public NDX_Font CreateFont(NDX_FontInfo fi)
        {
            return CreateFont(fi.FontName, fi.Size, fi.Thickness, fi.FontType);
        }
        public NDX_Font CreateFont(string font_name, int size, int thickness, EnumFontType font_type = EnumFontType.Normal)
        {
            var handle = NDX_API_Graphics2D.CreateFontToHandle(font_name, size, thickness, font_type);
            return new NDX_Font(handle);
        }

        /**
         * スプライトフォントを作成
         */
        public NDX_SpriteFont CreateSpriteFont(NDX_SpriteSheet sheet, string font_chars)
        {
            return new NDX_SpriteFont(sheet, font_chars);
        }

        /**
         * 画面に描かれたものを消去する
         */
        public void ClearDrawScreen()
        {
            NDX_API_Graphics2D.ClearDrawScreen();
        }

        /**
         * 矩形を描画
         */
        public void DrawBox(int x, int y, int width, int height, NDX_Color color, EnumFillMode fill_mode = EnumFillMode.Fill)
        {
            // 矩形を描画
            NDX_API_Graphics2D.DrawBox(x, y, x + width, y + height, color, fill_mode == EnumFillMode.Fill);
        }

        /**
         * フリップ関数、画面の裏ページ（普段は表示されていない）を 表ページ（普段表示されている）に反映する
         */
        public void ScreenFlip()
        {
            NDX_API_Graphics2D.ScreenFlip();
        }

    }
}
