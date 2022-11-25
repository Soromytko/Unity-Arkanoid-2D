using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data", order = 51)]
public class GameDataScript : ScriptableObject
{
    public bool resetOnStart;
    public int level = 1;
    public int balls = 6;
    public int points = 0;
    public bool music = true;
    public bool sound = true;
    public int pointsToBall = 0;
    public int BonusFrequency = 40;
    public int FireBonusFrequency = 70; //вероятность
    public int MetalBonusFrequency = 90; //вероятность
    public int NormBonusFrequency = 100; //вероятность
    public int FireTimer = 5; //продолжительность огненного 
    public int MetalTimer = 3; //продолжительность металлического

    public string Name;
    public string Best;
    public int Score;

    public bool IsNewScore => points > Score;

    public void Reset()
    {
        level = 1;
        balls = 6;
        points = 0;
        pointsToBall = 0;

        name = PlayerPrefs.GetString("currentPlayer");
        Best = PlayerPrefs.GetString("bestPlayer");
        Score = PlayerPrefs.GetInt("score");

        BonusFrequency = 40;
        FireBonusFrequency = 70;
        MetalBonusFrequency = 90;
        NormBonusFrequency = 100;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("balls", balls);
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("pointsToBall", pointsToBall);
        PlayerPrefs.SetInt("music", music ? 1 : 0);
        PlayerPrefs.SetInt("sound", sound ? 1 : 0);
        SaveScore();

    }

    public void Load()
    {
        level = PlayerPrefs.GetInt("level", 1);
        balls = PlayerPrefs.GetInt("balls", 6);
        points = PlayerPrefs.GetInt("points", 0);
        pointsToBall = PlayerPrefs.GetInt("pointsToBall", 0);
        music = PlayerPrefs.GetInt("music", 1) == 1;
        sound = PlayerPrefs.GetInt("sound", 1) == 1;
        Name = PlayerPrefs.GetString("currentPlayer");
        Best = PlayerPrefs.GetString("bestPlayer");
        Score = PlayerPrefs.GetInt("score");
    }

    public void SaveScore()
    {
        if (IsNewScore)
        {
            PlayerPrefs.SetInt("score", points);
            PlayerPrefs.SetString("bestPlayer", Name);
        }
    }

}
