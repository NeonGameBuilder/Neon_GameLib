
namespace NeonDX.Graphics3D.Animation
{
    /**
     * アニメーション情報
     */
    public sealed class NDX_3DModelAnimationInfo : NDX_Object
    {
        private int _index;
        private string _name;
        private float _length;

        /**
         * インデックス
         */
        public int Index
        {
            get { return _index; }
        }

        /**
         * アニメーション名
         */
        public string Name
        {
            get { return _name; }
        }

        /**
         * アニメーション長（総時間）
         */
        public float Length
        {
            get { return _length; }
        }

        /**
         * コンストラクタ
         */
        public NDX_3DModelAnimationInfo(int index, string name, float length)
        {
            _index = index;
            _name = name;
            _length = length;
        }

    }
}
