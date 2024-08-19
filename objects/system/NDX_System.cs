using System;
using System.Collections.Generic;

using NeonDX.System.Logger;

namespace NeonDX.System
{
    /**
     * システム
     * 
     * 取得元： NeonDX
     */
    public sealed class NDX_System : NDX_Object
    {
        private Dictionary<int, NDX_Logger> _loggers = new Dictionary<int, NDX_Logger>();
        private Dictionary<int, bool> _logger_status = new Dictionary<int, bool>();

        private NDX_LogHandler _log_handler;

        private NDX_DateTime _now = new NDX_DateTime();

        private NDX_Environment _env = new NDX_Environment();

        private NDX_SystemConfig _config = new NDX_SystemConfig();

        private NDX_ObjectManager _obj_mgr = new NDX_ObjectManager();

        /**
         * システム設定
         */
        public NDX_SystemConfig Config
        {
            get { return _config; }
        }

        /**
         * ログハンドラ
         */
        internal NDX_LogHandler LogHandler
        {
            get { return _log_handler; }
        }

        /**
         * 環境情報
         */
        public NDX_Environment Environment
        {
            get { return _env; }
        }

        /**
         * オブジェクトマネージャ
         */
        public NDX_ObjectManager ObjectManager
        {
            get { return _obj_mgr; }
        }

        /**
         * コンストラクタ
         */
        public NDX_System()
        {
            _log_handler = new NDX_LogHandler(_loggers);
        }

        /**
         * ロガーを設定
         */
        public void SetLogger(int channel, NDX_Logger logger)
        {
            _loggers[channel] = logger;
        }

        /**
         * ロガーを取得
         */
        public NDX_Logger? GetLogger(int channel)
        {
            return _loggers.ContainsKey(channel) ? _loggers[channel] : null;
        }

        /**
         * ロガーの有効・無効を設定
         */
        public void EnableLogger(int channel, bool enabled = true)
        {
            _logger_status[channel] = enabled;
        }

        /**
         * ロガーの有効・無効を取得
         */
        public bool IsLoggerEnabled(int channel)
        {
            return _logger_status.ContainsKey(channel) ? _logger_status[channel] : false;
        }

        /**
         * 乱数（int）
         */
        public int Rand(int max)
        {
            return NDX_API_Util.GetRand(max);
        }

        /**
         * 現在時刻を取得
         */
        public NDX_DateTime Now
        {
            get {
                NDX_API_Util.GetDateTime(_now);
                return _now;
            }
        }

        /**
         * DXライブラリ初期化
         */
        public override void Init()
        {
            // ログファイルを出力するか
            NDX_API_System.SetOutApplicationLogValidFlag(_config.LogFileEnabled);

            // バックグランドでも動作させるか
            NDX_API_System.SetAlwaysRunFlag(_config.AlwaysRun);

            //SetZBufferBitDepth(24);
            //SetCreateDrawValidGraphZBufferBitDepth(24);
            //SetFullSceneAntiAliasingMode(4, 2);
            //SetDrawValidMultiSample(4, 2);

            // DXライブラリの初期化
            NDX_API_System.DxLib_Init();

            // マウスカーソルを表示するか
            NDX_API_System.SetMouseDispFlag(_config.ShowMouseCursor);

            // ウィンドウモード
            NDX_API_Window.ChangeWindowMode(_config.WindowMode);

            // ウィンドウモードの場合、ウィンドウハンドルが指定されていれば設定
            if (_config.WindowMode && _config.UserWindow != 0)
            {
                SetUserWindow(_config.UserWindow);
            }

            // 環境情報
            _env.Init();
        }

        /**
         * 終了処理
         */
        public override void Terminate()
        {
            // DXライブラリの終了
            NDX_API_System.DxLib_End();
        }

        /**
         * 更新
         */
        public override void Update()
        {
            _env.Update();
        }

        /**
         * メインウィンドウテキストを変更
         */
        public void SetMainWindowText(string text)
        {
            NDX_API_Window.SetMainWindowText(text);
        }

        /**
         * ウィンドウのアイコンを変更
         */
        public void SetWindowIcon(int icon_id)
        {
            NDX_API_Window.SetWindowIconID(icon_id);
        }

        /**
         * ウィンドウモード変更
         */
        public EnumChangeScreenResult ChangeWindowMode(EnumWindowMode mode)
        {
            return NDX_API_Window.ChangeWindowMode(mode == EnumWindowMode.WindowedMode);
        }

        /**
         * ウィンドウメッセージ処理
         */
        public int ProcessMessage()
        {
            return NDX_API_Window.ProcessMessage();
        }

        /**
         * ウェイト
         */
        public void Wait(int msec)
        {
            NDX_API_Util.WaitTimer(msec);
        }

        /**
         * マウスカーソル表示
         */
        public void ShowMouseCursor(bool show = true)
        {
            NDX_API_System.SetMouseDispFlag(show);
        }

        /**
         * SetScreenFlipTargetWindow
         */
        public void SetScreenFlipTargetWindow(IntPtr hwnd, double scaleX, double scaleY)
        {
            NDX_API_Window.SetScreenFlipTargetWindow((IntPtr) hwnd, scaleX, scaleY);
        }

        /**
         * ユーザウィンドウ
         */
        public void SetUserWindow(IntPtr hwnd)
        {
            NDX_API_System.SetUserWindow(hwnd);
        }
    }
}
