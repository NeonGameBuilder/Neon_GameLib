using System;

namespace NeonDX.System.Logger
{
    /**
     * コンソールロガー
     */
    public sealed class NDX_ConsoleLogger : NDX_Logger
    {
        /**
         * １行出力
         */
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
