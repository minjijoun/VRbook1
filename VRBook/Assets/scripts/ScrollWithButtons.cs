using UnityEngine;
using UnityEngine.UI;



public class ScrollWithButtons : MonoBehaviour
{
    public Scrollbar scrollbar;
    public Button leftButton;
    public Button rightButton;
    public float scrollSpeed = 0.1f;
    public float smoothTime = 0.3f;
    private float targetScrollValue;
    private bool isScrolling = false;

    void Start()
    {
        leftButton.onClick.AddListener(OnLeftButtonDown);
        rightButton.onClick.AddListener(OnRightButtonDown);
        targetScrollValue = scrollbar.value;
    }

    void Update()
    {
        if (isScrolling)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetScrollValue, smoothTime * Time.deltaTime);
        }
    }

    void OnLeftButtonDown()
    {
        isScrolling = true;
        targetScrollValue = Mathf.Clamp(targetScrollValue - scrollSpeed, 0f, 1f);
    }

    void OnRightButtonDown()
    {
        isScrolling = true;
        targetScrollValue = Mathf.Clamp(targetScrollValue + scrollSpeed, 0f, 1f);
    }

    void OnButtonUp()
    {
        isScrolling = false;
    }

    void LateUpdate()
    {
        // 버튼에서 떼었는지 확인
        if (!leftButton.interactable && !rightButton.interactable)
        {
            OnButtonUp();
        }
    }
}
  
