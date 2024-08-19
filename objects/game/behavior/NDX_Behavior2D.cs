using System;

using NeonDX.Game.Action;

namespace NeonDX.Game.Behavior
{
    /**
     * ビヘイビア
     * 
     */
    public abstract class NDX_Behavior2D : NDX_Object
    {
        private EnumBehaviorType _behavior_type;

        /**
         * ビヘイビアタイプ
         */
        public EnumBehaviorType BehaviorType
        {
            get { return _behavior_type; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Behavior2D(EnumBehaviorType behavior_type)
        {
            _behavior_type = behavior_type;
        }

        /**
         * アクションを生成
         */
        public abstract NDX_Action2D Act();

    }
}
