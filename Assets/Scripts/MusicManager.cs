using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [Header("Stats musics")]
    public AudioClip victorySound;

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

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
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
