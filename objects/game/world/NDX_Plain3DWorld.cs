using System;

namespace NeonDX.Game.World
{
    /**
     * 重力なし3Dワールド
     * 
     */
    public sealed class NDX_Plain3DWorld : NDX_World
    {
        /**
         * コンストラクタ
         */
        public NDX_Plain3DWorld() : base(EnumWorldType.Plain3D)
        {
        }
    }
}
