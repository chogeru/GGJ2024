using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStopCol : MonoBehaviour
{
    EnemySystem enemySystem;
    public int m_ClickCount;
    private int m_TargetClickCount;
    [SerializeField]
    private int m_MinClicCount=3;
    [SerializeField]
    private int m_MaxClicCount=9;

    private void Start()
    {
        enemySystem = GetComponentInParent<EnemySystem>();
        ResetClickCount();
    }

    private void Update()
    {
        if (m_ClickCount >= m_TargetClickCount)
        {
            enemySystem.isAttckStop = true;
            ResetClickCount();
            gameObject.SetActive(false);
        }
    }

    private void ResetClickCount()
    {
        m_ClickCount = 0;
        m_TargetClickCount = Random.Range(m_MinClicCount, m_MaxClicCount);
    }
}
