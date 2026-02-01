using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public static event Action OnOpenDialogPanel;
    public static event Action OnCloseDialogPanel;
    public static event Action OnOpenOrchestralDialogPanel;
    public static event Action OnCloseOrchestralDialogPanel;
    public static event Action OnVictoryCameraSwitched;
    public static event Action<AudioClip> OnMusicPlayed;
    public static event Action OnMusicStopped;
    public static event Action OnVictoryScreenDisplayed;
    public static event Action<AudioClip, bool> OnSFXPlayed;
    public static event Action OnSFXStopped;

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

    public static void VictoryCameraSwitched() => OnVictoryCameraSwitched?.Invoke();
    public static void VictoryScreenDisplayed() => OnVictoryScreenDisplayed?.Invoke();

    public static void PlayMusic(AudioClip clip) => OnMusicPlayed?.Invoke(clip);
    public static void StopMusic() => OnMusicStopped?.Invoke();

    public static void PlaySFX(AudioClip clip, bool loop) => OnSFXPlayed?.Invoke(clip, loop);
    public static void StopSFX() => OnSFXStopped?.Invoke();
}
