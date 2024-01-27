using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;
    
    [Tab("オーディオソース")]
    [SerializeField]
    public AudioSource m_AudioSource;
    [Tab("SE"), Foldout("SE")]
    [SerializeField, Header("ルーム作成時のBGM")]
    private AudioClip m_RoomScreenBGM;
    [SerializeField, Header("Map1BGM")]
    private AudioClip m_Map1BGM;
    [SerializeField, Header("Map2BGM")]
    private AudioClip m_Map2BGM;
    [SerializeField, Header("Map3BGM")]
    private AudioClip m_Map3BGM;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        RoomScreenBGM();
    }

    public void RoomScreenBGM()
    {
        m_AudioSource.clip = m_RoomScreenBGM;
        m_AudioSource.Play();
    }
    public void SetMap1BGM()
    {
        m_AudioSource.clip = m_Map1BGM;
        m_AudioSource.Play();
    }
    public void SetMap2BGM()
    {
        m_AudioSource.clip = m_Map2BGM;
        m_AudioSource.Play();
    }
    public void SetMap3BGM()
    {
        m_AudioSource.clip= m_Map3BGM;
        m_AudioSource.Play();
    }
}
