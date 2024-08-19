
namespace NeonDX.System
{
    /**
     * オブジェクトマネージャ
     */
    public sealed class NDX_ObjectManager
    {
        private List<NDX_Object> _objects = new List<NDX_Object>();

        /**
         * 追加
         */
        public void AddObject(NDX_Object obj)
        {
            _objects.Add(obj);
        }

        /**
         * 終了処理
         */
        public void Terminate()
        {
            foreach(var obj in _objects)
            {
                obj.Terminate();
            }
        }
    }
}
