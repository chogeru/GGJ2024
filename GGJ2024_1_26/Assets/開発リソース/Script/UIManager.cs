using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonobitEngine;

public class UIManager : MonobitEngine.MonoBehaviour
{
    MonobitEngine.MonobitView m_MonobitView = null;

    [SerializeField, Header("ルーム設定UI")]
    private GameObject m_RoomSettingUI;
    [SerializeField, Header("プレイヤー名入力UI")]
    private GameObject m_PlayerNameSetUI;
    [SerializeField, Header("待機画面")]
    private GameObject m_StandbyScreen;
    [SerializeField, Header("ステージ選択UI")]
    private GameObject m_StageSelectUI;

    [SerializeField, Header("ステージ1のUI")]
    private GameObject m_Stage1UI;
    [SerializeField, Header("ステージ2のUI")]
    private GameObject m_Stage2UI;
    [SerializeField, Header("ステージ3のUI")]
    private GameObject m_Stage3UI;
    private bool isStartStage1;
    private bool isStartStage2;
    private bool isStartStage3;
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
