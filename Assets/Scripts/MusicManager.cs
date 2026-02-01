using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [Header("Mask musics")]
    [SerializeField] private AudioClip _joySound;
    [SerializeField] private AudioClip _sadSound;
    [SerializeField] private AudioClip _wrathSound;
    [SerializeField] private AudioClip _fearSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
