using System;

namespace NeonDX.Input.Key
{
    /**
     * 物理入力キー
     * 
     */
    public sealed class NDX_PhysicalKey : NDX_KeyInput
    {
        private EnumPhysicalKey _physical_key;

        /**
         * 物理入力キー
         */
        public EnumPhysicalKey PhysicalKey
        {
            get { return _physical_key; }
        }

        /**
         * コンストラクタ
         */
        public NDX_PhysicalKey(EnumPhysicalKey physical_key) : base(EnumKeyInputType.Physical)
        {
            _physical_key = physical_key;
        }
    }
}
