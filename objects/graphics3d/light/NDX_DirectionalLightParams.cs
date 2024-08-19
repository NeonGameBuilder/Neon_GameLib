using System;

using NeonDX.Graphics3D.Util;

namespace NeonDX.Graphics3D.Light
{
    /**
     * 平行光源パラメータ
     */
    public class NDX_DirectionalLightParams
    {
        private NDX_Vector3D _direction = new NDX_Vector3D();

        /**
         * 方向
         */
        public NDX_Vector3D Direction
        {
            get { return _direction; }
            set { _direction = value; _direction.IsModified = true; }
        }

    }
}
