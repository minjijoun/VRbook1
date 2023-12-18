using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    public float speed = 5f;
    public float amplitude = 1f;
    public float frequency = 1f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // ���� ������ �̵��ϸ鼭 ���Ʒ��� ��鸲
        float newY = initialPosition.y + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // ���� �̵� �ӵ��� ���� �̵�
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
