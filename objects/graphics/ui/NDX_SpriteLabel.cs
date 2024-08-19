using System;

using NeonDX.Graphics.Font;
using NeonDX.Graphics2D.Screen;

namespace NeonDX.Graphics.UI
{
    /**
     * スプライトラベル
     * 
     */
    public sealed class NDX_SpriteLabel : NDX_GraphicalObject
    {
        private NDX_Position2D _pos;

        private NDX_SpriteFont _font;
        private NDX_VirtualScreen? _screen;
        private string _text;

        /**
         * 位置
         */
        public NDX_Position2D Position
        {
            get { return _pos; }
            set { _pos = value; IsModified = true; }
        }

        /**
         * スプライトフォント
         */
        public NDX_SpriteFont SpriteFont
        {
            get { return _font; }
            set { _font = value; IsModified = true; }
        }

        /**
         * テキスト
         */
        public string Text
        {
            get { return _text; }
            set { 
                if (_text != value)
                {
                    _text = value;
                    IsModified = true;
                }
            }
        }

        /**
         * コンストラクタ
         */
        public NDX_SpriteLabel(NDX_SpriteFont font, string text)
        {
            _pos = new NDX_Position2D();
            _font = font;
            _text = text;
            _pos = new NDX_Position2D(0, 0);

            IsModified = true;
        }
        public NDX_SpriteLabel(NDX_SpriteFont font, string text, int x, int y)
        {
            _pos = new NDX_Position2D();
            _font = font;
            _text = text;
            _pos = new NDX_Position2D(x, y);

            IsModified = true;
        }
        public NDX_SpriteLabel(NDX_SpriteFont font, string text, NDX_Position2D pos)
        {
            _pos = new NDX_Position2D();
            _font = font;
            _text = text;
            _pos = new NDX_Position2D(pos);

            IsModified = true;
        }

        /**
         * 初期化
         */
        public override void Init()
        {
            _screen = NeonDX.Graphics2D.CreateVirtualScreen(1, 1, false);
            _screen.Position = _pos;

            _screen.Init();
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            _screen?.Draw();
        }

        /**
         * 更新
         */
        public override void Update()
        {
            if (!IsModified && !_pos.IsModified) return;

            // 描画対象画面にスプライトフォントで文字を描画
            NeonDX.Graphics2D.DrawText(_pos, _text, _font);

            // テキストのサイズを計算
            var text_size = new NDX_Size2D(_font.SpriteSheet.FrameSize.Width * _text.Length, _font.SpriteSheet.FrameSize.Height);

            // 仮想画面を再作成
            _screen = NeonDX.Graphics2D.CreateVirtualScreen(text_size, false);

            // テキストを描きこんだ描画対象画面をキャプチャ
            _screen.Capture(_pos, text_size);

            _screen.Position = _pos;

            _pos.IsModified = false;
            IsModified = false;
        }

        /**
         * 解放
         */
        public override void Terminate()
        {
            _screen?.Terminate();

            base.Terminate();
        }
    }
}
