using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0f;
    private bool isRunning = false;

    void Start()
    {
        // Vérifie si le timer doit démarrer après le chargement
        if (GameState.StartTimerOnLoad)
        {
            StartTimer();
            GameState.StartTimerOnLoad = false; // Réinitialise l'état
        }
        if (GameState.RetryTriggered)
        {
            StartTimer();
            GameState.RetryTriggered = false; // Réinitialise le signal
        }
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);

            if (timerText != null)
            {
                timerText.text = $"{minutes} :{(minutes > 1 ? "s" : "")} {seconds} {(seconds > 1 ? "s" : "")}";
            }
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        isRunning = false;
    }
}
