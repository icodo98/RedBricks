using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public Slider volumeSlider;

    private void Awake() {
         if ( Instance == null)
        {
            Instance = this;
         // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

       
        
    }

    private void Start() 
    {
        
        PlayMusic("battle");
        LoadByJSON();
        volumeSlider.value = musicSource.volume;
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if(s==null)
        {
            Debug.Log("Sound Nor found");

        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if(s==null)
        {
            Debug.Log("Sound Nor found");

        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        SaveByJSON();
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float SdVolume)
    {
        musicSource.volume = SdVolume;
        SaveByJSON();
        LoadByJSON();
        volumeSlider.value = musicSource.volume;
    }
    public void SFXVolume(float SdVolume)
    {
        sfxSource.volume = SdVolume;
    }

    private SettingJson saveSetting()
    {
        SettingJson save = new SettingJson();

        save.volume = musicSource.volume;
        save.Mute = musicSource.mute;

        return save;
    }
    private void SaveByJSON()
    {
        SettingJson save = saveSetting();
        string JsonString = JsonUtility.ToJson(save);
        StreamWriter sw = new StreamWriter(Application.dataPath + "/SettingJson.text");
        sw.Write(JsonString);
        sw.Close();
        Debug.Log("Save");
        
    }
    private void LoadByJSON()
    {
        if(File.Exists(Application.dataPath + "/SettingJson.text"))
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/SettingJson.text");
            string JsonString = sr.ReadToEnd();
            sr.Close();
            SettingJson save =JsonUtility.FromJson<SettingJson>(JsonString);
            Debug.Log("LOADED");

        ////
        
        musicSource.volume= save.volume;
        musicSource.mute = save.Mute;
        ///
        }
        else
        {
            Debug.Log("NOT FOUND SAVE FILE");
        }
    }
}
