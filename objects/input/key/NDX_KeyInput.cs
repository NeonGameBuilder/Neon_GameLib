using System;

namespace NeonDX.Input.Key
{
    /**
     * キー入力
     * 
     */
    public abstract class NDX_KeyInput
    {
        private EnumKeyInputType _type;

        /**
         * キー入力タイプ
         */
        public EnumKeyInputType Type
        {
            get { return _type; }
        }

        /**
         * コンストラクタ
         */
        public NDX_KeyInput(EnumKeyInputType type)
        {
            _type = type;
        }
    }
}
