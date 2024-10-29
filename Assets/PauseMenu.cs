using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {
        GetComponent<Button>().onClick.AddListener(buttonClick);
    }

    void buttonClick() {
        if (!isPaused) {
            Pause();
        }
    }

    public void Resume() {
        pauseMenuUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause() {
        pauseMenuUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
