using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField, Header("���[���ݒ�UI")]
    private GameObject m_RoomSettingUI;
    [SerializeField,Header("�v���C���[������UI")]
    private GameObject m_PlayerNameSetUI;
    [SerializeField, Header("�ҋ@���")]
    private GameObject m_StandbyScreen;

    private void Start()
    {
        ClosePlayerNameSetUI();
        CloseStanddyScreenUI();
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
}
