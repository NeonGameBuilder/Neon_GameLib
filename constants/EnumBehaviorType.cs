
namespace NeonDX.Constants
{
    /**
     * ビヘイビアタイプ
     */
    public enum EnumBehaviorType
    {
        Unknown,

        UniformMotion,      // 等速運動
        TrackingMotion,     // 追跡運動
        EscapingMotion,     // 逃避運動
        AimingMotion,       // 標的運動
        RandomTurn,         // ランダムターン
        AI,                 // AI

        Custom,         // カスタムビヘイビア
    }
}
