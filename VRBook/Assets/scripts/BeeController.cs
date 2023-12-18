using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeeController : MonoBehaviour
{
    public GameObject beePrefab;   // 벌 프리팹
    public int numberOfBees = 5;   // 생성할 벌의 수
    public Vector2 flyingAreaSize = new Vector2(10f, 10f); // 벌이 날아다닐 영역 크기

    public void SpawnBees()
    {
        for (int i = 0; i < numberOfBees; i++)
        {
            float x = transform.position.x + Random.Range(-flyingAreaSize.x / 2f, flyingAreaSize.x / 2f);
            float z = transform.position.z + Random.Range(-flyingAreaSize.y / 2f, flyingAreaSize.y / 2f);
            Vector3 spawnPosition = new Vector3(x, transform.position.y, z);

            GameObject bee = Instantiate(beePrefab, spawnPosition, Quaternion.identity);
            bee.transform.SetParent(transform); // 벌을 BeeController의 자식으로 설정
        }
    }
}
