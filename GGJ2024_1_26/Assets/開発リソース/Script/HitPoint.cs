using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonobitEngine;
public class HitPoint : MonobitEngine.MonoBehaviour
{
    MonobitEngine.MonobitView m_MonobitView = null;

    EnemySystem enemySystem;

    [SerializeField, Header("ëùÇ‚Ç∑Ç®èŒÇ¢É|ÉCÉìÉg")]
    private int m_IncreasePoint;

    public bool isHit;
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
    }
    private void Update()
    {
        if (isHit)
        {
            if (MonobitEngine.MonobitNetwork.offline == false)
            {
                m_MonobitView.RPC("SetHit", MonobitEngine.MonobitTargets.All, null);
            }
            else
            {
                SetHit();
            }
        }

    }
    [MunRPC]
    private void SetHit()
    {
        enemySystem.m_ComedyPoint += m_IncreasePoint;
        isHit = false;
    }
}
