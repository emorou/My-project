using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
   public Sound[] musicSounds, sfxSounds;
   public AudioSource musicSource, sfcSource;

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

   public void PlaySFX()
   {
    
   }
}
