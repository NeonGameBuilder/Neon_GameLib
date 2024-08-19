using System;

namespace NeonDX.GameLoops
{
    /**
     * ゲームループ
     * 
     * 取得元： NeonDX
     */
    public sealed class NDX_DefaultGameLoop : NDX_AbstractGameLoop
    {
        /**
         * ループ初期化
         */
        public override void InitLoop()
        {
            // 初期化
            NeonDX.Game.Init();
        }

        /**
         * ループ終了処理
         */
        public override void TerminateLoop()
        {
            // NeonDXライブラリ終了
            NeonDX.Shutdown();
        }

        /**
         * ループ条件
         */
        public override bool CanProcessNextLoop()
        {
            return !NeonDX.IsExitFlagOn && NeonDX.System.ProcessMessage() == 0;
        }

        /**
         * ループ処理
         */
        public override void ProcessLoop()
        {
            // 裏画面をクリア
            NeonDX.Graphics.ClearDrawScreen();

            // FPS処理開始
            NeonDX.Graphics.Fps.StartFpsProcess();

            // 更新
            NeonDX.UpdateFramework();

            // 描画
            NeonDX.DrawFramework();

            // FPS処理完了
            NeonDX.Graphics.Fps.EndFpsProcess();

            // 裏画面に反映
            NeonDX.Graphics.ScreenFlip();
        }
    }
}
