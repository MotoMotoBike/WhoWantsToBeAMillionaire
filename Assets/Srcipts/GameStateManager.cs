using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject gameSessionPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] QuizGameSessionData gameData;

    [SerializeField] TextMeshProUGUI PlayerNameText;
    public void StartGameSession()
    {
        mainMenuPanel.SetActive(false);
        losePanel.SetActive(false);
        gameData.StartSession(PlayerNameText.text);
        gameSessionPanel.SetActive(true);
    }
}
