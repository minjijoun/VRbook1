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
        // 벌은 앞으로 이동하면서 위아래로 흔들림
        float newY = initialPosition.y + amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // 벌의 이동 속도에 따라 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
