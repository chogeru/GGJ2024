using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    EnemySystem enemySystem;

    [SerializeField, Header("���₷���΂��|�C���g")]
    private int m_IncreasePoint;

    public bool isHit;

    private void Start()
    {
        enemySystem = GetComponentInParent<EnemySystem>();
    }
    private void Update()
    {
        if (isHit)
        {
            enemySystem.m_ComedyPoint += m_IncreasePoint;
            isHit = false;
        }

    }
}
