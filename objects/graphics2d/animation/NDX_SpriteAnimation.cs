
using NeonDX.Graphics2D.Sprite;

namespace NeonDX.Graphics2D.Animation
{
    /**
     * スプライトアニメーション
     * 
     */
    public sealed class NDX_SpriteAnimation : NDX_GraphicalObject
    {
        private const int DEFAULT_ANIMATION_SPEED = 10;     // １アニメーションフレームを描画する実フレーム数

        private NDX_Position2D _pos = new NDX_Position2D();

        private NDX_SpriteSheet? _sheet;

        private EnumAnimationOrder _animation_order = EnumAnimationOrder.Cyclic;

        private bool _alpha_enabled = true;

        private int _current_animation_frame;
        private EnumRoundTripDirection _roundtrip_direction;

        private int _animation_speed = DEFAULT_ANIMATION_SPEED;
        private int _animation_counter;

        /**
         * 位置
         */
        public NDX_Position2D Position
        {
            get { return _pos; }
            set { _pos = value; IsModified = true; }
        }

        /**
         * スプライトシート
         */
        public NDX_SpriteSheet? SpriteSheet
        {
            get { return _sheet; }
            set { _sheet = value; IsModified = true; }
        }

        /**
         * アニメーション再生方法
         */
        public EnumAnimationOrder AnimationOrder
        {
            get { return _animation_order; }
            set
            {
                _animation_order = value;
                IsModified = true;
                _roundtrip_direction = EnumRoundTripDirection.OutwardTrip;
            }
        }

        /**
         * アニメーションスピード（描画フレーム数）
         */
        public int AnimationSpeed
        {
            get { return _animation_speed; }
            set { _animation_speed = value; _animation_counter = 0; IsModified = true; }
        }

        /**
         * 透明度（アルファチャンネル）が有効か
         */
        public bool IsAlphaEnabled
        {
            get { return _alpha_enabled; }
            set { _alpha_enabled = value; IsModified = true; }
        }

        /**
         * 往復方向
         */
        public EnumRoundTripDirection RoundTripDirection
        {
            get { return _roundtrip_direction; }
        }

        /**
         * アニメーション
         */
        private void Animate()
        {
            if (_sheet == null) return;

            // 特定の描画フレーム数まで待つ
            _animation_counter++;
            if (_animation_counter < _animation_speed) return;

            _animation_counter = 0;

            // フレーム更新
            switch (_animation_order)
            {
                case EnumAnimationOrder.Cyclic:
                    {
                        _current_animation_frame++;
                        if (_current_animation_frame >= _sheet.FrameCount) _current_animation_frame = 0;
                    }
                    break;

                case EnumAnimationOrder.RoundTrip:
                    {
                        switch (_roundtrip_direction)
                        {
                            /** 往路 */
                            case EnumRoundTripDirection.OutwardTrip:
                                {
                                    _current_animation_frame++;
                                    if (_current_animation_frame >= _sheet.FrameCount)
                                    {
                                        _current_animation_frame = _sheet.FrameCount - 2;
                                        _roundtrip_direction = EnumRoundTripDirection.ReturnTrip;
                                    }
                                }
                                break;

                            /* 復路 */
                            case EnumRoundTripDirection.ReturnTrip:
                                {
                                    _current_animation_frame++;
                                    if (_current_animation_frame < 0)
                                    {
                                        _current_animation_frame = 1;
                                        _roundtrip_direction = EnumRoundTripDirection.OutwardTrip;
                                    }
                                }
                                break;
                        }
                    }
                    break;
            }
        }
        /**
         * 更新
         */
        public override void Update()
        {
            if (!IsModified) return;

            // アニメーション
            Animate();

            IsModified = false;
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            var frame = _sheet?.GetFrame(_current_animation_frame);

            if (frame != null)
            {
                NeonDX.Graphics2D.DrawSpriteFrame(frame, _pos, _alpha_enabled);
            }
        }
    }
}
