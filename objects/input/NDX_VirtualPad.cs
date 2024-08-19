using System;

using NeonDX.Input.Key;
using NeonDX.Interfaces;

namespace NeonDX.Input
{
    /**
     * 仮想パッド
     * 
     * 取得元： NDX_Input
     * 
     * 入力は物理キーボードの入力を直接判定せず、仮想パッドの入力を判定する。
     * 仮想パッドの入力テーブルを変更することもできる。
     */
    public sealed class NDX_VirtualPad : NDX_InputDevice, NDX_InputKeyFrameConsumer, NDX_InputKeyFrameProvider
    {
        private NDX_InputBuffer _internal_buffer = new NDX_InputBuffer();

        private NDX_VirtualPadKeyMap _keymap = new NDX_VirtualPadKeyMap();

        private NDX_InputKeyFrameProvider? _provider;

        /**
         * 内部入力バッファ
         */
        public NDX_InputBuffer InternalBuffer
        {
            get { return _internal_buffer; }
        }

        /**
         * キーマップ
         */
        public NDX_VirtualPadKeyMap KeyMap
        {
            get { return _keymap; }
        }

        /**
         * キープロバイダに接続する。
         */
        public void ConnectToKeyProvider(NDX_InputKeyFrameProvider provider)
        {
            _provider = provider;
        }

        /**
         * キーを供給する。供給するキーがない場合はnullを返す。
         */
        public NDX_InputKeyFrame? ProvideInputKeyFrame()
        {
            return _internal_buffer.DequeueInputKeyFrame();
        }

        /**
         * 更新
         */
        public override void Update()
        {
            // キー入力プロバイダに接続されていなければ何もしない
            if (_provider == null) return;

            // キー入力フレームを１つ読み込む
            var next_frame = _provider.ProvideInputKeyFrame();

            // キー入力フレームがなければ終了
            if (next_frame == null) return;

            // フレーム内のキーをすべて処理
            var internal_frame = new NDX_InputKeyFrame();

            foreach(var key in next_frame.Items)
            {
                // 入力されたキーが物理キーであるか確認
                if (!(key is NDX_PhysicalKey))
                {
                    throw new NDX_InputKeyException($"Virtual Pad accepts only physical keys! Received: {key}");
                }

                // 入力された物理キーを取得
                var physical_key = (key as NDX_PhysicalKey)?.PhysicalKey ?? EnumPhysicalKey.Key_Unknown;

                // キーマップにより物理キーを仮想パッドキーに変換
                var virtual_key = _keymap.GetVirtualPadKey(physical_key);

                // 変換された仮想キーがあれば返還後の仮想キーを内部バッファに保存
                if (virtual_key != EnumVirtualPadKey.Unknown)
                {
                    internal_frame.AddInputKey(new NDX_VirtualPadKey(virtual_key));
                }
            }

            _internal_buffer.EnqueueInputKeyFrame(internal_frame);
        }
    }
}
