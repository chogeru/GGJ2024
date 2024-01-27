using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleManager : MonoBehaviour
{
    [SerializeField, Header("ロードするシーン名")]
    private string m_LoadSceneName;

    void Update()
    {
        if (Input.anyKey||Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(m_LoadSceneName,LoadSceneMode.Single);
        }
    }
}
