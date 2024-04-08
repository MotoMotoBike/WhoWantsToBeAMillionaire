using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeToAnsver : MonoBehaviour
{
    [SerializeField] private float maxTime = 15;
    [SerializeField] private Text text;
    private float remainTime;
    public UnityEvent OnQestionExpired;
    
    public void ResetTimer()
    {
        remainTime = maxTime;
    }

    void Update()
    {
        remainTime -= Time.deltaTime;
        text.text = int.Parse(remainTime.ToString()).ToString();
        if (remainTime <= 0)
        {
            OnQestionExpired?.Invoke();
            remainTime = maxTime;
        }
    }
}
