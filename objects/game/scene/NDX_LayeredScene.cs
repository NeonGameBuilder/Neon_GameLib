using System.Collections.Generic;

using NeonDX.Game.Layer;

namespace NeonDX.Game.Scene
{
    /**
     * レイヤードシーン
     * 
     */
    public sealed class NDX_LayeredScene : NDX_Scene
    {
        private List<NDX_Layer> _layers = new List<NDX_Layer>();

        /**
         * レイヤーを追加
         */
        public void AddLayer(NDX_Layer layer)
        {
            _layers.Add(layer);
        }

        /**
         * 初期化
         */
        public override void Init()
        {
            base.Init();

            foreach (var l in _layers)
            {
                l.Init();
            }
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            base.Draw();

            foreach (var l in _layers)
            {
                l.Draw();
            }
        }

        /**
         * 更新
         */
        public override void Update()
        {
            base.Update();

            foreach (var l in _layers)
            {
                l.Update();
            }
        }
    }
}
