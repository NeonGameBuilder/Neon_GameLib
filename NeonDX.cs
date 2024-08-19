using NeonDX.Graphics;
using NeonDX.Graphics2D;
using NeonDX.Graphics3D;
using NeonDX.Input;
using NeonDX.System;
using NeonDX.Game;
using NeonDX.Game.World;
using NeonDX.Game.Layer;
using NeonDX.System.Logger;

namespace NeonDX
{
    public sealed class NeonDX : NDX_GraphicalObject
    {
        private NDX_Game _game = new NDX_Game();
        private NDX_System _sys = new NDX_System();
        private NDX_Graphics _g = new NDX_Graphics();
        private NDX_Graphics2D _g2d = new NDX_Graphics2D();
        private NDX_Graphics3D _g3d = new NDX_Graphics3D();
        private NDX_Input _in = new NDX_Input();

        private NDX_Plain2DWorld _world_plain_2d = new NDX_Plain2DWorld();

        private NDX_DebugInfoLayer _debug_layer = new NDX_DebugInfoLayer();

        private static NeonDX _ndx = new NeonDX();

        public static NDX_ConsoleLogger ConsoleLogger = new NDX_ConsoleLogger();
        public static NDX_DebugLogger DebugLogger = new NDX_DebugLogger();

        private static bool _exit_flag_on = false;

        /**
         * 終了フラグ
         */
        public static bool IsExitFlagOn
        {
            get { return _exit_flag_on; }
        }


        /**
         * コンストラクタ（private）
         */
        private NeonDX()
        {
        }

        /**
         * 初期化
         */
        public override void Init()
        {
            // DXライブラリの初期化
            _sys.Init();

            // グラフィックスオブジェクトの初期化
            _g.Init();

            // システムの初期化
            _sys.Init();
        }

        public static void InitFramework()
        {
            _ndx.Init();
        }

        /**
         * 更新
         */
        public override void Update()
        {
            _g.Update();
            _game.Update();
            _sys.Update();
            _in.Update();

            // ESCキーが押されていたら終了
            if (NDX_API_Input.CheckHitKey(NDX_API_Input.KEY_INPUT_ESCAPE))
            {
                _exit_flag_on = true;
            }
        }

        public static void UpdateFramework()
        {
            _ndx.Update();
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            _g.Draw();
            _game.Draw();
        }

        public static void DrawFramework()
        {
            _ndx.Draw();
        }

        /**
         * 終了処理
         */
        public override void Terminate()
        {
            _sys.Terminate();
        }

        public static void Shutdown()
        {
            _ndx.Terminate();
        }

        /**
         * ゲーム
         */
        public static NDX_Game Game
        {
            get { return _ndx._game; }
        }

        /**
         * 重力なし２D世界
         */
        public static NDX_Plain2DWorld Plain2DWorld
        {
            get { return _ndx._world_plain_2d; }
        }

        /**
         * デバッグ情報レイヤー
         */
        public static NDX_DebugInfoLayer DebugInfoLayer
        {
            get { return _ndx._debug_layer; }
        }

        /**
         * システム
         */
        public static NDX_System System
        {
            get { return _ndx._sys; }
        }

        /**
         * グラフィックス
         */
        public static NDX_Graphics Graphics
        {
            get { return _ndx._g; }
        }

        /**
         * ２次元グラフィックス
         */
        public static NDX_Graphics2D Graphics2D
        {
            get { return _ndx._g2d; }
        }

        /**
         * ３次元グラフィックス
         */
        public static NDX_Graphics3D Graphics3D
        {
            get { return _ndx._g3d; }
        }

        /**
         * 入力
         */
        public static NDX_Input Input
        {
            get { return _ndx._in; }
        }

    }
}
