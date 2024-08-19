using System;

namespace NeonDX.Game.World
{
    /**
     * ワールド
     * 
     */
    public abstract class NDX_World : NDX_Object
    {
        private EnumWorldType _type;

        /**
         * ワールドタイプ
         */
        public EnumWorldType Type
        {
            get { return _type; }
        }

        /**
         * Default
         */
        public static NDX_World Default
        {
            get { return new NDX_DefaultWorld(); }
        }

        /**
         * コンストラクタ
         */
        public NDX_World(EnumWorldType type)
        {
            _type = type;
        }
    }
}
