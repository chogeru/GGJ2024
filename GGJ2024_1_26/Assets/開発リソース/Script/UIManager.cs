using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
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
        m_Stage1UI.SetActive(true);
    }
    public void SetStage2()
    {
        m_Stage2UI.SetActive(true);
    }
    public void SetStage3()
    {
        m_Stage3UI.SetActive(true);
    }
}
