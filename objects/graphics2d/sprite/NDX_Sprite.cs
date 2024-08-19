using NeonDX.Graphics2D.Animation;

namespace NeonDX.Graphics2D.Sprite
{
    /**
     * スプライト
     * 
     */
    public sealed class NDX_Sprite : NDX_GraphicalObject
    {
        private NDX_Position2D _pos;

        private NDX_SpriteAnimation _animation = new NDX_SpriteAnimation();

        /**
         * 位置
         */
        public NDX_Position2D Position
        {
            get { return _pos; }
            set { _pos = value; IsModified = true; }
        }

        /**
         * アニメーション
         */
        public NDX_SpriteAnimation Animation
        {
            get { return _animation; }
            set { _animation = value; IsModified = true; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Sprite()
        {
            _pos = new NDX_Position2D();
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            _animation.Draw();
        }

        /**
         * 更新
         */
        public override void Update()
        {
            _animation.Position = _pos;
            _animation.Update();
        }
    }
}
