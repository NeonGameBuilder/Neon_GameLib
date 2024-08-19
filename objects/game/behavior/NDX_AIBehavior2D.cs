using System;

using NeonDX.Game.Action;
using NeonDX.Game.AI;

namespace NeonDX.Game.Behavior
{
    /**
     * AIビヘイビア
     * 
     */
    public sealed class NDX_AIBehavior2D : NDX_Behavior2D
    {
        private NDX_AI2D _ai;

        /**
         * AI
         */
        public NDX_AI2D AI
        {
            get { return _ai; }
        }

        /**
         * コンストラクタ
         */
        public NDX_AIBehavior2D(NDX_AI2D ai) : base(EnumBehaviorType.AI)
        {
            _ai = ai;
        }

        /**
         * アクションを生成
         */
        public override NDX_Action2D Act()
        {
            return _ai.Act();
        }

        /**
         * 更新
         */
        public override void Update()
        {
            _ai.Update();
        }
    }
}
