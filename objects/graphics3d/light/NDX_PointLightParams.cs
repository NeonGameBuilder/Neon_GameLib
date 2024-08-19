using System;

using NeonDX.Graphics3D.Util;

namespace NeonDX.Graphics3D.Light
{
    /**
     * 点光源パラメータ
     */
    public class NDX_PointLightParams
    {
        private NDX_Vector3D _center_pos = new NDX_Vector3D();

        private float _range = 0.0f;

        private float _atten0 = 0.0f;
        private float _atten1 = 0.0f;
        private float _atten2 = 0.0f;

        /**
         * 中心座標
         */
        public NDX_Vector3D CenterPosition
        {
            get { return _center_pos; }
            set { _center_pos = value; _center_pos.IsModified = true; }
        }

        /**
         * 範囲
         */
        public float Range
        {
            get { return _range; }
            set { _range = value; }
        }

        /**
         * 距離減衰パラメータ０
         */
        public float Atten0
        {
            get { return _atten0; }
            set { _atten0 = value; }
        }

        /**
         * 距離減衰パラメータ１
         */
        public float Atten1
        {
            get { return _atten1; }
            set { _atten1 = value; }
        }

        /**
         * 距離減衰パラメータ２
         */
        public float Atten2
        {
            get { return _atten2; }
            set { _atten2 = value; }
        }
    }
}
