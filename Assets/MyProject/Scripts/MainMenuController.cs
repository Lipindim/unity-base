using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuController : MonoBehaviour
{

    #region Methods

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    #endregion

}
