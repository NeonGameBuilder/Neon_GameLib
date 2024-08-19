using System;
using System.Collections.Generic;

using NeonDX.Input.Key;

namespace NeonDX.Interfaces
{
    /**
     * キープロバイダインタフェース
     * 
     */
    public interface NDX_InputKeyFrameProvider
    {
        /**
         * キーを供給する。供給するキーがない場合はnullを返す。
         */
        NDX_InputKeyFrame? ProvideInputKeyFrame();
    }
}
