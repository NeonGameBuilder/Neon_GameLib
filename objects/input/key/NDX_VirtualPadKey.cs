using System;

namespace NeonDX.Input.Key
{
    /**
     * 仮想パッドキー
     * 
     */
    public sealed class NDX_VirtualPadKey : NDX_KeyInput
    {
        private EnumVirtualPadKey _virtual_pad_key;

        /**
         * 物理入力キー
         */
        public EnumVirtualPadKey VirtualPadKey
        {
            get { return _virtual_pad_key; }
        }

        /**
         * コンストラクタ
         */
        public NDX_VirtualPadKey(EnumVirtualPadKey virtual_pad_key) : base(EnumKeyInputType.VirtualPad)
        {
            _virtual_pad_key = virtual_pad_key;
        }
    }
}
