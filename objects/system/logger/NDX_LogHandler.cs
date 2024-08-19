using System;
using System.Collections.Generic;

namespace NeonDX.System.Logger
{
    /**
     * ログハンドラ―
     */
    internal sealed class NDX_LogHandler
    {
        private Dictionary<int, NDX_Logger> _loggers;

        /**
         * コンストラクタ
         */
        public NDX_LogHandler(Dictionary<int, NDX_Logger> loggers)
        {
            _loggers = loggers;
        }

        /**
         * １行出力
         */
        public void WriteLine(int channel, string line)
        {
            var logger = _loggers.ContainsKey(channel) ? _loggers[channel] : null;
            if (logger != null)
            {
                logger.WriteLine(line);
            }
        }
    }
}
