
namespace NeonDX.Graphics2D.Image
{
    /**
     * 動画
     * 
     */
    public class NDX_Video : NDX_GraphicalObject
    {
        private NDX_Position2D _pos = new NDX_Position2D();
        private NDX_Size2D _size;
        private int _total_frames;
        private long _frame_time;

        /**
         * 位置
         */
        public NDX_Position2D Position
        {
            get { return _pos; }
            set { _pos = value; IsModified = true; }
        }

        /**
         * サイズ
         */
        public NDX_Size2D Size
        {
            get { return _size; }
        }

        /**
         * 総フレーム数
         */
        public int TotalFrames
        {
            get { return _total_frames; }
        }

        /**
         * 1フレームあたりの時間（マイクロ秒）
         */
        public long FrameTime
        {
            get { return _frame_time; }
        }

        /**
         * ムービーの再生状態
         */
        public int MovieState
        {
            get
            {
                return NDX_API_Movie.GetMovieStateToGraph(Handle);
            }
        }

        /**
         * コンストラクタ
         */
        public NDX_Video(NDX_Handle handle) : base(handle)
        {
            _size = NDX_API_Graphics2D.GetGraphSize(handle);
            _total_frames = NDX_API_Movie.GetMovieTotalFrames(handle);
            _frame_time = NDX_API_Movie.GetMovieOneFrameTime(handle);
        }

        /**
         * 描画
         */
        public override void Draw()
        {
            NDX_API_Graphics2D.DrawExtendGraph(_pos.X, _pos.Y, _pos.X + _size.Width, _pos.Y + _size.Height, Handle, true);
        }

        /**
         * 更新
         */
        public override void Update()
        {
        }
    }
}
