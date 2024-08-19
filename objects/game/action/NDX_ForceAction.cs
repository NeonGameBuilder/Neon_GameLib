using System;

namespace NeonDX.Game.Action
{
    /**
     * 力を加えるアクション
     * 
     */
    public sealed class NDX_ForceAction : NDX_Action2D
    {
        private NDX_Vector2D _dir;
        private double _force;

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
        public NDX_ForceAction(double dx, double dy, double force)
        {
            _dir = new NDX_Vector2D(dx, dy);
            _force = force;
        }
        public NDX_ForceAction(NDX_Vector2D vec, double force)
        {
            _dir = new NDX_Vector2D(vec);
            _force = force;
        }
    }
}
