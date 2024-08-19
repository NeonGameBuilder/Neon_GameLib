using System;
using System.Collections.Generic;

using NeonDX.Graphics;
using NeonDX.Graphics.UI;

namespace NeonDX.Game.Layer
{
    /**
     * デバッグ情報レイヤー
     * 
     */
    public sealed class NDX_DebugInfoLayer : NDX_Layer
    {
        private const int OFFSET_DEBUGINFO_TEXT_LEFT = 4;
        private const int OFFSET_DEBUGINFO_TEXT_TOP = 4;

        private float _fps1 = 0;
        private float _fps2 = 0;

        private int frame_cnt = 0;

        //private NDX_GraphicsMode _mode;

        private int _loaded_graphs = 0;

        //private NDX_Environment _env;

        private Dictionary<string, NDX_SpriteLabel> _titles = new Dictionary<string, NDX_SpriteLabel>();

        /**
         * 初期化
         */
        public override void Init()
        {
            //_mode = NeonDX.Graphics.Mode;
            //_env = NeonDX.System.Environment;

            var sysfont = NeonDX.Graphics.SystemFont;

            if (sysfont == null)
            {
                throw new NDX_SystemFontIsNotSetException("System font is not set");
            }

            _titles["FPS1"] = new NDX_SpriteLabel(sysfont, "FPS1", CharacterPosToScreenPos(0, 0));
            _titles["FPS2"] = new NDX_SpriteLabel(sysfont, "FPS2", CharacterPosToScreenPos(0, 1));

            _titles["Screen"] = new NDX_SpriteLabel(sysfont, "Screen", CharacterPosToScreenPos(0, 2));
            _titles["LoadedGraphs"] = new NDX_SpriteLabel(sysfont, "LoadedGraphs", CharacterPosToScreenPos(0, 3));

            _titles["Memory"] = new NDX_SpriteLabel(sysfont, "Memory", CharacterPosToScreenPos(0, 4));
            _titles["OS Versoin"] = new NDX_SpriteLabel(sysfont, "OS Versoin", CharacterPosToScreenPos(0, 5));
            _titles["64bit OS"] = new NDX_SpriteLabel(sysfont, "64bit OS", CharacterPosToScreenPos(0, 6));
            _titles["64bit Process"] = new NDX_SpriteLabel(sysfont, "64bit Process", CharacterPosToScreenPos(0, 7));
            _titles["Processors"] = new NDX_SpriteLabel(sysfont, "Processors", CharacterPosToScreenPos(0, 8));

            // ラベル
            foreach (var k in _titles.Keys)
            {
                var label = _titles[k];
                label.Init();
            }
        }

        /**
         * 文字単位の座標からグラフィック座標に変換
         */
        private NDX_Position2D CharacterPosToScreenPos(int cx, int cy)
        {
            var sysfont = NeonDX.Graphics.SystemFont;

            if (sysfont == null)
            {
                throw new NDX_SystemFontIsNotSetException("System font is not set");
            }

            var size = sysfont.SpriteSheet.FrameSize;
            return new NDX_Position2D(OFFSET_DEBUGINFO_TEXT_LEFT + size.Width * cx, OFFSET_DEBUGINFO_TEXT_TOP + (int)(size.Height * cy * 1.5));
        }

        /**
         * 更新
         */
        public override void Update()
        {
            frame_cnt++;
            if (frame_cnt >= 60) frame_cnt = 0;

            // FPS（リアル）
            _fps1 = NeonDX.Graphics.Fps.FrameRate;

            // DXライブラリFPS
            if (frame_cnt % 10 == 0)
            {
                _fps2 = NeonDX.Graphics.Fps.FrameRateDx;
            }

            // グラフィックモード
            //_mode = NeonDX.Graphics.Mode;

            // グラフィックスロード数
            _loaded_graphs = NeonDX.Graphics.LoadedGraphCount;

            // ラベル
            foreach(var k in _titles.Keys)
            {
                var label = _titles[k];
                label.Update();
            }
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            base.Draw();

            NDX_GraphicsMode _mode = NeonDX.Graphics.Mode;
            NDX_Environment _env = NeonDX.System.Environment;

            var font = NeonDX.Graphics.SystemFont;

            if (font == null)
            {
                throw new NDX_SystemFontIsNotSetException("System font is not set");
            }

            // FPS
            NeonDX.Graphics2D.DrawText(CharacterPosToScreenPos(15, 0), $"{_fps1:F4}", font);
            NeonDX.Graphics2D.DrawText(CharacterPosToScreenPos(15, 1), $"{_fps2:F4}", font);

            // Graphics
            NeonDX.Graphics2D.DrawText(CharacterPosToScreenPos(15, 2), $"{_mode.ScreenSize.Width} x {_mode.ScreenSize.Height} {_mode.ColorBits} bit color", font);
            NeonDX.Graphics2D.DrawText(CharacterPosToScreenPos(15, 3), $"{_loaded_graphs}", font);

            // OS情報
            double mem = ((double)_env.WorkingSet) / 100.0f;
            NeonDX.Graphics2D.DrawText(CharacterPosToScreenPos(15, 4), $"{mem:f2} MB", font);
            NeonDX.Graphics2D.DrawText(CharacterPosToScreenPos(15, 5), $"{_env.OSVersion}", font);
            NeonDX.Graphics2D.DrawText(CharacterPosToScreenPos(15, 6), $"{_env.Is64bitOS}", font);
            NeonDX.Graphics2D.DrawText(CharacterPosToScreenPos(15, 7), $"{_env.Is64bitProcess}", font);
            NeonDX.Graphics2D.DrawText(CharacterPosToScreenPos(15, 8), $"{_env.Processors}", font);

            // ラベル
            foreach (var k in _titles.Keys)
            {
                var label = _titles[k];
                label.Draw();
            }
        }
    }
}
