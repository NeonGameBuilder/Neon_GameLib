using System;
using System.Diagnostics;

namespace NeonDX.System.Logger
{
    /**
     * デバッグロガー
     */
    public sealed class NDX_DebugLogger : NDX_Logger
    {
        /**
         * １行出力
         */
        public void WriteLine(string line)
        {
            Debug.WriteLine(line);
        }
    }
}
