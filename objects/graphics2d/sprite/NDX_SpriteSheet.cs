using System.Collections.Generic;

namespace NeonDX.Graphics2D.Sprite
{
    /**
     * スプライトシート
     */
    public sealed class NDX_SpriteSheet
    {
        private List<NDX_SpriteFrame> _frames = new List<NDX_SpriteFrame>();
        private NDX_Size2D _frame_size;

        /**
         * フレーム数
         */
        public int FrameCount
        {
            get { return _frames.Count; }
        }

        /**
         * フレームサイズ
         */
        public NDX_Size2D FrameSize
        {
            get { return _frame_size; }
        }

        /**
         * フレーム
         */
        public NDX_SpriteFrame? GetFrame(int index)
        {
            return (index >= 0) && (index < _frames.Count) ? _frames[index] : null;
        }

        /**
         * コンストラクタ
         */
        public NDX_SpriteSheet(List<NDX_SpriteFrame> frames, int sx, int sy)
        {
            _frames.AddRange(frames);
            _frame_size = new NDX_Size2D(sx, sy);
        }
        public NDX_SpriteSheet(List<NDX_SpriteFrame> frames, NDX_Size2D frame_size)
        {
            _frames.AddRange(frames);
            _frame_size = new NDX_Size2D(frame_size);
        }
    }
}
