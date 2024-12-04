using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        if(PlayerPrefs.HasKey("MusicVolume"))
            LoadVolume();
        else
            SetMusicVolume();
            SetSFXVolume();
    }

    public void SetMusicVolume()
    {
        float musicVolume = musicSlider.value;
        audioMixer.SetFloat("MusicParam", Mathf.Log10(musicVolume)*20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSFXVolume()
    {
        float sfxVolume = sfxSlider.value;
        audioMixer.SetFloat("SFXParam", Mathf.Log10(sfxVolume)*20);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadVolume() 
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SetMusicVolume();
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetSFXVolume();
    }
}
