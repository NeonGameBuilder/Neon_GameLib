using System;
using System.Collections.Generic;

namespace NeonDX.Game.Layer
{
    /**
     * レイヤー
     * 
     */
    public abstract class NDX_Layer : NDX_GraphicalObject
    {
        private List<NDX_GraphicalObject> _graph_objects = new List<NDX_GraphicalObject>();

        /**
         * レイヤーにグラフィカルオブジェクトを追加
         */
        public void Add(NDX_GraphicalObject graphicalObject)
        {
            _graph_objects.Add(graphicalObject);
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            foreach(var o in _graph_objects)
            {
                o.Draw();
            }
        }

    }
}
