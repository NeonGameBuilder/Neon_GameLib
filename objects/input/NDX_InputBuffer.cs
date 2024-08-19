using System.Collections.Generic;

using NeonDX.Input.Key;

namespace NeonDX.Input
{
    /**
     * 入力バッファ
     * 
     * 取得元： NDX_Input
     * 
     * 物理入力デバイス（キーボード等）と仮想パッド、または仮想パッドとキャラクターコントローラーをつなぐ。
     * 
     * 　　≪物理入力デバイス≫→≪入力バッファ≫→≪仮想パッド≫
     * 　　≪仮想パッド≫→≪入力バッファ≫→≪キャラクターコントローラー≫
     * 　　
     * 入力バッファを多めに取ると、格闘ゲームのような連続コマンド入力を扱うことができる。バッファを少な目にすると
     * リアルタイム性が増す。
     */
    public sealed class NDX_InputBuffer : NDX_Object
    {
        private Queue<NDX_InputKeyFrame> _frame_buffer = new Queue<NDX_InputKeyFrame>();

        /**
         * キー入力フレームをキューから取り出さずに先頭のものを返す
         */
        public NDX_InputKeyFrame? PeekInputKeyFrame()
        {
            // キューが空の場合はnullを返す
            if (_frame_buffer.Count == 0) return null;

            // キーを取り出さずに返す
            return _frame_buffer.Peek();
        }

        /**
         * キー入力フレームをキューから取り出す
         */
        public NDX_InputKeyFrame? DequeueInputKeyFrame()
        {
            // キューが空の場合はnullを返す
            if (_frame_buffer.Count == 0) return null;

            // キーを取り出して返す
            return _frame_buffer.Dequeue();
        }

        /**
         * キー入力フレームをキューに入れる
         * 
         * 最大サイズがないため投入は常に成功する
         */
        public void EnqueueInputKeyFrame(NDX_InputKeyFrame frame)
        {
            // キーをキューに投入
            _frame_buffer.Enqueue(frame);
        }
    }
}
