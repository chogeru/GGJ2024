using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonobitEngine;
public class AttackStopCol : MonobitEngine.MonoBehaviour
{
    MonobitEngine.MonobitView m_MonobitView = null;

    EnemySystem enemySystem;
    public int m_ClickCount;
    private int m_TargetClickCount;
    [SerializeField]
    private int m_MinClicCount=3;
    [SerializeField]
    private int m_MaxClicCount=9;
    void Awake()
    {
        if (MonobitNetwork.offline == false)
        {
            if (GetComponentInParent<MonobitEngine.MonobitView>() != null)
            {
                m_MonobitView = GetComponentInParent<MonobitEngine.MonobitView>();
            }
            else if (GetComponentInChildren<MonobitEngine.MonobitView>() != null)
            {
                m_MonobitView = GetComponentInChildren<MonobitEngine.MonobitView>();
            }
            else
            {
                m_MonobitView = GetComponent<MonobitEngine.MonobitView>();
            }
        }
    }
    private void Start()
    {
        enemySystem = GetComponentInParent<EnemySystem>();
        ResetClickCount();
    }

    private void Update()
    {
        if (m_ClickCount >= m_TargetClickCount)
        {
            if (MonobitEngine.MonobitNetwork.offline == false)
            {
                m_MonobitView.RPC("EnemyAttackStop", MonobitEngine.MonobitTargets.All, null);
            }
            else
            {
                EnemyAttackStop();
            }
        }
    }
    [MunRPC]
    private void EnemyAttackStop()
    {
        enemySystem.isAttckStop = true;
        ResetClickCount();
        gameObject.SetActive(false);
    }
    private void ResetClickCount()
    {
        m_ClickCount = 0;
        m_TargetClickCount = Random.Range(m_MinClicCount, m_MaxClicCount);
    }
}
