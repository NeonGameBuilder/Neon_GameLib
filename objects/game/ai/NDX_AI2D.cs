using System;

using NeonDX.Game.Agent;
using NeonDX.Game.Scene;
using NeonDX.Game.Action;

namespace NeonDX.Game.AI
{
    /**
     * AI
     * 
     */
    public abstract class NDX_AI2D : NDX_Object
    {
        private NDX_Agent2D _agent;
        private NDX_Scene _scene;

        /**
         * 操作対象エージェント
         */
        public NDX_Agent2D Agent
        {
            get { return _agent; }
        }

        /**
         * AI、エージェントが存在するシーン
         */
        public NDX_Scene Scene
        {
            get { return _scene; }
        }

        /**
         * コンストラクタ
         */
        public NDX_AI2D(NDX_Agent2D agent, NDX_Scene scene)
        {
            _agent = agent;
            _scene = scene;
        }

        /**
         * アクションを生成する
         */
        public abstract NDX_Action2D Act();
    }
}
