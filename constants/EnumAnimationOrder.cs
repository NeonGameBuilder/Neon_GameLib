
namespace NeonDX.Constants
{
    /**
     * アニメーションの再生方法
     */
    public enum EnumAnimationOrder
    {
        Cyclic,         // 循環：０→１→２→３→０→１→２→３・・・
        RoundTrip,      // 往復：０→１→２→３→２→１→０→１・・・
        Custom,         // カスタム：カスタム再生配列によって制御
    }
}
