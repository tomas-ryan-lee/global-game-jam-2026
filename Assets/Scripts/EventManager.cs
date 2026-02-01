using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public static event Action OnOpenDialogPanel;
    public static event Action OnCloseDialogPanel;
    public static event Action OnOpenOrchestralDialogPanel;
    public static event Action OnCloseOrchestralDialogPanel;
    public static event Action OnMusicPlayed;
    public static event Action OnMusicStopped;

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

    public static void DialogPanelOpened() => OnOpenDialogPanel?.Invoke();
    public static void DialogPanelClosed() => OnCloseDialogPanel?.Invoke();

    public static void OrchestralDialogPanelOpened() => OnOpenOrchestralDialogPanel?.Invoke();
    public static void OrchestralDialogPanelClosed() => OnCloseOrchestralDialogPanel?.Invoke();

    public static void PlayMusic() => OnMusicPlayed?.Invoke();
    public static void Music() => OnMusicStopped?.Invoke();
}
