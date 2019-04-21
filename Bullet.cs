using System;
using SplashKitSDK;

public class Bullet {
    private Bitmap _Bullet;
    public double X { get; set; }
    public double Y { get; set; }
    private Vector2D Velocity { get; set; }
    public Bullet (Window gameWindow, Player currentPlayer) {
        int SPEED = 5;
        _Bullet = new Bitmap ("Bullet", "Bullet.png");
        X = currentPlayer.x + 15;
        Y = currentPlayer.y - 39;
        Point2D fromPt = new Point2D () {
            X = X, Y = Y
        };
        Point2D toPt = new Point2D () {
            X = SplashKit.MousePosition().X, Y = SplashKit.MousePosition().Y
        };
        Vector2D dir;
        dir = SplashKit.UnitVector (SplashKit.VectorPointToPoint (fromPt, toPt));
        // Set the speed and assign to the Velocity
        Velocity = SplashKit.VectorMultiply (dir, SPEED);
    }
    public void Draw () {
        SplashKit.DrawBitmap (_Bullet, X, Y);
    }
    public void Update () {
        X = X + Velocity.X;
        Y = Y + Velocity.Y;
    }
    public bool CollideWith (Robot other) {
        return _Bullet.CircleCollision (X, Y, other.CollisionCircle);
    }
    public bool isOffScreen (Window gameWindow) {
        if (X < -50 || X > gameWindow.Width || Y < -50 || Y > gameWindow.Height) return true;
        return false;
    }
}