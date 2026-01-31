using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [Header("UI Screens")]
    [SerializeField] private Canvas menuScreen;
    [SerializeField] private Canvas pauseScreen;

    private void OnEnable()
    {
        InputManager.OnEscapePressed += HandleEscape;
    }

    private void OnDisable()
    {
        InputManager.OnEscapePressed -= HandleEscape;
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
        OnGameMenu();
    }

    public void OnGameMenu()
    {
        GameManager.Instance.GameMenu();

        menuScreen.enabled = true;
        pauseScreen.enabled = false;
    }

    public void OnGamePlay()
    {
        GameManager.Instance.GamePlay();

        menuScreen.enabled = false;
    }

    public void OnGamePause()
    {
        GameManager.Instance.GamePause();

        pauseScreen.enabled = true;
    }

    public void OnGameResume()
    {
        GameManager.Instance.GameResume();

        pauseScreen.enabled = false;
    }

    public void OnGameQuit()
    {
        GameManager.Instance.GameQuit();

        pauseScreen.enabled = false;
    }

    private void HandleEscape()
    {
        if (!pauseScreen.enabled)
            OnGamePause();
        else if (pauseScreen.enabled)
            OnGameResume();
    }

}
