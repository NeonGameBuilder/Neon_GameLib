using System;
using System.Collections.Generic;

namespace NeonDX.Input.Key
{
    /**
     * 入力キーフレーム
     * 
     * １フレームに入力されたキーセット
     * 
     */
    public sealed class NDX_InputKeyFrame
    {
        private List<NDX_KeyInput> _items = new List<NDX_KeyInput>();

        /**
         * 入力キーのリスト
         */
        public List<NDX_KeyInput> Items
        {
            get { return _items; }
        }

        /**
         * キー入力を追加
         */
        public void AddInputKey(NDX_KeyInput ki)
        {
            _items.Add(ki);
        }
    }
}
