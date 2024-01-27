using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonobitEngine;
public class EnemySystem : MonobitEngine.MonoBehaviour
{
    MonobitEngine.MonobitView m_MonobitView = null;

    public Animator animator;
    [SerializeField,Header("お笑いポイント")]
    public int m_ComedyPoint;
    [SerializeField,Header("最大お笑いポイント")]
    public int m_MaxComedyPoint;
    private float m_NextAttackTime;

    [SerializeField,Header("ゲージ")]
    private GameObject m_SliderPrefab;
    [SerializeField, Header("スライダー生成位置の高さ")]
    private float sliderSpawnHeight = 1.0f;
    [SerializeField, Header("スライダーのサイズ")]
    private Vector3 sliderSize = new Vector3(1.0f, 1.0f, 1.0f);
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
    }
    [MunRPC]
    void Attack()
    {
        animator.SetBool("Attack", true);
        if (MonobitEngine.MonobitNetwork.offline == false)
        {
            m_MonobitView.RPC("SetNextAttackTime", MonobitEngine.MonobitTargets.All, null);
        }
        else
        {
            SetNextAttackTime();
        }
    }
    public void EndAttck()
    {
        animator.SetBool("Attack", false);
    }

    [MunRPC]
    void SetNextAttackTime()
    {
        m_NextAttackTime = Time.time + Random.Range(3f, 9f);
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
    }
    public void EndDie()
    {
        animator.SetBool("Die", false);
        Destroy(gameObject);
    }
}
