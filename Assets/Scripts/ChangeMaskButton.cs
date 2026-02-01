using UnityEngine;
public class ChangeMaskButton : MonoBehaviour
{
    public GameObject newMask;
    public EmotionsList emotion;
    private AudioClip musicToPlay;
    private AudioClip sfxToPlay;

    public void OnClick()
    {
        GameManager.Instance.ChangeMask(newMask, emotion);
        Destroy(gameObject);

        switch (emotion)
        {
            case EmotionsList.fear:
                musicToPlay = MusicManager.Instance.fearSound;
                sfxToPlay = SFXManager.Instance.fear;
                break;
            case EmotionsList.wrath:
                musicToPlay = MusicManager.Instance.wrathSound;
                sfxToPlay = SFXManager.Instance.wrath;
                break;
            case EmotionsList.sad:
                musicToPlay = MusicManager.Instance.sadSound;
                sfxToPlay = SFXManager.Instance.sad;
                break;
            default: 
                musicToPlay = null;
                sfxToPlay = null;
                break;
        }

        if (musicToPlay != null)
            EventManager.PlayMusic(musicToPlay);

        if (sfxToPlay != null)
            EventManager.PlaySFX(sfxToPlay, false);
    }
}
