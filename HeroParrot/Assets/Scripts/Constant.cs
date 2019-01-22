using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant
{

    public static class String
    {
        public const string BESTSCORE = "BEST SCORE : ";
        public const string GAMESPLAYED = "GAMES PLAYED : ";
    }
    public static class Tag
    {
        public const string UNTAGGED = "Untagged";
        public const string PLAYER = "Player";
        public const string WALL = "Wall";
        public const string SPIKE = "Spike";
    }

    public static class ScoreInfo
    {
        public const string BESTSCORE = "BestScore";
        public const string TOTALGEM = "TotalGem";
    }

    public static class Scenes
    {
        public const string MAINSCENE = "MainScene";
        public const string STARTSCENE = "StartScene";
    }


    public static class Animation
    {
        public const string BIRDFLY = "BirdFly";
        public const string BIRDDEAD = "BirdDead";
        public const string HIDESHOPPANEL = "HideShopPanel";
    }

    public static class PlayerInfo
    {
        public const string CURRENTPLAYER = "CurrentPlayer";
        public static string[] LISTPLAYER = new string[16] { "Player0","Player1", "Player2", "Player3", "Player4", "Player5", "Player6", "Player7", "Player8", "Player9","Player10", "Player11", "Player12", "Player13", "Player14", "Player15" };
    }
}
