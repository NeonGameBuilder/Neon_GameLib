
namespace NeonDX
{
    /**
     * グラフィカル
     */
    public abstract class NDX_GraphicalObject : NDX_Object
    {
        /**
         * コンストラクタ
         */
        public NDX_GraphicalObject() 
        {
        }
        public NDX_GraphicalObject(NDX_Handle handle) : base(handle)
        {
        }

        /**
         * 描画
         */
        public virtual void Draw()
        {
        }

        /**
         * 終了処理
         */
        public override void Terminate()
        {
            if (Handle != null)
            {
                NDX_API_Graphics2D.DeleteGraph(Handle);
                Handle = NDX_Handle.Null;
            }
        }
    }
}
