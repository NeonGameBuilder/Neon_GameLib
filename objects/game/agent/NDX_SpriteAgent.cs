using System;

using NeonDX.Graphics2D.Sprite;

namespace NeonDX.Game.Agent
{
    /**
     * スプライトエージェント
     * 
     * 取得元： NDX_Game
     */
    public sealed class NDX_SpriteAgent : NDX_Agent2D
    {
        private NDX_Sprite _sprite = new NDX_Sprite();

        /**
         * コンストラクタ
         */
        public NDX_SpriteAgent(EnumAgentType type)
            : base(type)
        {
        }

        /**
         * スプライトアニメーションをロード
         */
        public void LoadSpriteSheet(NDX_SpriteSheetInfo si)
        {
            _sprite.Animation.SpriteSheet = NeonDX.Graphics2D.LoadSpriteSheet(si);
        }

        /**
         * 初期化
         */
        public override void Init()
        {
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            _sprite.Draw();
        }

        /**
         * 更新
         */
        public override void Update()
        {
            _sprite.Position = Position;
            _sprite.Update();
        }
    }
}
