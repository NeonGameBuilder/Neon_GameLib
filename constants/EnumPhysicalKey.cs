
using static NeonDX.DxLibApi.NDX_API_Input;

namespace NeonDX.Constants
{
    public enum EnumPhysicalKey
    {
        Key_Unknown,

        Key_BACK        = KEY_INPUT_BACK,	// バックスペースキー
        Key_TAB         = KEY_INPUT_TAB,	// タブキー
        Key_RETURN      = KEY_INPUT_RETURN,	// エンターキー

        Key_LSHIFT      = KEY_INPUT_LSHIFT,	// 左シフトキー
        Key_RSHIFT      = KEY_INPUT_RSHIFT,	// 右シフトキー
        Key_LCONTROL    = KEY_INPUT_LCONTROL,	// 左コントロールキー
        Key_RCONTROL    = KEY_INPUT_RCONTROL,	// 右コントロールキー
        Key_ESCAPE      = KEY_INPUT_ESCAPE,	// エスケープキー
        Key_SPACE       = KEY_INPUT_SPACE,	// スペースキー
        Key_PGUP        = KEY_INPUT_PGUP,	// ＰａｇｅＵＰキー
        Key_PGDN        = KEY_INPUT_PGDN,	// ＰａｇｅＤｏｗｎキー
        Key_END         = KEY_INPUT_END,	// エンドキー
        Key_HOME        = KEY_INPUT_HOME,	// ホームキー
        Key_LEFT        = KEY_INPUT_LEFT,	// 左キー
        Key_UP          = KEY_INPUT_UP,	// 上キー
        Key_RIGHT       = KEY_INPUT_RIGHT,	// 右キー
        Key_DOWN        = KEY_INPUT_DOWN,	// 下キー
        Key_INSERT      = KEY_INPUT_INSERT,	// インサートキー
        Key_DELETE      = KEY_INPUT_DELETE,	// デリートキー

        Key_MINUS       = KEY_INPUT_MINUS,	// －キー
        Key_YEN         = KEY_INPUT_YEN,	// ￥キー
        Key_PREVTRACK   = KEY_INPUT_PREVTRACK,	// ＾キー
        Key_PERIOD      = KEY_INPUT_PERIOD,	// ．キー
        Key_SLASH       = KEY_INPUT_SLASH,	// ／キー
        Key_LALT        = KEY_INPUT_LALT,	// 左ＡＬＴキー
        Key_RALT        = KEY_INPUT_RALT,	// 右ＡＬＴキー
        Key_SCROLL      = KEY_INPUT_SCROLL,	// ScrollLockキー
        Key_SEMICOLON   = KEY_INPUT_SEMICOLON,	// ；キー
        Key_COLON       = KEY_INPUT_COLON,	// ：キー
        Key_LBRACKET    = KEY_INPUT_LBRACKET,	// ［キー
        Key_RBRACKET    = KEY_INPUT_RBRACKET,	// ］キー
        Key_AT          = KEY_INPUT_AT,	// ＠キー
        Key_BACKSLASH   = KEY_INPUT_BACKSLASH,	// ＼キー
        Key_COMMA       = KEY_INPUT_COMMA,	// ，キー
        Key_CAPSLOCK    = KEY_INPUT_CAPSLOCK,	// CaspLockキー
        Key_PAUSE       = KEY_INPUT_PAUSE,	// PauseBreakキー

        Key_NUMPAD0     = KEY_INPUT_NUMPAD0,	// テンキー０
        Key_NUMPAD1     = KEY_INPUT_NUMPAD1,	// テンキー１
        Key_NUMPAD2     = KEY_INPUT_NUMPAD2,	// テンキー２
        Key_NUMPAD3     = KEY_INPUT_NUMPAD3,	// テンキー３
        Key_NUMPAD4     = KEY_INPUT_NUMPAD4,	// テンキー４
        Key_NUMPAD5     = KEY_INPUT_NUMPAD5,	// テンキー５
        Key_NUMPAD6     = KEY_INPUT_NUMPAD6,	// テンキー６
        Key_NUMPAD7     = KEY_INPUT_NUMPAD7,	// テンキー７
        Key_NUMPAD8     = KEY_INPUT_NUMPAD8,	// テンキー８
        Key_NUMPAD9     = KEY_INPUT_NUMPAD9,	// テンキー９
        Key_MULTIPLY    = KEY_INPUT_MULTIPLY,	// テンキー＊キー
        Key_ADD         = KEY_INPUT_ADD,	// テンキー＋キー
        Key_SUBTRACT    = KEY_INPUT_SUBTRACT,	// テンキー－キー
        Key_DECIMAL     = KEY_INPUT_DECIMAL,	// テンキー．キー
        Key_DIVIDE      = KEY_INPUT_DIVIDE,	// テンキー／キー
        Key_NUMPADENTER = KEY_INPUT_NUMPADENTER,	// テンキーのエンターキー

        Key_F1          = KEY_INPUT_F1,	// Ｆ１キー
        Key_F2          = KEY_INPUT_F2,	// Ｆ２キー
        Key_F3          = KEY_INPUT_F3,	// Ｆ３キー
        Key_F4          = KEY_INPUT_F4,	// Ｆ４キー
        Key_F5          = KEY_INPUT_F5,	// Ｆ５キー
        Key_F6          = KEY_INPUT_F6,	// Ｆ６キー
        Key_F7          = KEY_INPUT_F7,	// Ｆ７キー
        Key_F8          = KEY_INPUT_F8,	// Ｆ８キー
        Key_F9          = KEY_INPUT_F9,	// Ｆ９キー
        Key_F10         = KEY_INPUT_F10,	// Ｆ１０キー
        Key_F11         = KEY_INPUT_F11,	// Ｆ１１キー
        Key_F12         = KEY_INPUT_F12,	// Ｆ１２キー

        Key_A           = KEY_INPUT_A,	// Ａキー
        Key_B           = KEY_INPUT_B,	// Ｂキー
        Key_C           = KEY_INPUT_C,	// Ｃキー
        Key_D           = KEY_INPUT_D,	// Ｄキー
        Key_E           = KEY_INPUT_E,	// Ｅキー
        Key_F           = KEY_INPUT_F,	// Ｆキー
        Key_G           = KEY_INPUT_G,	// Ｇキー
        Key_H           = KEY_INPUT_H,	// Ｈキー
        Key_I           = KEY_INPUT_I,	// Ｉキー
        Key_J           = KEY_INPUT_J,	// Ｊキー
        Key_K           = KEY_INPUT_K,	// Ｋキー
        Key_L           = KEY_INPUT_L,	// Ｌキー
        Key_M           = KEY_INPUT_M,	// Ｍキー
        Key_N           = KEY_INPUT_N,	// Ｎキー
        Key_O           = KEY_INPUT_O,	// Ｏキー
        Key_P           = KEY_INPUT_P,	// Ｐキー
        Key_Q           = KEY_INPUT_Q,	// Ｑキー
        Key_R           = KEY_INPUT_R,	// Ｒキー
        Key_S           = KEY_INPUT_S,	// Ｓキー
        Key_T           = KEY_INPUT_T,	// Ｔキー
        Key_U           = KEY_INPUT_U,	// Ｕキー
        Key_V           = KEY_INPUT_V,	// Ｖキー
        Key_W           = KEY_INPUT_W,	// Ｗキー
        Key_X           = KEY_INPUT_X,	// Ｘキー
        Key_Y           = KEY_INPUT_Y,	// Ｙキー
        Key_Z           = KEY_INPUT_Z,	// Ｚキー
        Key_0           = KEY_INPUT_0,	// ０キー
        Key_1           = KEY_INPUT_1,	// １キー
        Key_2           = KEY_INPUT_2,	// ２キー
        Key_3           = KEY_INPUT_3,	// ３キー
        Key_4           = KEY_INPUT_4,	// ４キー
        Key_5           = KEY_INPUT_5,	// ５キー
        Key_6           = KEY_INPUT_6,	// ６キー
        Key_7           = KEY_INPUT_7,	// ７キー
        Key_8           = KEY_INPUT_8,	// ８キー
        Key_9           = KEY_INPUT_9,	// ９キー
    }
}
