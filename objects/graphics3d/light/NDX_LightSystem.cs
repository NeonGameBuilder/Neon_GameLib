
namespace NeonDX.Graphics3D.Light
{
    /**
     * 光源
     * 
     * 取得元： NDX_Graphics3D
     */
    public sealed class NDX_LightSystem
    {
        private bool _enabled = false;

        private bool _enabled_updated = false;

        private NDX_Color _global_ambient_color = NDX_Color.White;

        /**
         * 有効か
         */
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; _enabled_updated = true; }
        }

        /**
         * グローバルアンビエント光の色
         */
        public NDX_Color GlobalAmbientColor
        {
            get { return _global_ambient_color; }
            set { _global_ambient_color = value; _global_ambient_color.IsModified = true; }
        }

        /**
         * コンストラクタ
         */
        public NDX_LightSystem()
        {
        }

        /**
         * 更新
         */
        public void Update()
        {
            // 有効フラグ切り替え
            if (_enabled_updated)
            {
                NDX_API_Graphics3D.SetUseLighting(_enabled);
                _enabled_updated = false;
            }

            // グローバルアンビエント光の色
            if (_global_ambient_color.IsModified)
            {
                NDX_API_Graphics3D.SetGlobalAmbientLight(_global_ambient_color);
                _global_ambient_color.IsModified = false;
            }
        }
    }
}
