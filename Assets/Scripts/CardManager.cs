using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    private int yellowCards = 0;
    public UIManager uiManager;

    private void Awake()
{
    if (Instance == null)
    {
        Instance = this;
    }
    else
    {
        Destroy(gameObject);
    }

    if (uiManager == null)
    {
        uiManager = FindObjectOfType<UIManager>();
    }
}


    public void AddYellowCard()
    {
        yellowCards++;

        if (yellowCards == 1)
        {
            uiManager.uiPanelCard.SetActive(true);
            uiManager.yellowCardImage.SetActive(true);
            Debug.Log("Player received the first yellow card!");
        }
        else if (yellowCards == 2)
        {
            uiManager.yellowCardImage1.SetActive(true);
            uiManager.RedCardImage.SetActive(true);
            Debug.Log("Player received a red card and the game is over!");
            uiManager.timer.StopTimer();
            uiManager.retryPanel.SetActive(true);
        }
    }
}
