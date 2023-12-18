using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_SceneMove : MonoBehaviour
{
    public void ToSampleScene()
    {
        SceneManager.Instance.LoadScene("SampleScene");
    }

    public void ToTheLIttlePrince()
    {
        SceneManager.Instance.LoadScene("TheLIttlePrince");
    }

    public void ToShinSaimdang()
    {
        SceneManager.Instance.LoadScene("ShinSaimdang");
    }

    public void ToPoetry()
    {
        SceneManager.Instance.LoadScene("Poetry");
    }

    public void ToABCD()
    {
        SceneManager.Instance.LoadScene("ABCD");
    }
}
