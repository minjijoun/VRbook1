using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectDropper : MonoBehaviour
{
    public GameObject objectToDrop; // ����߸� ������Ʈ ������
    public int numberOfObjects = 5;  // ����߸� ������Ʈ ����
    public Vector2 spawnAreaSize = new Vector2(10f, 10f); // ��ȯ ���� ũ��

    public void DropObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // ��ȯ ���� ������ ������ ��ġ ���
            float x = transform.position.x + Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
            float z = transform.position.z + Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

            Vector3 spawnPosition = new Vector3(x, transform.position.y, z);

            Instantiate(objectToDrop, spawnPosition, Quaternion.identity);
        }
    }

}
