using System;

namespace NeonDX.Interfaces
{
    /**
     * ゲームループインタフェース
     * 
     */
    public interface NDX_GameLoop
    {
        /**
         * ゲームループ本体
         */
        void DoLoop();

        /**
         * ループ初期化
         */
        void InitLoop();

        /**
         * ループ終了処理
         */
        void TerminateLoop();

        /**
         * ループ条件
         */
        bool CanProcessNextLoop();

        /**
         * ループ処理
         */
        void ProcessLoop();
    }
}
