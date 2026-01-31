using UnityEngine;

public class PNJScript : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private GameObject _mask;
    [SerializeField][TextAreaAttribute] string _dialogText;

    public void ChangeMask(GameObject newMask)
    {
        _mask = newMask;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.canOpenDialog = true;
            GameManager.Instance.dialogText = _dialogText;
            GameManager.Instance.pnjToUpdate = this;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.canOpenDialog = false;
            GameManager.Instance.dialogText = null;
        }
    }

}
