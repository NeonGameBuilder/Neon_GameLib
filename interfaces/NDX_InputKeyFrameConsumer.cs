using System;

namespace NeonDX.Interfaces
{
    /**
     * キーコンシューマーインタフェース
     * 
     */
    public interface NDX_InputKeyFrameConsumer
    {
        /**
         * キープロバイダに接続する。
         */
        void ConnectToKeyProvider(NDX_InputKeyFrameProvider provider);
    }
}
