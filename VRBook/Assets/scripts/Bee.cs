using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float minSpeed = 1f;            // ���� �̵� �ӵ�
    public float maxSpeed = 2f;            // ���� �̵� �ӵ�
    public float amplitude = 1f;        // ���� ���Ʒ� ��鸲 ����
    public float frequency = 1f;        // ���� ���Ʒ� ��鸲 �ֱ�
    public float roamingRadius = 5f;    // ���� ���ƴٴ� �ݰ�

    private Vector3 initialPosition;    // �ʱ� ��ġ
    private Vector3 truePosition;
    
    float speed;
    float timer = 0;

    void Start()
    {
        initialPosition = transform.position;
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        // ���� ������ �̵��ϸ鼭 ���Ʒ��� ��鸲
        float newY = initialPosition.y + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // ���� �̵� ���� ����
        Vector3 randomDirection = Random.insideUnitSphere * roamingRadius;
        randomDirection.y = 0f; // y ������ ������� ����
        Vector3 newPosition = initialPosition + randomDirection;

        timer += Time.deltaTime;

        if(timer / 0.5f > 1f)
        {
            truePosition = newPosition;
            speed = Random.Range(minSpeed, maxSpeed);
            timer = 0f;
        }

        // ���� �ٶ󺸴� ���� ����
        transform.LookAt(truePosition);
        // ���� �̵� �ӵ��� ���� �̵�
        transform.position = Vector3.MoveTowards(transform.position, truePosition, speed * Time.deltaTime);
    }
}
