using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    public string Text { get; set; }
    public List<string> Answers { get; set; }
    public int CorrectAnswerIndex { get; set; }
}
