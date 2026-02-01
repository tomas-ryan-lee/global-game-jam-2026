using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }
    [SerializeField] private AudioSource _audioSource;

    [Header("Common sounds")]
    public AudioClip _NPCInteraction;
    public AudioClip pupitreInteraction;

    [Header("Mask sounds")]
    [SerializeField] private AudioClip _maskChoiceMenu;
    [SerializeField] private AudioClip _maskChoiceSound;


    [Header("Dialog sounds")]
    public AudioClip wrath;
    public AudioClip fear;
    public AudioClip sad;

    private void OnEnable()
    {
        EventManager.OnSFXPlayed += PlaySFX;
        EventManager.OnSFXStopped += StopSFX;
    }

    private void OnDisable()
    {
        EventManager.OnSFXPlayed -= PlaySFX;
        EventManager.OnSFXStopped -= StopSFX;
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
