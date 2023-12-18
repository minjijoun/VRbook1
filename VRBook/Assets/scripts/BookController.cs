using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    public Animator bookAnimator;
    public GameObject coverUI;
    public GameObject[] pageUIs; // ���� ������ UI�� �迭�� ����
    private int currentPageIndex = 0;

    private void Start()
    {
        // �ʱ�ȭ: Cover UI Ȱ��ȭ, ù ������ UI�� Ȱ��ȭ
        ToggleUI(true, false);
    }

    // å ���� ��ư�� ����� �Լ�
    public void OpenBook()
    {
        bookAnimator.SetTrigger("OpenBook");
        ToggleUI(false, true);
    }

    // ���� �������� ���� ��ư�� ����� �Լ�
    public void NextPage()
    {
        if (currentPageIndex < pageUIs.Length - 1)
        {
            currentPageIndex++;
            bookAnimator.SetTrigger("NextPage");
            ToggleUI(false, true);
        }
        else
        {
            // ������ ���������� ���� ������ ��ư�� ������ ��
            // CloseBook �ִϸ��̼� ����
            CloseBook();
            // �߰��� OnCloseBookAnimationEnd �Լ��� ȣ���Ͽ� Cover UI�� Ȱ��ȭ�ϰ� ���� ������ UI�� ��Ȱ��ȭ
            ToggleUI(true, false);
            currentPageIndex = 0; // ó�� �������� ���ư���
        }
    }

    // ���� �������� ���� ��ư�� ����� �Լ�
    public void PrevPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            bookAnimator.SetTrigger("PrevPage");
            ToggleUI(false, true);
        }
        else
        {
            // ������1���� �ڷΰ��� ��ư�� ������ ��
            // CloseBook �ִϸ��̼� ����
            CloseBook();
            // �߰��� OnCloseBookAnimationEnd �Լ��� ȣ���Ͽ� Cover UI�� Ȱ��ȭ�ϰ� ���� ������ UI�� ��Ȱ��ȭ
            ToggleUI(true, false);
        }
    }

    // å �ݱ� ��ư�� ����� �Լ�
    public void CloseBook()
    {
        // ������ ���������� CloseBook ȣ�� �� �ʱ� ���·� ����
        bookAnimator.SetTrigger("CloseBook");
    }

    // �ִϸ��̼� �̺�Ʈ�κ��� ȣ��Ǵ� �Լ�
    public void OnCloseBookAnimationEnd()
    {
        // å�� ������ �ִϸ��̼��� ����� ��
        // ���� ������ UI�� ��Ȱ��ȭ�ϰ� Cover UI�� Ȱ��ȭ
        ToggleUI(true, false);
    }

    // UI Ȱ��ȭ/��Ȱ��ȭ �Լ�
    private void ToggleUI(bool coverUIActive, bool pageUIActive)
    {
        if (coverUI != null) coverUI.SetActive(coverUIActive);

        for (int i = 0; i < pageUIs.Length; i++)
        {
            if (pageUIs[i] != null)
            {
                pageUIs[i].SetActive(pageUIActive && i == currentPageIndex);
            }
        }
    }
}
