using System;
using SplashKitSDK;

public class Program {
    public static Timer myTimer = new Timer ("My Timer");
    public static int Score = 0;
    public static void Main () {
        // Window gameWindow = new Window("Game", 800, 600);
        // Player player = new Player(gameWindow: gameWindow);
        // gameWindow.Clear(Color.LightYellow); 
        // player.Draw();
        // gameWindow.Refresh(60);
        // SplashKit.Delay(10000);
        myTimer.Start ();
        // myTimer.Delay(2000);
        Window gameWindow = new Window ("Game", 800, 600);
        RobotDodge robotDodge = new RobotDodge (gameWindow);
        while (!gameWindow.CloseRequested || robotDodge.Quit == false) {
            Score = Convert.ToInt32(myTimer.Ticks / 1000);
            SplashKit.ProcessEvents ();
            robotDodge.HandleInput ();
            robotDodge.Update ();
            robotDodge.Draw ();
        }
    }
}