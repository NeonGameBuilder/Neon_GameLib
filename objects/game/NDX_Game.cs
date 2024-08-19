using System;

using NeonDX.Game.World;
using NeonDX.Game.Scene;
using NeonDX.Interfaces;
using NeonDX.GameLoops;

namespace NeonDX.Game
{
    /**
     * ゲーム
     * 
     * 取得元： NeonDX
     */
    public sealed class NDX_Game : NDX_GraphicalObject
    {
        private NDX_World _world = new NDX_DefaultWorld();
        private NDX_SceneManager _scene_mgr = new NDX_SceneManager();
        private NDX_GameLoop _loop = new NDX_DefaultGameLoop();

        /**
         * ワールド
         */
        public NDX_World World
        {
            get { return _world; }
            set { _world = value; IsModified = true; }
        }

        /**
         * シーンマネージャ
         */
        public NDX_SceneManager SceneManager
        {
            get { return _scene_mgr; }
        }

        /**
         * ゲームループ
         */
        public NDX_GameLoop GameLoop
        {
            get { return _loop; }
            set { _loop = value; }
        }

        /**
         * コンストラクタ
         */
        public NDX_Game()
        {
        }

        /**
         * 初期化
         */
        public override void Init()
        {
            // シーンの初期化
            _scene_mgr.Init();
        }

        /**
         * 開始
         */
        public void Start()
        {
            _loop.DoLoop();
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            // シーンの描画
            _scene_mgr.Draw();
        }

        /**
         * 更新
         */
        public override void Update()
        {
            // シーンの更新
            _scene_mgr.Update();
        }
    }
}
