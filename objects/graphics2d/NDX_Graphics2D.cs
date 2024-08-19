using System.Collections.Generic;

using NeonDX.Graphics.Font;
using NeonDX.Graphics2D.Screen;
using NeonDX.Graphics2D.Sprite;
using NeonDX.Graphics2D.Image;

namespace NeonDX.Graphics2D
{
    /**
     * ２次元グラフィックス
     * 
     * 取得元： NeonDX
     */
    public sealed class NDX_Graphics2D
    {
        /**
         * 画像をロード
         */
        public NDX_Image LoadImage(string filename)
        {
            return new NDX_Image(NDX_API_Graphics2D.LoadGraph(filename));
        }

        /**
         * 拡大縮小可能画像をロード
         */
        public NDX_StretchableImage LoadStretchableImage(string filename)
        {
            return new NDX_StretchableImage(NDX_API_Graphics2D.LoadGraph(filename));
        }

        /**
         * 動画をロード
         */
        public NDX_Video LoadVideo(string filename)
        {
            return new NDX_Video(NDX_API_Graphics2D.LoadGraph(filename));
        }

        /**
         * 動画を再生
         */
        public void PlayMovie(string filename, int rate = 1, EnumMoviePlayType play_type = EnumMoviePlayType.Normal)
        {
            NDX_API_Movie.PlayMovie(filename, rate, play_type);
        }

        /**
         * 動画を再生
         */
        public void PlayMovie(NDX_Video video)
        {
            NDX_API_Movie.PlayMovieToGraph(video.Handle);
        }

        /**
         * スプライトシートをロード
         */
        public NDX_SpriteSheet LoadSpriteSheet(NDX_SpriteSheetInfo si)
        {
            return CreateSpriteSheet(si.FileName, si.Width, si.Height, si.HorzCount, si.VertCount, si.Total);
        }
        public NDX_SpriteSheet CreateSpriteSheet(string filename, int width, int height, int h_cnt, int v_cnt, int total)
        {
            // アニメーション画像全体をファイルから読み込む
            var handles = NDX_API_Graphics2D.LoadDivGraph(filename, total, h_cnt, v_cnt, width, height);

            // アニメーションフレームの構築
            var frames = new List<NDX_SpriteFrame>();
            foreach(var h in handles)
            {
                frames.Add(new NDX_SpriteFrame(h));
            }

            return new NDX_SpriteSheet(frames, width, height);
        }

        /**
         * 仮想画面を作成
         */
        public NDX_VirtualScreen CreateVirtualScreen(NDX_Size2D size, bool use_alpha = true)
        {
            return CreateVirtualScreen(size.Width, size.Height, use_alpha);
        }
        public NDX_VirtualScreen CreateVirtualScreen(int width, int height, bool use_alpha = true)
        {
            return new NDX_VirtualScreen(NDX_API_Graphics2D.MakeScreen(width, height, use_alpha), width, height);
        }

        /**
         * 点を描画
         */
        public void DrawPixel(int x, int y, NDX_Color color)
        {
            NDX_API_Graphics2D.DrawPixel(x, y, color);
        }

        /**
         * 文字列を描画（デフォルトフォント）
         */
        public void DrawText(int x, int y, string text, NDX_Color color)
        {
            NDX_API_Graphics2D.DrawString(x, y, text, color);
        }
        public void DrawText(NDX_Position2D pos, string text, NDX_Color color)
        {
            NDX_API_Graphics2D.DrawString(pos.X, pos.Y, text, color);
        }

        /**
         * 文字列を描画（フォント指定）
         */
        public void DrawText(int x, int y, string text, NDX_Color color, NDX_Font font)
        {
            NDX_API_Graphics2D.DrawStringToHandle(x, y, text, color, font.Handle);
        }
        public void DrawText(NDX_Position2D pos, string text, NDX_Color color, NDX_Font font)
        {
            NDX_API_Graphics2D.DrawStringToHandle(pos.X, pos.Y, text, color, font.Handle);
        }

        /**
         * 文字列を描画（スプライトフォント）
         */
        public void DrawText(NDX_Position2D pos, string text, NDX_SpriteFont font)
        {
            DrawText(pos.X, pos.Y, text, font);
        }
        public void DrawText(int x, int y, string text, NDX_SpriteFont font)
        {
            int width = font.SpriteSheet.FrameSize.Width;
            for(int i=0; i<text.Length; i++)
            {
                char c = text[i];

                var frame = font.GetCharFrame(c);
                if (frame != null)
                {
                    DrawSpriteFrame(frame, x + width * i, y);
                }
            }
        }

        /**
         * 文字列の描画幅を取得（デフォルトフォント）
         */
        public int GetStringWidth(string text)
        {
            return NDX_API_Graphics2D.GetDrawStringWidth(text, -1);
        }

        /**
         * 文字列の描画幅を取得（フォント指定）
         */
        public int GetStringWidth(string text, NDX_Font font)
        {
            return NDX_API_Graphics2D.GetDrawStringWidthToHandle(text, -1, font.Handle);
        }

        /**
         * スプライトフレームを描画
         */
        public void DrawSpriteFrame(NDX_SpriteFrame frame, NDX_Position2D pos, bool alpha_enabled = true)
        {
            DrawSpriteFrame(frame, pos.X, pos.Y, alpha_enabled);
        }
        public void DrawSpriteFrame(NDX_SpriteFrame frame, int x, int y, bool alpha_enabled = true)
        {
            NDX_API_Graphics2D.DrawGraph(x, y, frame.Handle, alpha_enabled);
        }
    }
}
