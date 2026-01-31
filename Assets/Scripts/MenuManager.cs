using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [Header("UI Screens")]
    [SerializeField] private Canvas menuScreen;
    [SerializeField] private Canvas pauseScreen;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
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
}
