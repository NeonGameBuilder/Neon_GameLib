using System;

using NeonDX.Interfaces;

namespace NeonDX.GameLoops
{
    /**
     * ゲームループインタフェース
     * 
     */
    public abstract class NDX_AbstractGameLoop : NDX_GameLoop
    {
        /**
         * ゲームループ本体
         */
        public virtual void DoLoop()
        {
            // ループ初期化
            InitLoop();

            // ゲームループ
            while (CanProcessNextLoop())
            {
                // ループ処理
                ProcessLoop();
            }

            // ループ終了処理
            TerminateLoop();
        }

        /**
         * ループ初期化
         */
        public abstract void InitLoop();

        /**
         * ループ終了処理
         */
        public abstract void TerminateLoop();

        /**
         * ループ条件
         */
        public abstract bool CanProcessNextLoop();

        /**
         * ループ処理
         */
        public abstract void ProcessLoop();
    }
}
