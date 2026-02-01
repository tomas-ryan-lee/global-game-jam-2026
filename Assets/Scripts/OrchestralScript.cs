using UnityEngine;

public class OrchestralScript : MonoBehaviour
{
    [SerializeField][TextAreaAttribute] string _dialogText;
    [SerializeField] private Material SkyboxHappy;
    [SerializeField] private GameObject vfxMusicalNotesPNJ1;
    [SerializeField] private GameObject vfxMusicalNotesPNJ2;
    [SerializeField] private GameObject vfxMusicalNotesPNJ3;
    [SerializeField] private GameObject vfxRain;
    [SerializeField] private GameObject vfxFireworks;
    [SerializeField] private GameObject joyMask;

    void CheckAllPNJHaveGoodMask()
    {
        GameObject[] pnjs = GameObject.FindGameObjectsWithTag("PNJ");

        foreach (GameObject pnj in pnjs)
        {
            PNJScript script = pnj.GetComponent<PNJScript>();

            if (script == null || !script.hasMask || !script.hasGoodMask)
                GameManager.Instance.maskToUpdate = joyMask;
                GameManager.Instance.pnjToUpdate = script;
                vfxMusicalNotesPNJ1.SetActive(true);
            vfxMusicalNotesPNJ2.SetActive(true);
            vfxMusicalNotesPNJ3.SetActive(true);
            vfxRain.SetActive(false);
            vfxFireworks.SetActive(true);
            return;
        }

        GameManager.Instance.canOpenDialogOrchestral = true;
        GameManager.Instance.dialogText = _dialogText;
    }

    public void ChangeSkybox()
    {
        if (SkyboxHappy != null)
        {
            RenderSettings.skybox = SkyboxHappy;
            DynamicGI.UpdateEnvironment();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckAllPNJHaveGoodMask();
            ChangeSkybox();
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
