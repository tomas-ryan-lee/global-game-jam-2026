using UnityEngine;

public class PNJScript : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    public GameObject _mask;
    [SerializeField][TextAreaAttribute] string _dialogText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.canOpenDialog = true;
            GameManager.Instance.dialogText = _dialogText;
            GameManager.Instance.maskToUpdate = _mask;
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
