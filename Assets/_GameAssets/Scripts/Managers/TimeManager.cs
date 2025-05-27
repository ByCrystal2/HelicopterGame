using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public DateTime CurrentDateTime; // Su an ki mevcut zamani tutar.
    //Delegates
    public delegate void MinutePassedDelegate();
    public event MinutePassedDelegate OnOneMinutePassed;
    public event MinutePassedDelegate OnTwoMinutePassed;
    public event MinutePassedDelegate OnThreeMinutePassed;
    public event MinutePassedDelegate OnFourMinutePassed;
    public event MinutePassedDelegate OnFiveMinutePassed;
    public event MinutePassedDelegate OnTenMinutePassed;

    public static TimeManager instance { get; set; }
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        StartCoroutine(TimeProgress());
    }
    private IEnumerator TimeProgress()
    {
        int lastMinute = CurrentDateTime.Minute;

        // Her dakika ba��na do�ru olacak �ekilde tetikleme noktalar�
        HashSet<int> twoMinuteMarks = new HashSet<int>();
        HashSet<int> threeMinuteMarks = new HashSet<int>();
        HashSet<int> fourMinuteMarks = new HashSet<int>();
        HashSet<int> fiveMinuteMarks = new HashSet<int>();
        HashSet<int> tenMinuteMarks = new HashSet<int>();

        // Dakikalar� i�aretleyerek ba�lat�yoruz
        for (int i = 2; i < 60; i += 2) twoMinuteMarks.Add(i);
        for (int i = 3; i < 60; i += 3) threeMinuteMarks.Add(i);
        for (int i = 4; i < 60; i += 4) fourMinuteMarks.Add(i);
        for (int i = 5; i < 60; i += 5) fiveMinuteMarks.Add(i);
        for (int i = 10; i < 60; i += 10) tenMinuteMarks.Add(i);

        while (true)
        {
            yield return new WaitForSeconds(1f); // 1 saniye bekle
            CurrentDateTime = CurrentDateTime.AddSeconds(1); // Zaman� ilerlet
            if (CurrentDateTime.Minute != lastMinute)
            {
                Debug.Log("CurrentDateTime dakika: " + CurrentDateTime.Minute);
                lastMinute = CurrentDateTime.Minute;

                // **1 Dakika i�lemleri**
                Debug.Log("1 dakika i�lemleri �al���yor...");
                OnOneMinutePassed?.Invoke();

                // **Di�er i�lemler**
                if (twoMinuteMarks.Contains(CurrentDateTime.Minute))
                {
                    Debug.Log("2 dakika i�lemleri �al���yor...");
                    OnTwoMinutePassed?.Invoke();
                }
                if (threeMinuteMarks.Contains(CurrentDateTime.Minute))
                {
                    Debug.Log("3 dakika i�lemleri �al���yor...");
                    OnThreeMinutePassed?.Invoke();
                }
                if (fourMinuteMarks.Contains(CurrentDateTime.Minute))
                {
                    Debug.Log("4 dakika i�lemleri �al���yor...");
                    OnFourMinutePassed?.Invoke();
                }
                if (fiveMinuteMarks.Contains(CurrentDateTime.Minute))
                {
                    Debug.Log("5 dakika i�lemleri �al���yor...");
                    OnFiveMinutePassed?.Invoke();
                }
                if (tenMinuteMarks.Contains(CurrentDateTime.Minute))
                {
                    Debug.Log("10 dakika i�lemleri �al���yor...");
                    OnTenMinutePassed?.Invoke();
                }
            }
        }
    }
}
