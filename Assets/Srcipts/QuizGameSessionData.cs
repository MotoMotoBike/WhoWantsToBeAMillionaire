using Assets.Srcipts.Model;
using UnityEngine;
using YG;

public class QuizGameSessionData : MonoBehaviour
{
    ParcerXML parcerXML;
    [SerializeField]int countToEndQizz;

    public string playerName;
    public int lives = 3;
    public int qestionCompleteCount = 0;
    public int score = 0;

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
            SetNextQustion();
            UIUpdater.NextQusetion();
            StartCoroutine(UIUpdater.ShowCorrectMessageBox());
        }
        else
        {
            YandexGame.FullscreenShow();
            AnswerWrong();
        }
    }

    public void SetNextQustion()
    {
        qestionCompleteCount++;
        if(qestionCompleteCount == countToEndQizz)
        {
            UIUpdater.ShowWinGamePanel();
            Destroy(this);
        }
        quiz.Questions.Remove(currentQuestion);
        currentQuestion = quiz.Questions[Random.Range(0, quiz.Questions.Count)];
        if (score == 0)
            score = 100;
        else
        {
            score *= 2;
        }
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
        UIUpdater.NextQusetion();
    }
}
