using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }

    [SerializeField] private Canvas _dialogPanel;
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private GameObject _maskPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        EventManager.OnOpenDialogPanel += OpenDialog;
        EventManager.OnCloseDialogPanel += CloseDialog;
        EventManager.OnOpenOrchestralDialogPanel += OpenOrchestralDialog;
        EventManager.OnCloseOrchestralDialogPanel += CloseOrchestralDialog;
    }

    private void OnDisable()
    {
        EventManager.OnOpenDialogPanel -= OpenDialog;
        EventManager.OnCloseDialogPanel -= CloseDialog;
        EventManager.OnOpenOrchestralDialogPanel -= OpenOrchestralDialog;
        EventManager.OnCloseOrchestralDialogPanel -= CloseOrchestralDialog;
    }


    private void Start() {
        CloseDialog();
    }

    private void OpenDialog() {
        _dialogText.text = GameManager.Instance.dialogText;
        _dialogPanel.enabled = true;
        EventManager.PlayMusic(MusicManager.Instance.dialogSound);
    }

    private void CloseDialog() => _dialogPanel.enabled = false;

    private void OpenOrchestralDialog()
    {
        OpenDialog();
        _maskPanel.SetActive(false);
        EventManager.PlayMusic(MusicManager.Instance.victorySound);
    }
    private void CloseOrchestralDialog()
    {
        CloseDialog();
        _maskPanel.SetActive(true);
    }
}
