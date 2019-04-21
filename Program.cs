using System;
using SplashKitSDK;

public class Program {
    public static Timer myTimer = new Timer ("My Timer");
    public static int Score = 0;
    public static void Main () {
        myTimer.Start ();
        Window gameWindow = new Window ("Game", 800, 600);
        RobotDodge robotDodge = new RobotDodge (gameWindow);
        while (!gameWindow.CloseRequested && robotDodge.Quit == false) {
            Score = Convert.ToInt32 (myTimer.Ticks / 1000);
            SplashKit.ProcessEvents ();
            robotDodge.HandleInput ();
            robotDodge.Update ();
            robotDodge.Draw ();
        }
    }
}