using Assets.Srcipts.Model;
using UnityEngine;
using YG;

public class QuizGameSessionData : MonoBehaviour
{
    ParcerXML parcerXML;

    public string playerName;
    public int lives = 3;
    public int qestionCompleteCount = 0;
    public int score = 0;
    public int AnsversCountToWin = 100;

    public Quiz quiz;
    public Question currentQuestion;
    public UIUpdater UIUpdater;

    private void Awake()
    {
        parcerXML = FindObjectOfType<ParcerXML>();
    }
    public void StartSession(string playerName)
    {
        quiz = parcerXML.ParseQuizXml();
        Debug.Log($"found {quiz.Questions.Count} Questions in xml");
        score = 0;
        this.playerName = playerName;
        lives = 3;
        qestionCompleteCount = 0;
        currentQuestion = quiz.Questions[Random.Range(0, quiz.Questions.Count)];
        UIUpdater.UpdateUI();
    }
    public void EndSession()
    {
        UIUpdater.SetEndGamePanel();
    }

    public void getAnsver(int ansverid)
    {
        if(currentQuestion.CorrectAnswerIndex == ansverid)
        {
            AnswerCorrect();
        }
        else
        {
            AnswerWrong();
        }
    }

    public void SetNextQustion()
    {
        qestionCompleteCount++;
        if(quiz.Questions.Count == 0) 
        {
            UIUpdater.ShowWinGamePanel();
            Destroy(this);
        }
        quiz.Questions.Remove(currentQuestion);
        currentQuestion = quiz.Questions[Random.Range(0, quiz.Questions.Count)];
        score += 100;
        
    }
    public void AnswerWrong()
    {
        lives--;
        if(lives != 0){
            StartCoroutine(UIUpdater.ShowWrongMessageBox());
            UIUpdater.UpdateLives();
        }
        else
        {
            EndSession();
        }
    }
    public void AnswerCorrect()
    {
        SetNextQustion();
        UIUpdater.NextQusetion();
        StartCoroutine(UIUpdater.ShowCorrectMessageBox());
    }
}
