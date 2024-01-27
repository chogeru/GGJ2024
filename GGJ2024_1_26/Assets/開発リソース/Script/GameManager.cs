using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("1�ԍŏ��ɏo��L�����N�^�[")]
    private GameObject[] m_FirstListObjects;
    [SerializeField, Header("2�Ԗڂɏo��L�����N�^�[")]
    private GameObject[] m_SecondListObjects;
    [SerializeField, Header("3�Ԗڂɏo��L�����N�^�[")]
    private GameObject[] m_ThirdListObjects;
    [SerializeField, Header("���[���ݒ�UI")]
    private GameObject m_RoomSettingUI;
    [SerializeField, Header("�N���A���o�pUI")]
    public GameObject m_GameClearCanvas;
    [SerializeField, Header("�N���A���BGM")]
    private AudioClip m_ClearBGM;
    private bool isSpawned = true;
    public bool isGameEnd = false;
    public enum StageType
    {
        Map1,
        Map2,
        Map3,
    }
    public StageType stageType;
    private void Start()
    {
        switch (stageType)
        {
            case StageType.Map1:
                BGMManager.Instance.SetMap1BGM();
                break;
            case StageType.Map2:
                BGMManager.Instance.SetMap2BGM();
                break;
            case StageType.Map3:
                BGMManager.Instance.SetMap3BGM();
                break;
            default:
                break;
        }
    }
    void Update()
    {
        m_RoomSettingUI.SetActive(false);
        if (isSpawned)
        {
            foreach (GameObject obj in m_FirstListObjects)
            {
                if (obj != null && obj.activeSelf)
                {
                    SetListObjectsActive(m_SecondListObjects, false);
                    SetListObjectsActive(m_ThirdListObjects, false);
                    break;
                }
            }

            if (AreAllObjectsDestroyed(m_FirstListObjects))
            {
                SetListObjectsActive(m_SecondListObjects, true);
            }
            if (AreAllObjectsDestroyed(m_SecondListObjects))
            {
                SetListObjectsActive(m_ThirdListObjects, true);
            }
            if (AreAllObjectsDestroyed(m_ThirdListObjects))
            {
                Instantiate(m_GameClearCanvas, transform.position, transform.rotation);

                isGameEnd = true;
                isSpawned = false;
                //BGM�Đ�
                BGMManager.Instance.m_AudioSource.clip = m_ClearBGM;
                BGMManager.Instance.m_AudioSource.Play();
            }
        }
    }

    bool AreAllObjectsDestroyed(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                return false;
            }
        }
        return true;
    }

    void SetListObjectsActive(GameObject[] objects, bool active)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(active);
            }
        }
    }
}
