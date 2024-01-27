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

    [SerializeField,Header("�ŏ��X�|�[���Ԋu")]
    private float m_MinSpawnInterval = 3f;
    [SerializeField, Header("�ő�X�|�[���Ԋu")]
    private float m_MaxSpawnInterval = 10f;

    // ���݂̌o�ߎ���
    private float m_ElapsedTime = 0f;
    // �O��̃X�|�[������̌o�ߎ���
    private float m_LastSpawnTime = 0f;

    void Update()
    {
        // �o�ߎ��Ԃ��X�V
        m_ElapsedTime += Time.deltaTime;

        // �X�|�[���Ԋu�𒴂�����I�u�W�F�N�g���X�|�[��
        if (m_ElapsedTime - m_LastSpawnTime >= Random.Range(m_MinSpawnInterval, m_MaxSpawnInterval))
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
            m_LastSpawnTime = m_ElapsedTime;
        }
    }
}
