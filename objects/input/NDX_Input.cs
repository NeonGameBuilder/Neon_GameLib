using System.Collections.Generic;

namespace NeonDX.Input 
{
    /**
     * 入力
     * 
     * 取得元： NeonDX
     */
    public sealed class NDX_Input : NDX_Object
    {
        private NDX_Keyboard _keyboard = new NDX_Keyboard();
        private NDX_VirtualPad _virtual_pad = new NDX_VirtualPad();

        private List<NDX_InputDevice> _devices = new List<NDX_InputDevice>();


        /**
         * キーボード
         */
        public NDX_Keyboard Keyboard
        {
            get { return _keyboard; }
        }

        /**
         * 仮想パッド
         */
        public NDX_VirtualPad VirtualPad
        {
            get { return _virtual_pad; }
        }

        /**
         * 入力デバイスを追加
         */
        public void AddInputDevice(NDX_InputDevice device)
        {
            _devices.Add(device);
        }
        public void AddInputDevice(NDX_InputDevice[] devices)
        {
            _devices.AddRange(devices);
        }

        /**
         * 更新
         */
        public override void Update()
        {
            foreach(var d in _devices)
            {
                d.Update();
            }
        }
    }
}
