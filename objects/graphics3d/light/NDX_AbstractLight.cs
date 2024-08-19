using System;

namespace NeonDX.Graphics3D.Light
{
    /**
     * 光源
     * 
     */
    public abstract class NDX_AbstractLight
    {
        private int _handle;

        private bool _enabled = false;

        private bool _enabled_updated = false;

        private NDX_Color _ambient_color = NDX_Color.White;
        private NDX_Color _diffuse_color = NDX_Color.White;
        private NDX_Color _specular_color = NDX_Color.White;

        private NDX_LightType _light_type = new NDX_LightType(EnumLightType.DirectionalLight);

        private NDX_DirectionalLightParams _dir_light_params = new NDX_DirectionalLightParams();
        private NDX_PointLightParams _point_light_params = new NDX_PointLightParams();
        private NDX_SpotLightParams _spot_light_params = new NDX_SpotLightParams();

        /**
         * ハンドル
         */
        protected int Handle
        {
            get { return _handle; }
        }

        /**
         * 有効フラグ
         */
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; _enabled_updated = true; }
        }

        /**
         * 有効フラグが更新されたか
         */
        protected bool EnabledUpdated
        {
            get { return _enabled_updated; }
            set { _enabled_updated = value; }
        }

        /**
         * アンビエントカラー
         */
        public NDX_Color AmbientColor
        {
            get { return _ambient_color; }
            set { _ambient_color = value; _ambient_color.IsModified = true; }
        }

        /**
         * ディヒューズカラー
         */
        public NDX_Color DiffuseColor
        {
            get { return _diffuse_color; }
            set { _diffuse_color = value; _diffuse_color.IsModified = true; }
        }

        /**
         * スペキュラーカラー
         */
        public NDX_Color SpecularColor
        {
            get { return _specular_color; }
            set { _specular_color = value; _specular_color.IsModified = true; }
        }

        /**
         * ライトタイプ
         */
        public NDX_LightType LightType
        {
            get { return _light_type; }
            set { _light_type = value; _light_type.IsModified = true; }
        }

        /**
         * 平行光源パラメータ
         */
        public NDX_DirectionalLightParams DirectionalLightParams
        {
            get { return _dir_light_params; }
        }

        /**
         * 点光源パラメータ
         */
        public NDX_PointLightParams PointLightParams
        {
            get { return _point_light_params; }
        }

        /**
         * スポット光源パラメータ
         */
        public NDX_SpotLightParams SpotLightParams
        {
            get { return _spot_light_params; }
        }

        /**
         * コンストラクタ
         */
        public NDX_AbstractLight(int handle)
        {
            _handle = handle;
        }

        /**
         * 更新
         */
        public abstract void Update();
    }
}
