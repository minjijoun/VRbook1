using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollision : MonoBehaviour
{
    public GameObject[] brokenEggContents;   // ���� �� ���빰 ������
    [Range(0f, 1f)] public float[] contentsProbabilities; // ���빰 Ȯ�� �迭

    private bool isBroken = false;

    private void OnCollisionEnter(Collision collision)
    {
        // ���⼭�� ������ �浹�� ����
        if (!isBroken && collision.gameObject.CompareTag("Wall"))
        {
            BreakEgg();
        }
    }

    private void BreakEgg()
    {
        isBroken = true;

        // �������� ���빰 ����
        GameObject selectedContent = GetRandomContent();

        // ���� �� ���빰 ����
        GameObject brokenEgg = Instantiate(selectedContent, transform.position, Quaternion.identity);

        // ������ �� ������Ʈ ��Ȱ��ȭ
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

        // ���� Ȯ���� ��� �������� 1�� �ȵǸ� ������ ���빰 ��ȯ
        return brokenEggContents[brokenEggContents.Length - 1];
    }

}
