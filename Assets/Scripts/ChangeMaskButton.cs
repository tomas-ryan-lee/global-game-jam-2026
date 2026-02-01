using UnityEngine;
public class ChangeMaskButton : MonoBehaviour
{
    public GameObject newMask;
    public EmotionsList emotion;
    private AudioClip musicToPlay;

    public void OnClick()
    {
        GameManager.Instance.ChangeMask(newMask, emotion);
        Destroy(gameObject);

        switch (emotion)
        {
            case EmotionsList.fear:
                musicToPlay = MusicManager.Instance.fearSound;
                break;
            case EmotionsList.joy:
                musicToPlay = MusicManager.Instance.joySound;
                break;
            case EmotionsList.wrath:
                musicToPlay = MusicManager.Instance.wrathSound;
                break;
            case EmotionsList.sad:
                musicToPlay = MusicManager.Instance.sadSound;
                break;
            default: 
                musicToPlay = null;
                break;
        }

        if (musicToPlay != null)
        {
            EventManager.PlayMusic(musicToPlay);
        }
    }
}
