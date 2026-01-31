using System.Security.Cryptography.X509Certificates;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum GameState { menu, inGame, pause, resume }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool canOpenDialog;
    public string dialogText;
    public GameObject maskToUpdate;
    private GameState _state;

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

    private void Update()
    {
        OpenDialog();
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

    public void ChangeMask(GameObject newMask)
    {
        if (!maskToUpdate) return;

        // Sauvegarde des transforms
        Transform oldTransform = maskToUpdate.transform;
        Vector3 position = oldTransform.position;
        Quaternion rotation = oldTransform.rotation;
        Transform parentTransform = oldTransform.parent;

        // Suppression de l'ancien
        Destroy(maskToUpdate.gameObject);

        // Instanciation du nouveau
        GameObject newMaskInstance = Instantiate(
            newMask,
            position,
            rotation,
            parentTransform
        );

        // (Optionnel) garder l'échelle
        // newMaskInstance.transform.localScale = oldTransform.localScale;

        CloseDialog();

        Debug.Log("Removed");
    }

    private void CloseDialog() => EventManager.DialogPanelClosed();

    #endregion
}
