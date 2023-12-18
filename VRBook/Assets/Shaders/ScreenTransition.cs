using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTransition : MonoBehaviour
{
    public float CircleSize = 0f;

    private readonly int _circleSizeId = Shader.PropertyToID("_Circle_Size");

    [SerializeField]
    private Image image;

    [SerializeField]
    private AnimationCurve[] curves = new AnimationCurve[2];

    private void Start()
    {
        // 서클 크기 초기화
        image.materialForRendering.SetFloat(_circleSizeId, CircleSize);
    }

    private void OnApplicationQuit()
    {
        image.materialForRendering.SetFloat(_circleSizeId, CircleSize);
    }

    public IEnumerator FadeInOut(float _time, Action _callback = null)
    {
        yield return StartCoroutine(CircleInCo(_time));
        yield return StartCoroutine(CircleOutCo(_time));
        _callback?.Invoke();
    }

    public IEnumerator CircleInCo(float _time, Action _callback = null)
    {
        CircleSize = 1f;

        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.unscaledDeltaTime;
            percent = current / _time;

            CircleSize = Mathf.Lerp(1f, 0f, curves[0].Evaluate(percent));
            image.materialForRendering.SetFloat(_circleSizeId, CircleSize);

            yield return null;
        }
        _callback?.Invoke();
    }

    public IEnumerator CircleOutCo(float _time, Action _callback = null)
    {
        CircleSize = 0f;

        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.unscaledDeltaTime;
            percent = current / _time;

            CircleSize = Mathf.Lerp(0f, 1f, curves[1].Evaluate(percent));
            image.materialForRendering.SetFloat(_circleSizeId, CircleSize);

            yield return null;
        }
        _callback?.Invoke();
    }
}
