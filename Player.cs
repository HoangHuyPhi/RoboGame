using System;
using SplashKitSDK;

public class Player
{
        private Bitmap _PlayerBitmap;
        private Window Window;
        public double X {
            get;
            private set;
        }
        public double Y {
            get;
            private set;
        }
        public int Width {
            get 
            {
                return _PlayerBitmap.Width;
            }
        }
        public int Height {
            get 
            {
                return _PlayerBitmap.Height;
            }
        }
        public Player(Window gameWindow) {
            _PlayerBitmap = new Bitmap("Player1", "Player1.png");
            Window = gameWindow;
            X = (Window.Width - Width) / 2;
            Y = (Window.Height - Height) / 2;
        }
        public void Draw() {
            Window.DrawBitmap(_PlayerBitmap, X, Y);
        }
}