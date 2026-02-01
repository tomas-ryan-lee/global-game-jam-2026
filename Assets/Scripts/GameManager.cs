using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum GameState { menu, inGame, pause, resume }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Camera Settings")]
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Camera _victoryCamera;

    [Header("Dialog Settings")]
    public bool canOpenDialog;
    public bool canOpenDialogOrchestral;
    public string dialogText;

    [Header("PNJ Settings")]
    public PNJScript pnjToUpdate;
    public GameObject maskToUpdate;

    private GameState _state;

    private void OnEnable() {
        EventManager.OnVictoryCameraSwitched += SwitchToVictoryCamera;
    }

    private void OnDisable() {
        EventManager.OnVictoryCameraSwitched -= SwitchToVictoryCamera;
    }

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

    private void Start() {
        SwitchToMainCamera();
    }

    private void Update()
    {
        OpenDialog();
        OpenDialogOrchestral();
    }

    #region GameStates
    public void GameMenu()
    {
        _state = GameState.menu;
        Time.timeScale = 0;
    }

    public void GamePlay()
    {
        _state = GameState.inGame;
        Time.timeScale = 1;
        EventManager.PlayMusic(MusicManager.Instance.mainSound);
    }

    public void GamePause()
    {
        _state = GameState.pause;
        Time.timeScale = 0;
    }

    public void GameResume()
    {
        if (_state != GameState.pause) return;

        _state = GameState.resume;
        Time.timeScale = 1;
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    #endregion

    #region GlobalActions
    public void OpenDialog()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenDialog)
        {
            EventManager.DialogPanelOpened();
        }
    }

    public void OpenDialogOrchestral()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenDialogOrchestral)
        {
            EventManager.OrchestralDialogPanelOpened();
        }
    }

    public void ChangeMask(GameObject newMask, EmotionsList emotion)
    {
        if (!maskToUpdate || !pnjToUpdate) return;

        // Sauvegarde des transforms
        Vector3 position = maskToUpdate.transform.position;
        Vector3 scale = maskToUpdate.transform.localScale;
        Quaternion rotation = Quaternion.identity;
        Transform parentTransform = maskToUpdate.transform.parent;

        // Suppression de l'ancien
        Destroy(maskToUpdate.gameObject);

        // Instanciation du nouveau
        GameObject newMaskInstance = Instantiate(
            newMask,
            position,
            rotation,
            parentTransform
        );

        pnjToUpdate.hasMask = true;
        if (emotion == pnjToUpdate.emotion) {
            pnjToUpdate.hasGoodMask = true;
        }

        CloseDialog();
    }

    private void CloseDialog() => EventManager.DialogPanelClosed();
    private void CloseDialogOrchestral() => EventManager.OrchestralDialogPanelClosed();

    private void SwitchToMainCamera()
    {
        _mainCamera.enabled = true;
        _victoryCamera.enabled = false;
    }
    private void SwitchToVictoryCamera()
    {
        _mainCamera.enabled = false;
        _victoryCamera.enabled = true;
    }

    #endregion
}
