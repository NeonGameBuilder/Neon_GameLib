using System;

using NeonDX.Interfaces;
using NeonDX.Game.Behavior;

namespace NeonDX.Game.Agent
{
    /**
     * エージェント
     * 
     * 取得元： NDX_Game
     */
    public abstract class NDX_Agent2D : NDX_GraphicalObject, NDX_InputKeyFrameConsumer
    {
        private EnumAgentType _type;

        private NDX_InputKeyFrameProvider? _provider;

        private NDX_Behavior2D? _behavior;

        private NDX_Position2D _pos = new NDX_Position2D();

        /**
         * 位置
         */
        public NDX_Position2D Position
        {
            get { return _pos; }
        }

        /**
         * エージェントタイプ
         */
        public EnumAgentType AgentType
        {
            get { return _type; }
        }

        /**
         * ビヘイビア
         */
        public NDX_Behavior2D? Behavior
        {
            get { return _behavior; }
            set { _behavior = value; IsModified = true; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Agent2D(EnumAgentType type)
        {
            _type = type;
        }

        /**
         * キープロバイダに接続する。
         */
        public void ConnectToKeyProvider(NDX_InputKeyFrameProvider provider)
        {
            _provider = provider;
        }

        /**
         * 描画
         */
        public override void Draw()
        {
        }

        /**
         * 更新
         */
        public override void Update()
        {
        }
    }
}
