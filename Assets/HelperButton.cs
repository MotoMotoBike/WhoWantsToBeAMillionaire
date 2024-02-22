using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HelperButton : MonoBehaviour
{
    [SerializeField]QuizGameSessionData data;
    [SerializeField] Button[] buttons; 
    public void DoHelp()
    {
        int deletedCount = 0;
        int deletedIndex = 999;
        while (deletedCount < buttons.Where(i => i.interactable == true).Count())
        {
            var to_del = Random.Range(0, buttons.Length);
            if(to_del != data.currentQuestion.CorrectAnswerIndex && (deletedIndex != to_del))
            {
                buttons[to_del].interactable = false;
                deletedIndex = to_del;
                deletedCount++;
            }
        }
        GetComponent<Button>().interactable = false;
        try
        {
            GetComponentInChildren<TextMeshProUGUI>().color = GetComponent<Button>().colors.disabledColor;
        }
        catch { }
        Destroy(this);
    }
}
