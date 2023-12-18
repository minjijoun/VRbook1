using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollision : MonoBehaviour
{
    public GameObject[] brokenEggContents;   // 깨진 알 내용물 프리팹
    [Range(0f, 1f)] public float[] contentsProbabilities; // 내용물 확률 배열

    private bool isBroken = false;

    private void OnCollisionEnter(Collision collision)
    {
        // 여기서는 벽과의 충돌을 감지
        if (!isBroken && collision.gameObject.CompareTag("Wall"))
        {
            BreakEgg();
        }
    }

    private void BreakEgg()
    {
        isBroken = true;

        // 랜덤으로 내용물 선택
        GameObject selectedContent = GetRandomContent();

        // 깨진 알 내용물 생성
        GameObject brokenEgg = Instantiate(selectedContent, transform.position, Quaternion.identity);

        // 완전한 알 오브젝트 비활성화
        gameObject.SetActive(false);
    }

    private GameObject GetRandomContent()
    {
        float randomValue = Random.value;
        float cumulativeProbability = 0f;

        for (int i = 0; i < contentsProbabilities.Length; i++)
        {
            cumulativeProbability += contentsProbabilities[i];

            if (randomValue <= cumulativeProbability)
            {
                return brokenEggContents[i];
            }
        }

        // 만약 확률이 모두 더해져도 1이 안되면 마지막 내용물 반환
        return brokenEggContents[brokenEggContents.Length - 1];
    }

}
