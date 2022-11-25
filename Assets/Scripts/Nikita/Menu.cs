using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private InputField _nameField;

    private void Start()
    {
        _nameField.text = PlayerPrefs.GetString("currentPlayer");
    }

    public void OnStart()
    {
        if (_nameField.text.Length < 5)
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
