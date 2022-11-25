using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Text _bestPlayerNameText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _newScoreTitleText;
    [SerializeField] private Text _newScoreValueText;

    private GameDataScript _gameData;
    private AudioSource _audioSource;

    void Start()
    {
        _gameData = FindObjectOfType<PlayerScript>().gameData;
        _audioSource = GetComponent<AudioSource>();
        SetPauseActive(false);
        _gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            SetPauseActive(!_pause.activeSelf);
        }

        _bestPlayerNameText.text = _gameData.Best;
        _scoreText.text = _gameData.Score.ToString();

        //print(PlayerPrefs.GetString("currentPlayer"));

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("Reset Score");
            PlayerPrefs.SetString("bestPlayer", "Ноу нейм");
            PlayerPrefs.SetInt("score", 0);
        }
    }

    public void SetPauseActive(bool active)
    {
        if (active)
        {
            _pause.SetActive(true);
            _audioSource.enabled = false;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            _pause.SetActive(false);
            _audioSource.enabled = true;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void OnNewGame()
    {
        FindObjectOfType<PlayerScript>().gameData.Reset();
        FindObjectOfType<PlayerScript>().gameData.Load();
        SceneManager.LoadScene(1);
    }

    public void OnMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver(int newScore = -1)
    {
        SetPauseActive(true);
        _pause.SetActive(false);
        _gameOverPanel.SetActive(true);

        if (newScore > -1)
        {
            _newScoreTitleText.gameObject.SetActive(true);
            _newScoreValueText.text = newScore.ToString();
        }
        else
        {
            _newScoreTitleText.gameObject.SetActive(false);
        }
    }

    
}
