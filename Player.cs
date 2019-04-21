using System;
using SplashKitSDK;
public class Player {
    private Bitmap _PlayerBitmap;
    private Bitmap _LifeBitmap;
    private Window window;
    public double x {
        get;
        private set;
    }
    public double y {
        get;
        private set;
    }
    public int Width {
        get {
            return _PlayerBitmap.Width;
        }
    }
    public int Height {
        get {
            return _PlayerBitmap.Height;
        }
    }
    public bool quit { get; set; }
    public bool isFire = false;
    public int Lives = 5;
    public Player (Window gameWindow) {
        _PlayerBitmap = new Bitmap ("Player1", "Player1.png");
        _LifeBitmap = new Bitmap ("Life", "Like.png");
        window = gameWindow;
        x = (window.Width - Width) / 2;
        y = (window.Height - Height) / 2;
        quit = false;
    }
    public void Draw () {
        window.DrawBitmap (_PlayerBitmap, x, y);
        // Draw Life
        window.DrawBitmap (_LifeBitmap, 680, 520);
        window.DrawText ($"{Lives}", Color.Black, "BoldFont", 2, 660, 540);
    }
    public void HandleInput () {
        const int Speed = 5;
        SplashKit.ProcessEvents ();
        if (SplashKit.KeyDown (KeyCode.UpKey)) y -= Speed;
        if (SplashKit.KeyDown (KeyCode.DownKey)) y += Speed;
        if (SplashKit.KeyDown (KeyCode.RightKey)) x += Speed;
        if (SplashKit.KeyDown (KeyCode.LeftKey)) x -= Speed;
        // Press Q to quit the game
        if (SplashKit.KeyDown (KeyCode.QKey)) quit = true;
        if (SplashKit.MouseDown (MouseButton.LeftButton)) isFire = true;
    }
    public void StayOnWindow (Window limit) {
        const int GAP = 60;
        if (x < GAP - 60) x = GAP - 60;
        if (x > limit.Width - GAP) x = limit.Width - GAP - 20;
        if (y < GAP - 60) y = GAP - 60;
        if (y > limit.Height - GAP) y = limit.Height - GAP - 20;
    }
    public bool CollideWith (Robot other) {
        return _PlayerBitmap.CircleCollision (x, y, other.CollisionCircle);
    }
}