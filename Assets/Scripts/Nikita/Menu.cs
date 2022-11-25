using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private InputField _nameField;
    [SerializeField] private Text _newScore;
    [SerializeField] private Text[] _leaderNames;

    private void Start()
    {
        Cursor.visible = true;

        _nameField.text = PlayerPrefs.GetString("currentPlayer");

        _newScore.text = "";
        int newScore = PlayerPrefs.GetInt("newScore", -1);
        if (newScore > 0)
        {
            PlayerPrefs.SetInt("newScore", -1);
            _newScore.text = $"Новый рекорд! {newScore}";
        }

        for (int i = 0; i < 5; i++)
        {
            string name = PlayerPrefs.GetString("LeaderName" + i, "");
            int score = PlayerPrefs.GetInt("LeaderScore" + i, 0);

            //print(name + " " + score + " index " + i);

            _leaderNames[i].text = name == "" ? "" : ((i + 1) + ". " + name);
            Text leaderScore = _leaderNames[i].transform.GetChild(0).GetComponent<Text>();
            leaderScore.text = name == "" ? "" : score.ToString();
        }

    }

    public void OnStart()
    {
        if (_nameField.text.Length < 3)
            return;

        PlayerPrefs.SetString("currentPlayer", _nameField.text);

        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
