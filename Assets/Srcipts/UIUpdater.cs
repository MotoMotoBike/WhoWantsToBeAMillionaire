using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] QuizGameSessionData data;

    [SerializeField] TextMeshProUGUI userName;
    [SerializeField] TextMeshProUGUI userScore;

    [SerializeField] TextMeshProUGUI endGameScore;
    [SerializeField] TextMeshProUGUI completteQuestionsCount;
    [SerializeField] TextMeshProUGUI endGameUser;

    [SerializeField] TextMeshProUGUI question;
    [SerializeField] TextMeshProUGUI button1;
    [SerializeField] TextMeshProUGUI button2;
    [SerializeField] TextMeshProUGUI button3;
    [SerializeField] TextMeshProUGUI button4;

    [SerializeField] GameObject hart1;
    [SerializeField] GameObject hart2;
    [SerializeField] GameObject hart3;

    [SerializeField] GameObject WrongAnsver;
    [SerializeField] GameObject CorrectAnsver;
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject GameSessionPanel;

    [SerializeField] AudioClip WrongClip;
    [SerializeField] AudioClip CorrectClip;
    [SerializeField] AudioSource source;

    [SerializeField] Animator[] anims;

    [SerializeField] UnityEngine.UI.Button[] buttons;
    public void ShowWinGamePanel()
    {
        endGameUser.text = data.playerName;
        GameSessionPanel.SetActive(false);
        WinPanel.SetActive(true);
    }

    public void UpdateUI()
    {
        buttons.ToList().ForEach(i => i.interactable = true);
        userName.text = data.playerName;
        userScore.text = data.score.ToString();
        question.text = data.currentQuestion.Text;
        button1.text = data.currentQuestion.Answers[0];
        button2.text = data.currentQuestion.Answers[1];
        button3.text = data.currentQuestion.Answers[2];
        button4.text = data.currentQuestion.Answers[3];
        completteQuestionsCount.text = (data.qestionCompleteCount + 1).ToString();


        UpdateLives();
    }
    public void NextQusetion()
    {
        anims.ToList().ForEach(i => i.SetTrigger("Flip"));
        Invoke("UpdateUI", 0.55f);
    }
    public void SetEndGamePanel()
    {
        endGameScore.text = "Счет : " + data.score.ToString();
        GameSessionPanel.SetActive(false);
        LosePanel.SetActive(true);
    }
    public void CorrectAnswer()
    {
        StartCoroutine(ShowCorrectMessageBox());
        UpdateUI();
    }
    public IEnumerator ShowWrongMessageBox()
    {
        StopAllCoroutines();
        source.clip = WrongClip;
        source.Play();
        
        WrongAnsver.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        WrongAnsver.SetActive(false);
    
    }
    public IEnumerator ShowCorrectMessageBox()
    {
        StopAllCoroutines();
        source.clip = CorrectClip;
        source.Play();
        CorrectAnsver.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        CorrectAnsver.SetActive(false);
        
    }
    public void UpdateLives()
    {
        switch (data.lives)
        {
            case 1:
                {
                    hart1.SetActive(false);
                    hart2.SetActive(false);
                    hart3.SetActive(true);
                    break;
                }
            case 2:
                {
                    hart1.SetActive(false);
                    hart2.SetActive(true);
                    hart3.SetActive(true);
                    break;
                }
            case 3:
                {
                    hart1.SetActive(true);
                    hart2.SetActive(true);
                    hart3.SetActive(true);
                    break;
                }
        }
    }
}
