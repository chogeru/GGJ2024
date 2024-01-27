using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SetComedyGage : MonoBehaviour
{
    EnemySystem enemySystem;

    [SerializeField]
    private Slider m_Slider;
    [SerializeField, Header("お笑いポイント表示用テキスト")]
    private TextMeshProUGUI m_Text;
    void Start()
    {
        enemySystem = GetComponentInParent<EnemySystem>();
        m_Slider.value = 0;
        SliderUpdate();
    }

    void Update()
    {
        SliderUpdate();
    }

    void SliderUpdate()
    {
        enemySystem.m_ComedyPoint = Mathf.Max(0, enemySystem.m_ComedyPoint);
        m_Slider.value = (float)enemySystem.m_ComedyPoint / (float)enemySystem.m_MaxComedyPoint;
        UpdateSliderText();
    }

    void UpdateSliderText()
    {
        float percentage = (float)enemySystem.m_ComedyPoint / (float)enemySystem.m_MaxComedyPoint * 100f;
        m_Text.text = $"{percentage:F0}%";
    }
}
