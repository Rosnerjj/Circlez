using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonController : MonoBehaviour
{
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    public void StartGame() {
        SceneManager.LoadSceneAsync(1);
        Debug.Log("Game started");
    }

    public void CustomizeButton() {
        SceneManager.LoadSceneAsync(2);
        Debug.Log("Customization started");
    }

    public void ExitGame() {
        Application.Quit();
        Debug.Log("Game exited");
    }

    public void RestartGame() {
        pauseMenu.Resume();
        SceneManager.LoadSceneAsync(1);
        Debug.Log("Game restarted");
    }

    public void ReturnToMenu() {
        SceneManager.LoadSceneAsync(0);
        pauseMenu.Resume();
        Debug.Log("Main menu");
    }

    public void ResumeGame() {
        pauseMenu.Resume();
        Debug.Log("Game resumed");
    }

    public void Tutorial()
    {
        SceneManager.LoadSceneAsync(3);
        Debug.Log("Tutorial started");
    }
}
