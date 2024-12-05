using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int timer_minutes = 2;
    public Score score_compter;

    private TextMeshPro text;
    private float current_time;
    private float start_time;
    private bool isStoped;
    private bool isReset;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        isStoped = true;
        isReset = true;
        current_time = timer_minutes * 60;
        text.SetText(ConvertTime(current_time));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStoped)
        {
            current_time = (timer_minutes * 60) - (Time.time - start_time);
            if (current_time > 0)
            {
                text.SetText(ConvertTime(current_time));
            }
            else
            {
                text.SetText("00:00");
                isStoped = true;
            }
        }
    }

    private string ConvertTime(float t)
    {
        string minutes = Mathf.Floor(t / 60).ToString("00");
        string seconds = Mathf.Floor(t % 60).ToString("00");
        return minutes + ":" + seconds;
    }

    public bool IsStoped()
    {
        return isStoped;
    }

    public bool IsReset()
    {
        return isReset;
    }

    public bool StartTimer()
    {
        bool started = false;
        if (isStoped && isReset)
        {
            isStoped = false;
            isReset = false;
            start_time = Time.time;
            started = true;
        }
        return started;
    }

    public void ResetTimer()
    {
        isStoped = true;
        isReset = true;
        current_time = timer_minutes * 60;
        text.SetText(ConvertTime(current_time));
        score_compter.Reset();
    }

    public Score GetScore()
    {
        return score_compter;
    }
}
