using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject gameSessionPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] QuizGameSessionData gameData;

    [SerializeField] TextMeshProUGUI PlayerNameText;
    public void StartGameSession()
    {
        string userName = PlayerNameText.text;
        if (userName == "​" || userName == "" )
        {
            userName = "Испытуемый: "+Random.Range(0,10000).ToString();
        }
        mainMenuPanel.SetActive(false);
        losePanel.SetActive(false);
        gameData.StartSession(userName);
        gameSessionPanel.SetActive(true);
    }
}
