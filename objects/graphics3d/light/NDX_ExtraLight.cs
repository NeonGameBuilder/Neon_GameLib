using System;

namespace NeonDX.Graphics3D.Light
{
    /**
     * 拡張光源
     * 
     */
    public sealed class NDX_ExtraLight : NDX_AbstractLight
    {
        /**
         * コンストラクタ
         */
        public NDX_ExtraLight(int handle) : base(handle)
        {
        }

        /**
         * 更新
         */
        public override void Update()
        {
            // 有効フラグ切り替え
            if (EnabledUpdated)
            {
                NDX_API_Graphics3D.SetLightEnableHandle(Handle, Enabled);
                EnabledUpdated = false;
            }

            // アンビエント光の色
            if (AmbientColor.IsModified)
            {
                NDX_API_Graphics3D.SetLightAmbColorHandle(Handle, AmbientColor);
                AmbientColor.IsModified = false;
            }

            // ライトタイプの変更
            if (LightType.IsModified)
            {
                NDX_API_Graphics3D.SetLightTypeHandle(Handle, LightType);
                LightType.IsModified = false;
            }
        }
    }
}
