using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonobitEngine;
public class ClickHandler : MonobitEngine.MonoBehaviour
{
    MonobitEngine.MonobitView m_MonobitView = null;
    [SerializeField]
    private AudioSource m_AudioSource;
    [SerializeField]
    private AudioClip m_HitPointHitSE;
    [SerializeField]
    private AudioClip m_AttackStopHitSE;

    [SerializeField]
    private GameObject m_HitPointHitEffect;
    [SerializeField]
    private GameObject m_AttackStopHitEffect;
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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (MonobitEngine.MonobitNetwork.offline == false)
            {
                m_MonobitView.RPC("RayShot", MonobitEngine.MonobitTargets.All, null);
            }
            else
            {
                RayShot();
            }
        }
    }

    [MunRPC]
    void RayShot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("HitPoint"))
            {
                HitPoint hitPointComponent = hit.collider.GetComponent<HitPoint>();
                hitPointComponent.isHit = true;
                m_AudioSource.clip = m_HitPointHitSE;
                Instantiate(m_HitPointHitEffect,hit.transform.position,Quaternion.identity);
                m_AudioSource.Play();
            }
            if(hit.collider.CompareTag("AttackStopPoint"))
            {
                AttackStopCol attackStopCol =hit.collider.GetComponent<AttackStopCol>();
                attackStopCol.m_ClickCount++;
                Instantiate(m_AttackStopHitEffect, hit.transform.position, Quaternion.identity);
                m_AudioSource.clip = m_AttackStopHitSE;
                m_AudioSource.Play();
            }
        }
    }
}
