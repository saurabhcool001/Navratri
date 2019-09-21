using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{

    public TextMeshProUGUI timerText;

    bool timeOvercondition = false;
    bool onetimeplayed = false;
    float startTimer;

    public AudioSource countdownFX;

    private void Start()
    {
        startTimer = 12f;
    }

    void Update()
    {
        if (TimeOver())
            return;

        float t = startTimer- Time.time;
        string seconds = (t % 60).ToString("f0");

        if (t < 10f)
        {
            timerText.color = Color.red;

            if (!onetimeplayed) {
                PlayCountDownSound(true);
            }
            
        }

        if (t < 0.5f)
        {
            timeOvercondition = true;
            PlayCountDownSound(false);
        }
        timerText.text = seconds;

    }

    void PlayCountDownSound(bool go)
    {

        
        if (go == true)
            StartCoroutine(PlaySoundEvery(1.0f, 10));
            onetimeplayed = true;
    }

    private bool TimeOver()
    {
        if (timeOvercondition)
            return true;

        return false;
    }

    IEnumerator PlaySoundEvery(float t, int times)
    {
        for (int i = 0; i < times; i++)
        {

            print("play method enter");
            countdownFX.Play();
            yield return new WaitForSeconds(t);
        }

        //times up sound
    }

}
