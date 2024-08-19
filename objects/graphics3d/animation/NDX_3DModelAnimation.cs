using System;

using NeonDX.Graphics3D.Model;

namespace NeonDX.Graphics3D.Animation
{
    /**
     * アニメーション
     */
    public sealed class NDX_3DModelAnimation : NDX_Object
    {
        private NDX_3DModel _model;
        private int _attach_index;
        private float _length;

        private int _current_frame;
        private float _speed;

        private bool _current_frame_updated = false;
        private bool _speed_updated = false;

        /**
         * アニメーション長（総時間）
         */
        public float Length
        {
            get { return _length; }
        }

        /**
         * アニメーションスピード
         */
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; _speed_updated = true; IsModified = true; }
        }

        /**
         * 現在の表示フレーム
         */
        public int CurrentFrame
        {
            get { return _current_frame; }
            set { 
                _current_frame = value;
                _current_frame_updated = true;
                IsModified = true;
            }
        }

        /**
         * コンストラクタ
         */
        public NDX_3DModelAnimation(NDX_3DModel model, int attach_index, float length)
        {
            _model = model;
            _attach_index = attach_index;
            _length = length;

            _current_frame = 0;
            _speed = 0.1f;
        }

        /**
         * 更新
         */
        public override void Update()
        {
            if (!IsModified) return;

            if (_current_frame_updated || _speed_updated)
            {
                float current_frame_time = _current_frame * _speed;
                if (current_frame_time > _length || current_frame_time < 0)
                {
                    _current_frame = 0;
                }

                // フレームを適用
                NDX_API_Graphics3D.MV1SetAttachAnimTime(_model.Handle, _attach_index, current_frame_time);

                _current_frame_updated = false;
                _speed_updated = false;
            }


            IsModified = false;
        }
    }
}
