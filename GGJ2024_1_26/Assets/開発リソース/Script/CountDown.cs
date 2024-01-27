using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField, Header("カウントダウンの時間")]
    private float m_CountDownTime = 60.0f;
    [SerializeField, Header("カウントダウン用Textオブジェクト")]
    private TextMeshProUGUI m_CountDownText;

    private void Update()
    {
        TimeCountDown();
    }
    public void TimeCountDown()
    {
        m_CountDownTime -= Time.deltaTime;
        if(m_CountDownTime < 0 )
        {
            m_CountDownTime = 0;
        }
        DisplayTime(m_CountDownTime);
    }
    private void DisplayTime(float time)
    {
        //残り時間を分と秒に変換
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        m_CountDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
