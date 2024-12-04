using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public Button audioButton;
    public GameObject audioCanvas;
    public AudioSource musicSource;
    public bool isActive;

    // Update is called once per frame
    void Update()
    {
        audioButton.onClick.AddListener(buttonClick);
    }

    void buttonClick() 
    {
        if (!isActive) 
            Active();
        else
            InActive();
    }

    public void InActive()
    {
        audioCanvas.gameObject.SetActive(false);
        musicSource.Stop();
        isActive = false;
    }

    public void Active() 
    {
        audioCanvas.gameObject.SetActive(true);
        musicSource.Play();
        isActive = true;
    }
}
