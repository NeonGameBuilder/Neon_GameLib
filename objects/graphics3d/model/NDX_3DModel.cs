using System;
using System.Collections.Generic;

using NeonDX.Graphics3D.Animation;
using NeonDX.Graphics3D.Util;

namespace NeonDX.Graphics3D.Model
{
    /**
     * ３次元モデル
     * 
     * 取得元： NDX_Graphics3D
     */
    public sealed class NDX_3DModel : NDX_GraphicalObject
    {
        private NDX_Vector3D _pos = new NDX_Vector3D();
        private NDX_Vector3D _scale = new NDX_Vector3D(1.0f, 1.0f, 1.0f);
        private NDX_Vector3D _rot = new NDX_Vector3D();

        private List<NDX_Material> _materials = new List<NDX_Material>();

        private int _anime_cnt = 0;

        private List<NDX_3DModelAnimationInfo> _anim_infos = new List<NDX_3DModelAnimationInfo>();

        /**
         * 位置
         */
        public NDX_Vector3D Position
        {
            get { return _pos; }
        }

        /**
         * 拡大値
         */
        public NDX_Vector3D Scale
        {
            get { return _scale; }
        }

        /**
         * 	モデルの回転値をセットする
         */
        public NDX_Vector3D Rotation
        {
            get { return _rot; }
        }

        /**
         * マテリアル（コレクション）
         */
        public List<NDX_Material> Materials
        {
            get { return _materials; }
        }

        /**
         * アニメーション数
         */
        public int AnimationCount
        {
            get { return _anime_cnt; }
        }

        /**
         * アニメーション情報（コレクション）
         */
        public List<NDX_3DModelAnimationInfo> AnimationInfos
        {
            get { return _anim_infos; }
        }

        /**
         * コンストラクタ
         */
        public NDX_3DModel(NDX_Handle handle)
        {
            // マテリアルコレクションを作成
            int material_cnt = NDX_API_Graphics3D.MV1GetMaterialNum(handle);

            for (int i = 0; i < material_cnt; i++)
            {
                _materials.Add(new NDX_Material(this, i));
            }

            // アニメーション数を取得
            int anime_cnt = NDX_API_Graphics3D.MV1GetAnimNum(handle);
            _anime_cnt = anime_cnt;

            // アニメーション情報を取得
            for (int i = 0; i < _anime_cnt; i++)
            {
                string name = NDX_API_Graphics3D.MV1GetAnimName(handle, i);
                float length = NDX_API_Graphics3D.MV1GetAnimTotalTime(handle, i);
                _anim_infos.Add(new NDX_3DModelAnimationInfo(i, name, length));
            }
        }

        /**
         * ファイルからモデルの読み込み
         */
        public static NDX_3DModel LoadFromFile(string filename)
        {
            var model_handle = NDX_API_Graphics3D.MV1LoadModel(filename);

            return new NDX_3DModel(model_handle);
        }

        /**
         * アニメーションをアタッチ
         */
        public NDX_3DModelAnimation AttachAnimation(int index)
        {
            int attach_index = NDX_API_Graphics3D.MV1AttachAnim(Handle, index, -1, false);

            // アニメーション長を取得
            float length = NDX_API_Graphics3D.MV1GetAttachAnimTotalTime(Handle, attach_index);

            // アニメーションを作成
            return new NDX_3DModelAnimation(this, attach_index, length);
        }

        /**
         * モデルの位置を更新
         */
        public override void Update()
        {
            // 位置を更新
            if (_pos.IsModified)
            {
                NDX_API_Graphics3D.MV1SetPosition(Handle, _pos);
                _pos.IsModified = false;
            }

            // 拡大値を更新
            if (_scale.IsModified)
            {
                NDX_API_Graphics3D.MV1SetScale(Handle, _scale);
                _scale.IsModified = false;
            }

            // 回転値を更新
            if (_rot.IsModified)
            {
                NDX_API_Graphics3D.MV1SetRotationXYZ(Handle, _rot);
                _rot.IsModified = false;
            }

            // マテリアルを更新
            foreach(var m in _materials)
            {
                if (m.IsModified)
                {
                    m.Update();
                }
            }
        }

        /**
         * モデルを描画
         */
        public override void Draw()
        {
            NDX_API_Graphics3D.MV1DrawModel(Handle);
        }

        /**
         * 破棄
         */
        public override void Terminate()
        {
            if (Handle != null)
            {
                NDX_API_Graphics3D.MV1DeleteModel(Handle);
            }

            base.Terminate();
        }
    }
}
