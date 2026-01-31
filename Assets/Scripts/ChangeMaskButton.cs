using UnityEngine;
public class ChangeMaskButton : MonoBehaviour
{
    public GameObject newMask;
    public EmotionsList emotion;

    public void OnClick()
    {
        GameManager.Instance.ChangeMask(newMask, emotion);
        Destroy(gameObject);
    }
}
