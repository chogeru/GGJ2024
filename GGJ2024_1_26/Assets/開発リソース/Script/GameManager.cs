using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] m_EnemyObjects; 
    public GameObject m_GameCleaCanvas;
    [SerializeField]
    private AudioClip m_CleaBGM;
    private bool isSpown=true;
    public bool isGameEnd=false;
    void Update()
    {
        bool allObjectsDestroyed = true;
        foreach (GameObject obj in m_EnemyObjects)
        {
            if (obj != null)
            {
                allObjectsDestroyed = false;
                break;
            }
        }

        if (allObjectsDestroyed&&isSpown)
        {
            Instantiate(m_GameCleaCanvas, transform.position, transform.rotation);
            isGameEnd = true;
            isSpown = false;
            BGMManager.Instance.m_AudioSource.clip = m_CleaBGM;
            BGMManager.Instance.m_AudioSource.Play();
        }
    }
}
