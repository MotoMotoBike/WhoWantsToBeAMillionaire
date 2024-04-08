using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiideIfHPLow : MonoBehaviour
{
    [SerializeField] private QuizGameSessionData _data;
    [SerializeField] private GameObject go;
    void FixedUpdate()
    {
        if (_data.lives < 3)
        {
            go.SetActive(true);
        }
        else
        {
            go.SetActive(false);
        }
    }
}
