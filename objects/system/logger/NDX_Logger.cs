using System;

namespace NeonDX.System.Logger
{
    /**
     * ロガー
     * 
     * 取得元： NDX_System
     */
    public interface NDX_Logger
    {
        /**
         * １行出力
         */
        void WriteLine(string line);
    }
}
