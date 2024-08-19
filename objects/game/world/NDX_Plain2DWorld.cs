using System;

namespace NeonDX.Game.World
{
    /**
     * 重力なし2Dワールド
     * 
     */
    public sealed class NDX_Plain2DWorld : NDX_World
    {
        /**
         * コンストラクタ
         */
        public NDX_Plain2DWorld() : base(EnumWorldType.Plain2D)
        {
        }
    }
}
