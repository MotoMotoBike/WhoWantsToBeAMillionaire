using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeToAnsver : MonoBehaviour
{
    [SerializeField] private float maxTime = 15;
    [SerializeField] private Text text;
    [SerializeField] private Color color1;
    [SerializeField] private Color color2;
    private float remainTime;
    public UnityEvent OnQestionExpired;

    private void Start()
    {
        ResetTimer();
    }

    public void ResetTimer()
    {
        remainTime = maxTime;
    }

    void Update()
    {
        remainTime -= Time.deltaTime;
        text.text = ((int)remainTime).ToString();
        text.color = Color.Lerp(color2, color1, remainTime / maxTime);
        if (remainTime <= 0)
        {
            OnQestionExpired?.Invoke();
            ResetTimer();
        }
    }
}
