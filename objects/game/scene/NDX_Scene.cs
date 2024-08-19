using System.Collections.Generic;

using NeonDX.Game.Agent;

namespace NeonDX.Game.Scene
{
    /**
     * シーン
     * 
     */
    public abstract class NDX_Scene : NDX_GraphicalObject
    {
        private Dictionary<int, NDX_Agent2D> _agents_map = new Dictionary<int, NDX_Agent2D>();

        /**
         * エージェント設定
         */
        public void SetAgent(int agent_id, NDX_Agent2D agent)
        {
            _agents_map[agent_id] = agent;
        }

        /**
         * エージェント取得
         */
        public NDX_Agent2D? GetAgent(int agent_id)
        {
            return _agents_map.ContainsKey(agent_id) ? _agents_map[agent_id] : null;
        }

        /**
         * 初期化
         */
        public override void Init()
        {
            // エージェントの初期化
            foreach (var key in _agents_map.Keys)
            {
                var agent = _agents_map[key];
                agent.Init();
            }
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            // エージェントの描画
            foreach (var key in _agents_map.Keys)
            {
                var agent = _agents_map[key];
                agent.Draw();
            }
        }

        /**
         * 更新
         */
        public override void Update()
        {
            // エージェントの更新
            foreach (var key in _agents_map.Keys)
            {
                var agent = _agents_map[key];
                agent.Update();
            }
        }
    }
}
