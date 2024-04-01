using Assets.Srcipts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class ParcerXML : MonoBehaviour
{
    public string quizFileName = "quiz.xml";

    public Quiz ParseQuizXml()
    {
        TextAsset xmlAsset = Resources.Load<TextAsset>(Path.GetFileNameWithoutExtension(quizFileName));
        var quiz = new Quiz();
        var xmlDocument = new XmlDocument();

        xmlDocument.LoadXml(xmlAsset.text);
        
        var questionsNodeList = xmlDocument.SelectNodes("//question");
        quiz.Questions = new List<Question>(questionsNodeList.Count);

        foreach (XmlNode questionNode in questionsNodeList)
        {
            var question = new Question();
            question.Text = questionNode.SelectSingleNode("text").InnerText;

            var answersNodeList = questionNode.SelectNodes("answer");
            question.Answers = new List<string>(answersNodeList.Count);
            for (int i = 0; i < answersNodeList.Count; i++)
            {
                question.Answers.Add(answersNodeList[i].InnerText);

                if (answersNodeList[i].Attributes["correct"] != null && answersNodeList[i].Attributes["correct"].Value == "true")
                {
                    question.CorrectAnswerIndex = i;
                }
            }
            quiz.Questions.Add(question);
        }
        return quiz;
    }
}
