using UnityEngine;

public class ChangeMaskButton : MonoBehaviour
{
    public GameObject newMask;

    public void OnClick()
    {
        GameManager.Instance.ChangeMask(newMask);
        Destroy(gameObject);
    }
}
