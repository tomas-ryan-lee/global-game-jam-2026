using UnityEngine;

public class PNJScript : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private GameObject _mask;
    [SerializeField][TextAreaAttribute] string _dialogText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.canOpenDialog = true;
            GameManager.Instance.dialogText = _dialogText;
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
