using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Header("スポーンするオブジェクトのプレハブ")]
    private List<GameObject> m_SpawnObjPrefab;
    [SerializeField, Header("スポーンポイント")]
    private Transform[] m_SpawnPoints;

    private List<GameObject> m_CurrentSpawnedObjects = new List<GameObject>();

    [SerializeField,Header("最小スポーン間隔")]
    private float m_MinSpawnInterval = 3f;
    [SerializeField, Header("最大スポーン間隔")]
    private float m_MaxSpawnInterval = 10f;

    // 現在の経過時間
    private float m_ElapsedTime = 0f;
    // 前回のスポーンからの経過時間
    private float m_LastSpawnTime = 0f;

    void Update()
    {
        // 経過時間を更新
        m_ElapsedTime += Time.deltaTime;

        // スポーン間隔を超えたらオブジェクトをスポーン
        if (m_ElapsedTime - m_LastSpawnTime >= Random.Range(m_MinSpawnInterval, m_MaxSpawnInterval))
        {
            // ランダムなスポーンポイントを選択
            Transform spawnPoint = m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)];

            // ランダムなオブジェクトを選択
            GameObject objectToSpawn = m_SpawnObjPrefab[Random.Range(0, m_SpawnObjPrefab.Count)];

            // 前にスポーンされたオブジェクトがあれば削除
            if (m_CurrentSpawnedObjects.Count > 0)
            {
                foreach (GameObject spawnedObject in m_CurrentSpawnedObjects)
                {
                    Destroy(spawnedObject);
                }
                m_CurrentSpawnedObjects.Clear();
            }

            // オブジェクトをスポーン
            GameObject spawnedObjectInstance = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity,transform);
            m_CurrentSpawnedObjects.Add(spawnedObjectInstance);

            // 前回のスポーン時間を更新
            m_LastSpawnTime = m_ElapsedTime;
        }
    }
}
