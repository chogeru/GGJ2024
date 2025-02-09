using MonobitEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnlineSystem : MonobitEngine.MonoBehaviour
{
    [SerializeField, Header("ルーム作成用テキスト")]
    private Text m_CreateRoomNameText;
    [SerializeField, Header("ルーム作成用パスワード")]
    private Text m_CreatePassWordText;
    [SerializeField, Header("ジョインルーム名テキスト")]
    private Text m_JoinRoomNameText;
    [SerializeField, Header("ジョインルームパスワード")]
    private Text m_JoinRoomPasWordText;

    public List<Text> playerNameListTexts;

    [SerializeField, Header("名前入力UI")]
    public List<Text> playerListTexts;

    public InputField playerNameInput;

    public void Awake()
    {
        //最初に自動でロビー作成
        MonobitEngine.MonobitNetwork.autoJoinLobby = true;
        MonobitNetwork.ConnectServer("OnlineServer_v1.0");
    }

    private void Update()
    {
        DebugLogs();
    }
    private void DebugLogs()
    {
        Debug.Log(MonobitEngine.MonobitNetwork.playerList);
        Debug.Log(MonobitEngine.MonobitNetwork.playerName);
        Debug.Log(MonobitNetwork.player);
        if (MonobitEngine.MonobitNetwork.isConnect)
        {
            Debug.Log("サーバーコネクト");
        }
        else
        {
            Debug.Log("サーバー未接続");
        }
        foreach (MonobitPlayer player in MonobitNetwork.playerList)
        {
            Debug.Log(player.name);
            GetRoomPlayerName();
        }
    }


    public void CreateRoom()
    {
        string roomName = m_CreateRoomNameText.text;
        string roomPassword = m_CreatePassWordText.text;
        MonobitEngine.RoomSettings roomsetting = new MonobitEngine.RoomSettings();
        roomsetting.maxPlayers = 2;
        roomsetting.isVisible = true;
        roomsetting.isOpen = true;
        MonobitEngine.LobbyInfo lobby = new MonobitEngine.LobbyInfo();
        lobby.Kind = LobbyKind.Default;

        MonobitEngine.MonobitNetwork.CreateRoom(roomName + roomPassword, roomsetting, lobby);
        Debug.Log(roomName + roomPassword);
        Debug.Log(roomsetting.isOpen);

    }

    public void JoinRoom()
    {
        string JoinRoomName = m_JoinRoomNameText.text;
        string JoinRoomPasword = m_JoinRoomPasWordText.text;

        MonobitEngine.MonobitNetwork.JoinRoom(JoinRoomName + JoinRoomPasword);
        Debug.Log(JoinRoomName + JoinRoomPasword);
        GetRoomPlayerName();
    }
    public void OfflineMode()
    {
        if (!MonobitNetwork.inRoom)
        {
            MonobitNetwork.LeaveRoom();
            MonobitEngine.MonobitNetwork.DisconnectServer();
        }
    }
    private void GetRoomPlayerName()
    {

        int index = 0;
        foreach (MonobitPlayer player in MonobitNetwork.playerList)
        {
            Debug.Log("Player Name: " + player.name);
            Debug.Log("Player Name: " + MonobitNetwork.playerList);

            playerNameListTexts[index].text = player.name;
            index++;
        }
    }
    public void OnDisconnectedFromServer()
    {
        MonobitEngine.MonobitNetwork.offline = true;
    }
    public void SetPlayerName()
    {
        // プレイヤーがゲームに参加したら、名前を設定して保存する
        string playerName = playerNameInput.text;
        MonobitNetwork.playerName = playerName;
        if (MonobitNetwork.inRoom)
        {
            // 他のプレイヤーにプレイヤー名を伝える
            monobitView.RPC("RpcSetPlayerName", MonobitTargets.Others, playerName);
        }
        Debug.Log(MonobitNetwork.playerName);
    }
    [MunRPC]
    private void RpcSetPlayerName(string playerName)
    {
        Debug.Log("Received player name: " + playerName);

        playerNameListTexts[MonobitNetwork.playerList.Length - 1].text = playerName;
    }
}
