using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameEnd : MonoBehaviour
{
    public void LoadSceneTitle()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
