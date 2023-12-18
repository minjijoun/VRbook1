using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float minSpeed = 1f;            // 벌의 이동 속도
    public float maxSpeed = 2f;            // 벌의 이동 속도
    public float amplitude = 1f;        // 벌의 위아래 흔들림 강도
    public float frequency = 1f;        // 벌의 위아래 흔들림 주기
    public float roamingRadius = 5f;    // 벌이 돌아다닐 반경

    private Vector3 initialPosition;    // 초기 위치
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
        // 벌은 앞으로 이동하면서 위아래로 흔들림
        float newY = initialPosition.y + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // 벌의 이동 범위 제한
        Vector3 randomDirection = Random.insideUnitSphere * roamingRadius;
        randomDirection.y = 0f; // y 방향은 사용하지 않음
        Vector3 newPosition = initialPosition + randomDirection;

        timer += Time.deltaTime;

        if(timer / 0.5f > 1f)
        {
            truePosition = newPosition;
            speed = Random.Range(minSpeed, maxSpeed);
            timer = 0f;
        }

        // 벌이 바라보는 방향 설정
        transform.LookAt(truePosition);
        // 벌의 이동 속도에 따라 이동
        transform.position = Vector3.MoveTowards(transform.position, truePosition, speed * Time.deltaTime);
    }
}
