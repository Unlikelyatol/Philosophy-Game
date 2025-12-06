using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    // set value in DB from 0 to -80
    [SerializeField] public float MasterVolume = 0f;
    [SerializeField] public float SFXVolume = 0f;
    [SerializeField] public float MusicVolume = 0f;
    [SerializeField] private AudioMixer audioMixer;

    // TEMPORARY VOLUME CHANGER DELETE THIS UPDATE AND ITS VARIABLES AFTER WE MAKE SLIDER
    private void Update()
    {
        SetMasterVolume(MasterVolume);
        SetMusicVolume(MusicVolume);
        SetSFXVolume(SFXVolume);
    }
    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", value);
    }
    
    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", value);
    }

}
