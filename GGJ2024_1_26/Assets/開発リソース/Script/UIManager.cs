using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonobitEngine;

public class UIManager : MonobitEngine.MonoBehaviour
{
    MonobitEngine.MonobitView m_MonobitView = null;

    [SerializeField, Header("���[���ݒ�UI")]
    private GameObject m_RoomSettingUI;
    [SerializeField, Header("�v���C���[������UI")]
    private GameObject m_PlayerNameSetUI;
    [SerializeField, Header("�ҋ@���")]
    private GameObject m_StandbyScreen;
    [SerializeField, Header("�X�e�[�W�I��UI")]
    private GameObject m_StageSelectUI;

    [SerializeField, Header("�X�e�[�W1��UI")]
    private GameObject m_Stage1UI;
    [SerializeField, Header("�X�e�[�W2��UI")]
    private GameObject m_Stage2UI;
    [SerializeField, Header("�X�e�[�W3��UI")]
    private GameObject m_Stage3UI;
    private bool isStartStage1;
    private bool isStartStage2;
    private bool isStartStage3;
    void Awake()
    {
        if (MonobitNetwork.offline == false)
        {
            // ���ׂĂ̐e�I�u�W�F�N�g�ɑ΂��� MonobitView �R���|�[�l���g����������
            if (GetComponentInParent<MonobitEngine.MonobitView>() != null)
            {
                m_MonobitView = GetComponentInParent<MonobitEngine.MonobitView>();
            }
            // �e�I�u�W�F�N�g�ɑ��݂��Ȃ��ꍇ�A���ׂĂ̎q�I�u�W�F�N�g�ɑ΂��� MonobitView �R���|�[�l���g����������
            else if (GetComponentInChildren<MonobitEngine.MonobitView>() != null)
            {
                m_MonobitView = GetComponentInChildren<MonobitEngine.MonobitView>();
            }
            // �e�q�I�u�W�F�N�g�ɑ��݂��Ȃ��ꍇ�A���g�̃I�u�W�F�N�g�ɑ΂��� MonobitView �R���|�[�l���g���������Đݒ肷��
            else
            {
                m_MonobitView = GetComponent<MonobitEngine.MonobitView>();
            }
        }
    }
    private void Start()
    {
        ClosePlayerNameSetUI();
        CloseStanddyScreenUI();
        CloseStageSelectUI();
    }

    public void CloseRoomSettingUI()
    {
        m_RoomSettingUI.SetActive(false);
        SetPlayerNameInputUI();
    }
    private void SetPlayerNameInputUI()
    {
        m_PlayerNameSetUI.SetActive(true);
    }
    public void ClosePlayerNameSetUI()
    {
        m_PlayerNameSetUI.SetActive(false);
        SetStandbyScreenUI();
    }
    public void SetStandbyScreenUI()
    {
        m_StandbyScreen.SetActive(true);
    }
    public void CloseStanddyScreenUI()
    {
        m_StandbyScreen.SetActive(false);
    }
    public void SetStageSelectUI()
    {
        m_StageSelectUI.SetActive(true);
    }
    public void CloseStageSelectUI()
    {
        m_StageSelectUI.SetActive(false);
    }

    public void SetStage1()
    {
        if (MonobitEngine.MonobitNetwork.offline == false)
        {
            m_MonobitView.RPC("Stage1", MonobitEngine.MonobitTargets.All, null);
        }
        else
        {
            Stage1();
        }
    }
    public void SetStage2()
    {
        if (MonobitEngine.MonobitNetwork.offline == false)
        {
            m_MonobitView.RPC("Stage2", MonobitEngine.MonobitTargets.All, null);
        }
        else
        {
            Stage2();
        }
    }
    public void SetStage3()
    {
        if (MonobitEngine.MonobitNetwork.offline == false)
        {
            m_MonobitView.RPC("Stage3", MonobitEngine.MonobitTargets.All, null);
        }
        else
        {
            Stage3();
        }
    }
    [MunRPC]
    public void Stage1()
    {
        m_Stage1UI.SetActive(true);
    }
    [MunRPC]
    public void Stage2()
    {
        m_Stage2UI.SetActive(true);
    }
    [MunRPC]
    public void Stage3()
    {
        m_Stage3UI.SetActive(true);
    }
}
