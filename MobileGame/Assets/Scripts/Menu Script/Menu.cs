using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public void StartGame()
    {
       SceneManager.LoadScene("Game");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

