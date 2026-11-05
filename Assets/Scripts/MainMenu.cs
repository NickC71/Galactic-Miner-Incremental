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
        Debug.Log("QUIT BUTTON CLICKED");

        Application.Quit();

        Debug.Log("APPLICATION QUIT REQUESTED");
    }
}
