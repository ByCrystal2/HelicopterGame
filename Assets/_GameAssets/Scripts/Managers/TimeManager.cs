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

        // Her dakika baþýna doðru olacak þekilde tetikleme noktalarý
        HashSet<int> twoMinuteMarks = new HashSet<int>();
        HashSet<int> threeMinuteMarks = new HashSet<int>();
        HashSet<int> fourMinuteMarks = new HashSet<int>();
        HashSet<int> fiveMinuteMarks = new HashSet<int>();
        HashSet<int> tenMinuteMarks = new HashSet<int>();

        // Dakikalarý iþaretleyerek baþlatýyoruz
        for (int i = 2; i < 60; i += 2) twoMinuteMarks.Add(i);
        for (int i = 3; i < 60; i += 3) threeMinuteMarks.Add(i);
        for (int i = 4; i < 60; i += 4) fourMinuteMarks.Add(i);
        for (int i = 5; i < 60; i += 5) fiveMinuteMarks.Add(i);
        for (int i = 10; i < 60; i += 10) tenMinuteMarks.Add(i);

        while (true)
        {
            yield return new WaitForSeconds(1f); // 1 saniye bekle
            CurrentDateTime = CurrentDateTime.AddSeconds(1); // Zamaný ilerlet
            if (CurrentDateTime.Minute != lastMinute)
            {
                Debug.Log("CurrentDateTime dakika: " + CurrentDateTime.Minute);
                lastMinute = CurrentDateTime.Minute;

                // **1 Dakika iþlemleri**
                Debug.Log("1 dakika iþlemleri çalýþýyor...");
                OnOneMinutePassed?.Invoke();

                // **Diðer iþlemler**
                if (twoMinuteMarks.Contains(CurrentDateTime.Minute))
                {
                    Debug.Log("2 dakika iþlemleri çalýþýyor...");
                    OnTwoMinutePassed?.Invoke();
                }
                if (threeMinuteMarks.Contains(CurrentDateTime.Minute))
                {
                    Debug.Log("3 dakika iþlemleri çalýþýyor...");
                    OnThreeMinutePassed?.Invoke();
                }
                if (fourMinuteMarks.Contains(CurrentDateTime.Minute))
                {
                    Debug.Log("4 dakika iþlemleri çalýþýyor...");
                    OnFourMinutePassed?.Invoke();
                }
                if (fiveMinuteMarks.Contains(CurrentDateTime.Minute))
                {
                    Debug.Log("5 dakika iþlemleri çalýþýyor...");
                    OnFiveMinutePassed?.Invoke();
                }
                if (tenMinuteMarks.Contains(CurrentDateTime.Minute))
                {
                    Debug.Log("10 dakika iþlemleri çalýþýyor...");
                    OnTenMinutePassed?.Invoke();
                }
            }
        }
    }
}
