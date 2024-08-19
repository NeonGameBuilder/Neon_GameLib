using System;

namespace NeonDX
{
    /**
     * カメラ
     * 
     * 取得元： NDX_Graphics3D
     */
    public sealed class NDX_Camera
    {
        private NDX_Vector3D _pos = new NDX_Vector3D();
        private NDX_Vector3D _up = new NDX_Vector3D();

        private float _clip_near;
        private float _clip_far;

        private bool _clip_near_updated = false;
        private bool _clip_far_updated = false;

        /**
         * 位置
         */
        public NDX_Vector3D Position
        {
            get { return _pos; }
        }

        /**
         * 向き
         */
        public NDX_Vector3D Up
        {
            get { return _up; }
        }

        /**
         * クリップ距離（近）
         */
        public float ClipNear
        {
            get { return _clip_near; }
            set { _clip_near = value; _clip_near_updated = true; }
        }

        /**
         * クリップ距離（遠）
         */
        public float ClipFar
        {
            get { return _clip_far; }
            set { _clip_far = value; _clip_far_updated = true; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Camera()
        {
        }

        /**
         * 更新
         */
        public void Update()
        {
            // カメラの位置と向きを更新
            if (_pos.IsModified)
            {
                NDX_API_Graphics3D.SetCameraPositionAndTarget_UpVecY(_pos, _up);
                _pos.IsModified = false;
            }

            // クリップ距離を更新
            if (_clip_near_updated || _clip_far_updated)
            {
                NDX_API_Graphics3D.SetCameraNearFar(_clip_near, _clip_far);
                _clip_near_updated = _clip_far_updated = false;
            }
        }
    }
}
