using System.Collections.Generic;

using NeonDX.Input.Key;
using NeonDX.Interfaces;

namespace NeonDX.Input
{
    /**
     * キーボード
     * 
     * 取得元： NDX_Input
     */
    public sealed class NDX_Keyboard : NDX_InputDevice, NDX_InputKeyFrameProvider
    {
        private NDX_InputBuffer _internal_buffer = new NDX_InputBuffer();

        private List<EnumPhysicalKey> _listen_keys = new List<EnumPhysicalKey>();

        /**
         * 内部入力バッファ
         */
        public NDX_InputBuffer InternalBuffer
        {
            get { return _internal_buffer; }
        }

        /**
         * 監視キー追加
         */
        public NDX_Keyboard AddListenKey(EnumPhysicalKey key)
        {
            _listen_keys.Add(key);
            return this;
        }
        public void AddListenKeys(params EnumPhysicalKey[] keys)
        {
            _listen_keys.AddRange(keys);
        }

        /**
         * キーを供給する。供給するキーがない場合はnullを返す。
         */
        public NDX_InputKeyFrame? ProvideInputKeyFrame()
        {
            return _internal_buffer?.DequeueInputKeyFrame();
        }

        /**
         * 更新
         */
        public override void Update()
        {
            // すべてのキーをチェックして結果を押されたキーの情報を入力バッファに送信する
            byte[] key_states = new byte[256];

            NDX_API_Input.GetHitKeyStateAll(key_states);

            // １つずつチェック
            var ki_frame = new NDX_InputKeyFrame();
            foreach(var k in _listen_keys)
            {
                if (key_states[(int)k] == 1)
                {
                    // 押されている
                    var input_key = new NDX_PhysicalKey(k);
                    ki_frame.AddInputKey(input_key);
                }
            }
            _internal_buffer.EnqueueInputKeyFrame(ki_frame);
        }

        /**
         * 	入力が終了しているか取得する
         */
        public int CheckKeyInput(int input_handle)
        {
            return NDX_API_Input.CheckKeyInput(input_handle);
        }

        /**
         * 特定キーの入力状態を得る
         */
        public bool CheckHitKey(EnumPhysicalKey key)
        {
            return NDX_API_Input.CheckHitKey((int)key);
        }


    }
}
