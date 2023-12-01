using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "Level Tutorial")
        {
            PlayMusic("Tutorial Music");
        }

    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x=> x.name == name);

        if(s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play(); 
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x=> x.name == name);

        if(s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
