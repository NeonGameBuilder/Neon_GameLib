using System;

namespace NeonDX
{
    /**
     * Neon初期化設定
     */
    public class NDX_SystemConfig
    {
        private bool _always_run;
        private bool _log_file_enabled;
        private bool _show_mouse_cursor;
        private bool _window_mode;

        /**
         * バックグラウンドでも実行する
         */
        public bool AlwaysRun
        {
            get { return _always_run; }
            set { _always_run = value; }
        }

        /**
         * ログを有効にする
         */
        public bool LogFileEnabled
        {
            get { return _log_file_enabled; }
            set { _log_file_enabled = value; }
        }

        /**
         * マウスカーソルを隠さない
         */
        public bool ShowMouseCursor
        {
            get { return _show_mouse_cursor; }
            set { _show_mouse_cursor = value; }
        }

        /**
         * ウィンドウモード
         */
        public bool WindowMode
        {
            get { return _window_mode; }
            set { _window_mode = value; }
        }

        /**
         * コンストラクタ
         */
        internal NDX_SystemConfig()
        {
            SetDefault();
        }

        /**
         * デフォルト設定
         */
        public void SetDefault()
        {
            // バックグラウンドでも実行する
            _always_run = true;

            // ログファイル有効
            _log_file_enabled = true;

            // ウィンドウ上にマウスを表示する
            _show_mouse_cursor = true;

            // ウィンドウモードで実行
            _window_mode = true;
        }
    }
}
