using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonobitEngine;
public class EnemySystem : MonobitEngine.MonoBehaviour
{
    MonobitEngine.MonobitView m_MonobitView = null;

    [SerializeField, Header("スポナー")]
    GameObject spawner;
    [SerializeField]
    private GameObject[] m_AttackStopObj;

    [SerializeField]
    private Animator animator;
    [SerializeField,Header("お笑いポイント")]
    public int m_ComedyPoint;
    [SerializeField,Header("最大お笑いポイント")]
    public int m_MaxComedyPoint;
    private float m_NextAttackTime;

    [SerializeField, Header("最短攻撃時間")]
    private float m_MinAttackTime=3f;
    [SerializeField,Header("最長攻撃時間")]
    private float m_MaxAttackTime=9f;
    [SerializeField,Header("ゲージ")]
    private GameObject m_SliderPrefab;
    [SerializeField, Header("スライダー生成位置の高さ")]
    private float sliderSpawnHeight = 1.0f;
    [SerializeField, Header("スライダーのサイズ")]
    private Vector3 sliderSize = new Vector3(1.0f, 1.0f, 1.0f);

    [SerializeField, Header("攻撃ヒット時のUI")]
    private GameObject m_AttackHitCanvas;

    public bool isAttckStop=false;
    private bool isAttack = false;
    public bool isLastBoss = false;
    public bool isCountStop=false;
    void Awake()
    {
        if (MonobitNetwork.offline == false)
        {
            // すべての親オブジェクトに対して MonobitView コンポーネントを検索する
            if (GetComponentInParent<MonobitEngine.MonobitView>() != null)
            {
                m_MonobitView = GetComponentInParent<MonobitEngine.MonobitView>();
            }
            // 親オブジェクトに存在しない場合、すべての子オブジェクトに対して MonobitView コンポーネントを検索する
            else if (GetComponentInChildren<MonobitEngine.MonobitView>() != null)
            {
                m_MonobitView = GetComponentInChildren<MonobitEngine.MonobitView>();
            }
            // 親子オブジェクトに存在しない場合、自身のオブジェクトに対して MonobitView コンポーネントを検索して設定する
            else
            {
                m_MonobitView = GetComponent<MonobitEngine.MonobitView>();
            }
        }
    }

    void Start()
    {
        SetNextAttackTime();
        AddSlider();
    }

    void Update()
    {
        if (Time.time >= m_NextAttackTime)
        {
            if (MonobitEngine.MonobitNetwork.offline == false)
            {
                m_MonobitView.RPC("Attack", MonobitEngine.MonobitTargets.All, null);
            }
            else
            {
                Attack();
            }
        }
        if(m_ComedyPoint==m_MaxComedyPoint)
        {
            if (MonobitEngine.MonobitNetwork.offline == false)
            {
                m_MonobitView.RPC("Die", MonobitEngine.MonobitTargets.All, null);
            }
            else
            {
                Die();
            }
        }
        if(m_ComedyPoint>=m_MaxComedyPoint)
        {
            m_ComedyPoint = m_MaxComedyPoint;
        }
        if(isAttckStop)
        {
            if (MonobitEngine.MonobitNetwork.offline == false)
            {
                m_MonobitView.RPC("EndAttck", MonobitEngine.MonobitTargets.All, null);
                isAttckStop = false;
            }
            else
            {
                EndAttck();
                isAttckStop=false;
            }
        }
        if(isAttack)
        {
            if (MonobitEngine.MonobitNetwork.offline == false)
            {
                m_MonobitView.RPC("ActivateAttackStopObjects", MonobitEngine.MonobitTargets.All, null);
            }
            else
            {
                ActivateAttackStopObjects();
            }
        }
    }
    [MunRPC]
    void Attack()
    {
        animator.SetBool("Attack", true);
        isAttack = true;
        if (MonobitEngine.MonobitNetwork.offline == false)
        {
            m_MonobitView.RPC("SetNextAttackTime", MonobitEngine.MonobitTargets.All, null);
        }
        else
        {
            SetNextAttackTime();
        }
    }
    [MunRPC]
    public void EndAttck()
    {
        animator.SetBool("Attack", false);
        isAttack = false;
        if (MonobitEngine.MonobitNetwork.offline == false)
        {
            m_MonobitView.RPC("UseAttackStopObjects", MonobitEngine.MonobitTargets.All, null);
        }
        else
        {
            UseAttackStopObjects();
        }
    }
    public void ResetPoint()
    {
        m_ComedyPoint = 0;
        Instantiate(m_AttackHitCanvas);
    }
    [MunRPC]
    void SetNextAttackTime()
    {
        m_NextAttackTime = Time.time + Random.Range(m_MinAttackTime, m_MaxAttackTime);
    }
    void AddSlider()
    {
        if (m_SliderPrefab == null)
        {
            return;
        }
        Vector3 spawnPosition = transform.position + Vector3.up * sliderSpawnHeight;
        GameObject sliderObject = Instantiate(m_SliderPrefab, spawnPosition, Quaternion.identity,transform);
        sliderObject.transform.localScale = sliderSize;
    }
    [MunRPC]
    private void Die()
    {
        animator.SetBool("Die", true);
        UseAttackStopObjects();
        if(isLastBoss)
        {
            isCountStop = true;
        }
        Destroy(spawner);
    }
    public void EndDie()
    {
        animator.SetBool("Die", false);
        Destroy(gameObject);
    }
    [MunRPC]
    public void ActivateAttackStopObjects()
    {
        foreach (GameObject obj in m_AttackStopObj)
        {
            obj.SetActive(true);
        }
    }
    [MunRPC]
    public void UseAttackStopObjects()
    {
        foreach (GameObject obj in m_AttackStopObj)
        {
            obj.SetActive(false);
        }
    }
}
