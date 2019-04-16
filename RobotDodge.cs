using System;
using System.Collections.Generic;
using SplashKitSDK;
public class RobotDodge {
    private Player _Player;
    private Window _GameWindow;
    private List<Robot> _Robots = new List<Robot> ();
    public bool Quit {
        get {
            return _Player.quit;
        }
    }
    public RobotDodge (Window gameWindow) {
        _GameWindow = gameWindow;
        _Player = new Player (_GameWindow);
        RandomRobot ();
    }
    public void HandleInput () {
        _Player.HandleInput ();
        _Player.StayOnWindow (_GameWindow);
    }
    public void Draw () {
        _GameWindow.Clear (Color.LightYellow);
        foreach (var _TestRobot in _Robots) {
            _TestRobot.Draw ();
        }
        _Player.Draw ();
        _GameWindow.DrawText($"{Program.Score}", Color.Black, "BoldFont",18, 750, 30);
        _GameWindow.Refresh (6000);
    }
    public void Update () {
        if (SplashKit.Rnd (100) < 2) _Robots.Add (RandomRobot ());
        foreach (var _TestRobot in _Robots) {
            _TestRobot.Update ();
        }
        CheckCollisions ();
    }
    public Robot RandomRobot () {
        Robot _TestRobot = new Robot (_GameWindow, _Player);
        return _TestRobot;
    }
    private void CheckCollisions () {
        List<Robot> removeRobots = new List<Robot> ();
        foreach (var _TestRobot in _Robots) {
            if (_Player.CollideWith (_TestRobot) == true || _TestRobot.isOffScreen (_GameWindow) == true) {
                removeRobots.Add (_TestRobot);
                if (_Player.CollideWith (_TestRobot) == true) {
                _Player.Lives -= 1;
                if (_Player.Lives <= 0) _Player.quit = true;
                }
            }
        }
        foreach (var _TestRobot in removeRobots) {
            _Robots.Remove (_TestRobot);
        }
    }
}