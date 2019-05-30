using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    private const int SECONDS_IN_DAY = 86400;
    
    private enum dayOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    private dayOfWeek day = dayOfWeek.Monday;
    public float time;
    public float speedUpFactor;
    public float slowDownFactor;
    public float maxTimeScale;
    public float minTimeScale;

    void Update()
    {
        time += Time.deltaTime;

        if (time >= SECONDS_IN_DAY)
        {
            time %= SECONDS_IN_DAY;
            NextDay();
        }
    }

    private void NextDay()
    {
        switch (day)
        {
            case dayOfWeek.Monday:
                day = dayOfWeek.Tuesday;
                break;
            case dayOfWeek.Tuesday:
                day = dayOfWeek.Wednesday;
                break;
            case dayOfWeek.Wednesday:
                day = dayOfWeek.Tuesday;
                break;
            case dayOfWeek.Thursday:
                day = dayOfWeek.Friday;
                break;
            case dayOfWeek.Friday:
                day = dayOfWeek.Saturday;
                break;
            case dayOfWeek.Saturday:
                day = dayOfWeek.Sunday;
                break;
            case dayOfWeek.Sunday:
                day = dayOfWeek.Monday;
                break;
        }
    }

    public string GetTimeString()
    {
        float timeInMinutes = time / 60;
        float seconds = time % 60;
        string hoursString = ((int)timeInMinutes / 60).ToString("00");
        string minutes = ((int)timeInMinutes % 60).ToString("00");
        return $"{day.ToString().ToUpper()} {hoursString}:{minutes}:{(int)seconds}";
    }

    public void DoSpeedUp()
    {
        Time.timeScale += speedUpFactor;
        FixTime();
    }

    public void DoSlowDown()
    {
        Time.timeScale -= slowDownFactor;
        FixTime();
    }

    private void FixTime()
    {
        Time.timeScale = Mathf.Clamp(Time.timeScale, minTimeScale, maxTimeScale);
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

}
