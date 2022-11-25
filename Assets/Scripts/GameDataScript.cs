using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using System.Linq;

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
    public int FireBonusFrequency = 70;
    public int MetalBonusFrequency = 90;
    public int NormBonusFrequency = 100;
    public int FireTimer = 5; //продолжительность огненного 
    public int MetalTimer = 3; //продолжительность металлического

    public string CurrentPlayerName;

    public class Leader
    {
        public Leader(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public string Name { get; set; }
        public int Score { get; set; }
    }

    private List<Leader> _leaders;

    public void Reset()
    {
        level = 1;
        balls = 6;
        points = 0;
        pointsToBall = 0;
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
    }

    public void SaveScore()
    {
        CurrentPlayerName = PlayerPrefs.GetString("currentPlayer");

        _leaders = new Leader[5]
            .Select((x, i) =>
            {
                var name = PlayerPrefs.GetString("LeaderName" + i, "");
                var score = PlayerPrefs.GetInt("LeaderScore" + i, 0);

                return new Leader(name, score);
            })
            .ToList();

        if (!IsNewScore(out int index))
            return;

        _leaders.Insert(index, new Leader(CurrentPlayerName, points));
        int lastIndex = _leaders.FindLastIndex(x => x.Name == CurrentPlayerName);

        if (index == lastIndex)
            _leaders.RemoveAt(_leaders.Count - 1);
        else
            _leaders.RemoveAt(lastIndex);

        PlayerPrefs.SetInt("newScore", points);
        for (int i = 0; i < _leaders.Count; i++)
        {
            PlayerPrefs.SetString("LeaderName" + i, _leaders[i].Name);
            PlayerPrefs.SetInt("LeaderScore" + i, _leaders[i].Score);
        }

        //int maxScoreIndex = leaders.FindIndex(x => x == leaders.Last(x => points > x.Score));
    }

    private bool IsNewScore(out int index)
    {
        index = -1;

        for (int i = 0; i < _leaders.Count; i++)
        {
            if (points > _leaders[i].Score)
            {
                index = i;
                return true;
            }

            if (CurrentPlayerName == _leaders[i].Name)
                return false;
        }

        return false;
    }

}


