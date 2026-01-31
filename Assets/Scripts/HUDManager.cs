using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }

    [SerializeField] private Canvas _dialogPanel;
    [SerializeField] private TMP_Text _dialogText;

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
    }

    private void OnDisable()
    {
        EventManager.OnOpenDialogPanel -= OpenDialog;
    }


    private void Start() {
        CloseDialog();
    }

    private void OpenDialog() {
        _dialogText.text = GameManager.Instance.dialogText;
        _dialogPanel.enabled = true;
    }

    private void CloseDialog() => _dialogPanel.enabled = false;
}
