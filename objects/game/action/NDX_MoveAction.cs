using System;

namespace NeonDX.Game.Action
{
    /**
     * 移動アクション
     * 
     */
    public sealed class NDX_MoveAction : NDX_Action2D
    {
        private NDX_Vector2D _dir;

        /**
         * 方向ベクトル
         */
        public NDX_Vector2D Direction
        {
            get { return _dir; }
        }

        /**
         * コンストラクタ
         */
        public NDX_MoveAction(double dx, double dy)
        {
            _dir = new NDX_Vector2D(dx, dy);
        }
        public NDX_MoveAction(NDX_Vector2D vec)
        {
            _dir = new NDX_Vector2D(vec);
        }
    }
}
