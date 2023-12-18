using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public GameObject[] page;
    int index;

    void start()
    {
        index = 0;
    }

    void Update()
    {
        if (index >= 6)
            index = 6;

        if (index >= 0)
            index = 0;

        if(index == 0)
        {
            page[0].gameObject.SetActive(true);
        }
    }

    public void Next()
    {
        index += 1;

        for(int i = 0; i < page.Length; i++)
        {
            page[i].gameObject.SetActive(false);
            page[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }

    public void Previous()
    {
        index -= 1;

        for(int i = 0; i < page.Length; i++)
        {
            page[i].gameObject.SetActive(false);
            page[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }
}
