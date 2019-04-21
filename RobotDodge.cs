using System;
using System.Collections.Generic;
using SplashKitSDK;
public class RobotDodge {
    private Player _Player;
    private Window _GameWindow;
    private List<Robot> _Robots = new List<Robot> ();
    private List<Bullet> _Bullets = new List<Bullet> ();
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
        if (_Player.isFire == true) {
            _Player.isFire = false;
            _Bullets.Add (CreateBullet ());
        }
    }
    public void Draw () {
        _GameWindow.Clear (Color.LightYellow);
        foreach (var _TestRobot in _Robots) {
            _TestRobot.Draw ();
        }
        _Player.Draw ();
        if (_Bullets != null) {
            foreach (var _Bullet in _Bullets) {
                _Bullet.Draw ();
            }
        }
        _GameWindow.DrawText ($"{Program.Score}", Color.Black, "BoldFont", 18, 750, 30);
        _GameWindow.Refresh (6000);
    }
    public void Update () {
        if (SplashKit.Rnd (100) < 2) _Robots.Add (RandomRobot ());
        foreach (var _TestRobot in _Robots) {
            _TestRobot.Update ();
        }
        if (_Bullets != null) {
            foreach (var _Bullet in _Bullets) {
                _Bullet.Update ();
            }
        }
        CheckCollisions ();
    }
    public Robot RandomRobot () {
        Robot _TestRobot;
        if (SplashKit.Rnd () < 0.5) {
             _TestRobot = new Boxy (_GameWindow, _Player);
        } else {
            if (SplashKit.Rnd() < 0.5) {
            _TestRobot = new Roundy (_GameWindow, _Player);
            }
            else {
            _TestRobot = new Octopus (_GameWindow, _Player);
            }
        }
        return _TestRobot;
    }
    public Bullet CreateBullet () {
        Bullet _NewBullet = new Bullet (_GameWindow, _Player);
        return _NewBullet;
    }
    private void CheckCollisions () {
        List<Robot> removeRobots = new List<Robot> ();
        List<Bullet> removeBullets = new List<Bullet> ();
        foreach (var _TestRobot in _Robots) {
            if (_Player.CollideWith (_TestRobot) == true || _TestRobot.isOffScreen (_GameWindow) == true) {
                removeRobots.Add (_TestRobot);
                if (_Player.CollideWith (_TestRobot) == true) {
                    _Player.Lives -= 1;
                    if (_Player.Lives <= 0) _Player.quit = true;
                }
            }
            //
            if (_Bullets != null) {
                foreach (var _Bullet in _Bullets) {
                    if (_Bullet.CollideWith (_TestRobot) == true) {
                        removeRobots.Add (_TestRobot);
                        removeBullets.Add (_Bullet);
                    }
                    if (_Bullet.isOffScreen (_GameWindow) == true) removeBullets.Add (_Bullet);
                }
            }
        }
        foreach (var _TestRobot in removeRobots) {
            _Robots.Remove (_TestRobot);
        }
        foreach (var _Bullet in removeBullets) {
            _Bullets.Remove (_Bullet);
        }
    }
}