using System;

using NeonDX.Graphics3D.Light;

namespace NeonDX.Graphics3D
{
    /**
     * ３次元グラフィックス
     * 
     * 取得元： NeonDX
     */
    public sealed class NDX_Graphics3D
    {
        private readonly float PI = 3.14159265359f;

        private NDX_Camera _camera = new NDX_Camera();
        private NDX_LightSystem _light_system = new NDX_LightSystem();
        private NDX_DefaultLight _def_light = new NDX_DefaultLight();

        /**
         * カメラ
         */
        public NDX_Camera Camera
        {
            get { return _camera; }
        }

        /**
         * 光源
         */
        public NDX_LightSystem LightSystem
        {
            get { return _light_system; }
        }

        /**
         * 標準光源
         */
        public NDX_DefaultLight DefaultLight
        {
            get { return _def_light; }
        }

        /**
         * 角度
         * 
         * @param int degree       角度（度）
         */
        public float DegreeToRadian(int degree)
        {
            return degree / 360.0f * PI * 2;
        }

    }
}
