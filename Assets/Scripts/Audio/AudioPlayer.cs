using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    //Enter name of track you want to play (keeping it simple)
    [SerializeField] string TrackName;
    public void Start()  
    {
        AudioManager.Instance.PlayMusic(TrackName);
    }
}
