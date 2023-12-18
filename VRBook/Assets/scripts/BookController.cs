using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    public Animator bookAnimator;
    public GameObject coverUI;
    public GameObject[] pageUIs; // 여러 페이지 UI를 배열로 관리
    private int currentPageIndex = 0;

    private void Start()
    {
        // 초기화: Cover UI 활성화, 첫 페이지 UI만 활성화
        ToggleUI(true, false);
    }

    // 책 열기 버튼에 연결된 함수
    public void OpenBook()
    {
        bookAnimator.SetTrigger("OpenBook");
        ToggleUI(false, true);
    }

    // 다음 페이지로 가기 버튼에 연결된 함수
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
            // 마지막 페이지에서 다음 페이지 버튼을 눌렀을 때
            // CloseBook 애니메이션 실행
            CloseBook();
            // 추가로 OnCloseBookAnimationEnd 함수를 호출하여 Cover UI를 활성화하고 현재 페이지 UI를 비활성화
            ToggleUI(true, false);
            currentPageIndex = 0; // 처음 페이지로 돌아가기
        }
    }

    // 이전 페이지로 가기 버튼에 연결된 함수
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
            // 페이지1에서 뒤로가기 버튼을 눌렀을 때
            // CloseBook 애니메이션 실행
            CloseBook();
            // 추가로 OnCloseBookAnimationEnd 함수를 호출하여 Cover UI를 활성화하고 현재 페이지 UI를 비활성화
            ToggleUI(true, false);
        }
    }

    // 책 닫기 버튼에 연결된 함수
    public void CloseBook()
    {
        // 마지막 페이지에서 CloseBook 호출 시 초기 상태로 리셋
        bookAnimator.SetTrigger("CloseBook");
    }

    // 애니메이션 이벤트로부터 호출되는 함수
    public void OnCloseBookAnimationEnd()
    {
        // 책이 닫히는 애니메이션이 종료된 후
        // 현재 페이지 UI를 비활성화하고 Cover UI를 활성화
        ToggleUI(true, false);
    }

    // UI 활성화/비활성화 함수
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
