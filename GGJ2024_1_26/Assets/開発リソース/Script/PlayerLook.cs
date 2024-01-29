using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player"; 

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
        else
        {
            Debug.LogWarning("プレイヤーが見つからない！");
        }
    }
}
