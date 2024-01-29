using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    EnemySystem enemySystem;
    [SerializeField, Header("カウントダウンの時間")]
    private float m_CountDownTime = 60.0f;
    [SerializeField, Header("カウントダウン用Textオブジェクト")]
    private TextMeshProUGUI m_CountDownText;
    [SerializeField, Header("ゲームオーバー用UI")]
    private GameObject m_GameOverUI;
    [SerializeField]
    GameManager m_GameManager;
    public bool isGameOver= false;

    private void Update()
    {
        if (m_GameManager.isGameEnd == false&&!enemySystem.isCountStop)
        {
            TimeCountDown();
        }
        if(m_GameManager.isGameEnd)
        {
            Destroy(gameObject);
        }
        if(m_CountDownTime==0&&!isGameOver)
        {
            Instantiate(m_GameOverUI);
            isGameOver = true;
            Destroy(gameObject);
        }
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
