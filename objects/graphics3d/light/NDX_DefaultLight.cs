using System;

namespace NeonDX.Graphics3D.Light
{
    /**
     * 標準光源
     * 
     * 取得元： NDX_Graphics3D
     */
    public sealed class NDX_DefaultLight : NDX_AbstractLight
    {
        /**
         * コンストラクタ
         */
        public NDX_DefaultLight() : base(0)
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
                NDX_API_Graphics3D.SetLightEnable(Enabled);
                EnabledUpdated = false;
            }

            // アンビエントカラー
            if (AmbientColor.IsModified)
            {
                NDX_API_Graphics3D.SetLightAmbColor(AmbientColor);
                AmbientColor.IsModified = false;
            }

            // ディフューズカラー
            if (DiffuseColor.IsModified)
            {
                NDX_API_Graphics3D.SetLightDifColor(DiffuseColor);
                DiffuseColor.IsModified = false;
            }

            // スペキュラーカラー
            if (SpecularColor.IsModified)
            {
                NDX_API_Graphics3D.SetLightSpcColor(SpecularColor);
                SpecularColor.IsModified = false;
            }

            // ライトタイプの変更
            if (LightType.IsModified)
            {
                switch(LightType.Type)
                {
                    case EnumLightType.DirectionalLight:
                        {
                            var p = DirectionalLightParams;
                            NDX_API_Graphics3D.ChangeLightTypeDir(p.Direction);
                        }
                        break;

                    case EnumLightType.Point:
                        {
                            var p = PointLightParams;
                            NDX_API_Graphics3D.ChangeLightTypePoint(p.CenterPosition, p.Range, p.Atten0, p.Atten1, p.Atten2);
                        }
                        break;

                    case EnumLightType.Spot:
                        {
                            var p = SpotLightParams;
                            NDX_API_Graphics3D.ChangeLightTypeSpot(p.CenterPosition, p.Direction, p.OutAngle, p.InAngle, p.Range, p.Atten0, p.Atten1, p.Atten2);
                        }
                        break;
                }
                LightType.IsModified = false;
            }
        }
    }
}
