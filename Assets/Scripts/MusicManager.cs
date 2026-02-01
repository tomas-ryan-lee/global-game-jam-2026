using UnityEngine;

public class MusicManager : MonoBehaviour
{

    [Header("Mask musics")]
    public AudioClip joySound;
    public AudioClip sadSound;
    public AudioClip wrathSound;
    public AudioClip fearSound;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable() {
        EventManager.OnMusicPlayed += PlayMusic;
        EventManager.OnMusicStopped += StopMusic;
    }

    private void OnDisable() {
        EventManager.OnMusicPlayed -= PlayMusic;
        EventManager.OnMusicStopped -= StopMusic;
    }

    private void PlayMusic(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    private void StopMusic()
    {
        _audioSource.Stop();
    }
}
