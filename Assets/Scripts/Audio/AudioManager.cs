using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region
    private static AudioManager instance;
    // Create an Instance of this Script So methods can be called anywhere
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Audiomanager Null");
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    #endregion
    // Array of Music Sounds And SFX Sounds
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    [SerializeField] private AudioSource PointSFXSource;
    public void PlayMusic(string name)
    {
        // Checks if the Name is Within the array
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            // Play The Music
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    // Global SFX, Can be heard anywhere not from one point
    public void PlaySFX(string name, float Volume = 1)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            // Only Plays Once
            sfxSource.PlayOneShot(s.clip);
        }
    }
    // Source is at a point
    public void PlaySFXAtPoint(string name, Transform transform, float Volume = 1) 
    {
        AudioSource audioSource = Instantiate(PointSFXSource, transform.position, Quaternion.identity);
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
            Destroy(audioSource);
        }
        else
        {
            // Only Plays Once Then destroys the source
            sfxSource.PlayOneShot(s.clip);
            float ClipLength = s.clip.length;
            Destroy(audioSource, ClipLength);
        }
    }
    public void PauseMusic()
    {
        if (musicSource.clip == null)
        {
            Debug.Log("No sound is playing");
        }
        else
        {
            musicSource.Pause();
        }
    }
}
