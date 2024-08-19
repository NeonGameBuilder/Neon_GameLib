using System.Collections.Generic;

namespace NeonDX.Input
{
    /**
     * 仮想パッドキーマップ
     * 
     * 取得元： NDX_VirtualPad
     * 
     * 仮想パッドのキーマップを扱う。
     */
    public sealed class NDX_VirtualPadKeyMap
    {
        private Dictionary<EnumPhysicalKey, EnumVirtualPadKey> _map = new Dictionary<EnumPhysicalKey, EnumVirtualPadKey>();

        /**
         * 物理入力キーに対する仮想キーを取得
         */
        public EnumVirtualPadKey GetVirtualPadKey(EnumPhysicalKey virtual_input)
        {
            return _map.ContainsKey(virtual_input) ? _map[virtual_input] : EnumVirtualPadKey.Unknown;
        }
    }
}
