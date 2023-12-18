using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectDropper : MonoBehaviour
{
    public GameObject objectToDrop; // 떨어뜨릴 오브젝트 프리팹
    public int numberOfObjects = 5;  // 떨어뜨릴 오브젝트 개수
    public Vector2 spawnAreaSize = new Vector2(10f, 10f); // 소환 영역 크기

    public void DropObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // 소환 영역 내에서 랜덤한 위치 계산
            float x = transform.position.x + Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
            float z = transform.position.z + Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

            Vector3 spawnPosition = new Vector3(x, transform.position.y, z);

            Instantiate(objectToDrop, spawnPosition, Quaternion.identity);
        }
    }

}
