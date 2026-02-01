using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }
    [SerializeField] private AudioSource _audioSource;

    [Header("Mask sounds")]


    [Header("Dialog sounds")]
    [SerializeField] private AudioClip _wrath;
    [SerializeField] private AudioClip _fear;

    private void OnEnable()
    {
        EventManager.OnSFXPlayed += PlayMusic;
        EventManager.OnSFXStopped += StopMusic;
    }

    private void OnDisable()
    {
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

    private void PlaySFX(AudioClip clip, bool loop = false)
    {
        _audioSource.clip = clip;
        _audioSource.loop = loop;
        _audioSource.Play();
    }

    private void StopSFX()
    {
        _audioSource.Stop();
    }
}
