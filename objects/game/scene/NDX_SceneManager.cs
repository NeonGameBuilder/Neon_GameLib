using System.Collections.Generic;

namespace NeonDX.Game.Scene
{
    /**
     * シーン
     * 
     */
    public sealed class NDX_SceneManager : NDX_GraphicalObject
    {
        private Dictionary<int, NDX_Scene> _scenes_map = new Dictionary<int, NDX_Scene>();

        private int _active_scene_id = 0;

        /**
         * アクティブシーンID
         */
        public int ActiveSceneID
        {
            get { return _active_scene_id; }
            set { _active_scene_id = value; IsModified = true; }
        }

        /**
         * コンストラクタ
         */
        public NDX_SceneManager()
        {
        }

        /**
         * シーンを設定
         */
        public void SetScene(int key, NDX_Scene scene)
        {
            _scenes_map[key] = scene;
        }

        /**
         * 初期化
         */
        public override void Init()
        {
            // シーンの初期化
            foreach (var key in _scenes_map.Keys)
            {
                var scene = _scenes_map[key];
                scene.Init();
            }
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            // アクティブシーンの描画
            var scene = GetActiveScene();
            if (scene != null)
            {
                scene.Draw();
            }
        }

        /**
         * 更新
         */
        public override void Update()
        {
            // アクティブシーンの更新
            var scene = GetActiveScene();
            if (scene != null)
            {
                scene.Update();
            }
        }

        private NDX_Scene? GetActiveScene()
        {
            return _scenes_map.ContainsKey(_active_scene_id) ? _scenes_map[_active_scene_id] : null;
        }
    }
}
