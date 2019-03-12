using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window gameWindow = new Window("Game", 800, 600);
        Player player = new Player(gameWindow: gameWindow );
        gameWindow.Clear(Color.LightYellow); 
        player.Draw();
        gameWindow.Refresh(60);
        SplashKit.Delay(10000);
    }
}