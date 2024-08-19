using System;

namespace NeonDX.Game.World
{
    /**
     * 重力あり3Dワールド
     * 
     */
    public sealed class NDX_Physics3DWorld : NDX_World
    {
        /**
         * コンストラクタ
         */
        public NDX_Physics3DWorld() : base(EnumWorldType.Physics3D)
        {
        }
    }
}
