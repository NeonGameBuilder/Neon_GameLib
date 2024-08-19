using System;

namespace NeonDX.Game.World
{
    /**
     * 重力あり2Dワールド
     * 
     */
    public sealed class NDX_Physics2DWorld : NDX_World
    {
        /**
         * コンストラクタ
         */
        public NDX_Physics2DWorld() : base(EnumWorldType.Physics2D)
        {
        }
    }
}
