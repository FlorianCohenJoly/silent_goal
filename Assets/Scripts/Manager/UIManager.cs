using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseUI;
    public Timer timer;
    public GameObject yellowCardImage;
    public GameObject yellowCardImage1;
    public GameObject RedCardImage;
    public GameObject uiPanelCard;

    public GameObject retryPanel;
    public void OnGameResumePress()
    {
        pauseUI.SetActive(false);
        timer.StartTimer();
    }

    public void OnGameExitPress()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void OnEnterPause()
    {
        pauseUI.SetActive(true);
        timer.StopTimer();

    }

    public void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            OnEnterPause();
        }

    }

    public void RetryGame()
    {

        GameState.RetryTriggered = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        
    }
}
