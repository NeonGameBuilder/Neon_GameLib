using System;

namespace NeonDX.Graphics
{
    /**
     * FPS
     * 
     * 取得元： NDX_Graphics
     */
    public sealed class NDX_FPS
    {
        private const float ONE_SECOND_FOR_MICROSECOND = 1000 * 1000;
        private const int DEFAULT_UPDATE_FREQUENCY = 1000;        // デフォルトのFPS更新頻度（1秒ごと）

        private float _fps = 0.0f;
        private long _last_updated_time;
        private long _last_started_time;
        private int _frame_count;
        private long _total_process_time;

        private int _update_frequency = DEFAULT_UPDATE_FREQUENCY;

        /**
         * FPS値（リアル）
         */
        public float FrameRate
        {
            get { return _fps; }
        }

        /**
         * FPS値（DXライブラリ内部）
         */
        public float FrameRateDx
        {
            get { return NDX_API_Util.GetFPS(); }
        }

        /**
         * 更新頻度（ミリ秒）
         */
        public int UpdateFrequency
        {
            get { return _update_frequency; }
        }

        /**
         * コンストラクタ
         */
        public NDX_FPS()
        {
            Reset();
        }

        /**
         * リセット
         */
        public void Reset()
        {
            _fps = 0.0f;
            _last_updated_time = 0;
            _last_started_time = 0;
            _frame_count = 0;
            _total_process_time = 0;
        }

        /**
         * 処理開始
         * 
         * ※フレームレートはStartFpsProcess()～EndFpsProcess()までの間を計測する
         */
        public void StartFpsProcess()
        {
            _last_started_time = NDX_API_Util.GetNowHiPerformanceCount();
            _frame_count++;
        }

        /**
         * 処理終了
         * 
         * ※フレームレートはStartFpsProcess()～EndFpsProcess()までの間を計測する
         */
        public void EndFpsProcess()
        {
            // このフレームの処理時間を加算
            _total_process_time += NDX_API_Util.GetNowHiPerformanceCount() - _last_started_time;

            // FPS更新処理
            Update();
        }

        /**
         * FPS更新処理
         */
        private void Update()
        {
            // 前回のFPS更新時刻から所定の時間が経過したか
            long now_time = NDX_API_Util.GetNowHiPerformanceCount();
            if (now_time - _last_updated_time < _update_frequency * 1000) return;

            // FPSの計算（総処理時間÷所要フレーム数で平均処理時間を計算し、１秒で割る）
            long ave_process_time = _frame_count > 0 ? _total_process_time / _frame_count : 0;
            _fps = ave_process_time > 0 ? ONE_SECOND_FOR_MICROSECOND / ave_process_time : 0.0f;

            // 計測に使用した変数をリセット
            _frame_count = 0;
            _total_process_time = 0;
            _last_started_time = now_time;

            // 最終更新時刻を設定
            _last_updated_time = now_time;
        }

    }
}
