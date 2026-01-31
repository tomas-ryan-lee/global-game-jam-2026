using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public static event Action OnOpenDialogPanel;
    public static event Action OnCloseDialogPanel;

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
}
