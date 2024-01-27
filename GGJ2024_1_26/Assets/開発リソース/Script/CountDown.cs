using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField, Header("�J�E���g�_�E���̎���")]
    private float m_CountDownTime = 60.0f;
    [SerializeField, Header("�J�E���g�_�E���pText�I�u�W�F�N�g")]
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
        //�c�莞�Ԃ𕪂ƕb�ɕϊ�
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        m_CountDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
