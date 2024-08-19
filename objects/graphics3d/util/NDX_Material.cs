
using NeonDX.Graphics3D.Model;

namespace NeonDX.Graphics3D.Util
{
    /**
     * マテリアル
     */
    public sealed class NDX_Material : NDX_Object
    {
        private int _index;
        private NDX_3DModel _model;

        private float _outline_width;
        private float _outline_dot_width;

        private bool _outline_width_updated = false;
        private bool _outline_dot_width_updated = false;


        /**
         * インデックス
         */
        public int Index
        {
            get { return _index; }
        }

        /**
         * 輪郭線の太さ
         */
        public float OutLineWidth
        {
            get { return _outline_width; }
            set { _outline_width = value; IsModified = true; _outline_width_updated = true; }
        }

        /**
         * 輪郭線のドット単位の太さ
         */
        public float OutlineDotWidth
        {
            get { return _outline_dot_width; }
            set { _outline_dot_width = value; IsModified = true; _outline_dot_width_updated = true; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Material(NDX_3DModel model, int index)
        {
            _model = model;
            _index = index;
        }

        /**
         * 更新
         */
        public override void Update()
        {
            if (!IsModified) return;

            // 輪郭線の太さを更新
            if (_outline_width_updated)
            {
                NDX_API_Graphics3D.MV1SetMaterialOutLineWidth(_model.Handle, _index, _outline_width);
                _outline_width_updated = false;
            }

            // 輪郭線のドット単位の太さを更新
            if (_outline_dot_width_updated)
            {
                NDX_API_Graphics3D.MV1GetMaterialNormalMapTexture(_model.Handle, _index);
                _outline_dot_width_updated = false;
            }

            IsModified = false;
        }
    }
}
