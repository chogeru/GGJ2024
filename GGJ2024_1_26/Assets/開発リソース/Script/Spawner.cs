using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Header("�X�|�[������I�u�W�F�N�g�̃v���n�u")]
    private List<GameObject> m_SpawnObjPrefab;
    [SerializeField, Header("�X�|�[���|�C���g")]
    private Transform[] m_SpawnPoints;

    private List<GameObject> m_CurrentSpawnedObjects = new List<GameObject>();

    // �ŏ�����эő�̃X�|�[���Ԋu
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;

    // ���݂̌o�ߎ���
    private float elapsedTime = 0f;
    // �O��̃X�|�[������̌o�ߎ���
    private float lastSpawnTime = 0f;

    void Update()
    {
        // �o�ߎ��Ԃ��X�V
        elapsedTime += Time.deltaTime;

        // �X�|�[���Ԋu�𒴂�����I�u�W�F�N�g���X�|�[��
        if (elapsedTime - lastSpawnTime >= Random.Range(minSpawnInterval, maxSpawnInterval))
        {
            // �����_���ȃX�|�[���|�C���g��I��
            Transform spawnPoint = m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)];

            // �����_���ȃI�u�W�F�N�g��I��
            GameObject objectToSpawn = m_SpawnObjPrefab[Random.Range(0, m_SpawnObjPrefab.Count)];

            // �O�ɃX�|�[�����ꂽ�I�u�W�F�N�g������΍폜
            if (m_CurrentSpawnedObjects.Count > 0)
            {
                foreach (GameObject spawnedObject in m_CurrentSpawnedObjects)
                {
                    Destroy(spawnedObject);
                }
                m_CurrentSpawnedObjects.Clear();
            }

            // �I�u�W�F�N�g���X�|�[��
            GameObject spawnedObjectInstance = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity,transform);
            m_CurrentSpawnedObjects.Add(spawnedObjectInstance);

            // �O��̃X�|�[�����Ԃ��X�V
            lastSpawnTime = elapsedTime;
        }
    }
}
