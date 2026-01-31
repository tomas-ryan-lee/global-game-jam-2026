using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum GameState { menu, inGame, pause, resume }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameState _state;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
       GameMenu();
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
        if (_state != GameState.inGame) return;

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
}
