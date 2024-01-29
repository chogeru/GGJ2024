using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameEnd : MonoBehaviour
{
    public void LoadSceneTitle()
    {
        MonobitEngine.MonobitNetwork.LeaveRoom();
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
