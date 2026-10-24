using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MiningArea");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
