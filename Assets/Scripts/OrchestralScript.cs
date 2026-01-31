using UnityEngine;

public class OrchestralScript : MonoBehaviour
{
    [SerializeField][TextAreaAttribute] string _dialogText;
    
    void CheckAllPNJHaveGoodMask()
    {
        GameObject[] pnjs = GameObject.FindGameObjectsWithTag("PNJ");

        foreach (GameObject pnj in pnjs)
        {
            PNJScript script = pnj.GetComponent<PNJScript>();

            if (script == null || !script.hasMask || !script.hasGoodMask) return;
        }

        GameManager.Instance.canOpenDialogOrchestral = true;
        GameManager.Instance.dialogText = _dialogText;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckAllPNJHaveGoodMask();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.canOpenDialogOrchestral = false;
        }
    }
}
