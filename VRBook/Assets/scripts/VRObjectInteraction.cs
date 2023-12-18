using UnityEngine;
using UnityEngine.InputSystem;

public class VRObjectInteraction : MonoBehaviour
{
    public Animator animator;           // 인스펙터에서 설정할 애니메이터
    public AudioClip interactionSound;  // 인스펙터에서 설정할 소리 클립
    private AudioSource audioSource;

    private bool isGrabbed = false;
    private bool hasInteracted = false;

    void Start()
    {
        // 오디오 소스 초기화
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Oculus Rift 컨트롤러의 그랩 버튼이 눌렸을 때의 동작
        if (isGrabbed && Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame && !hasInteracted)
        {
            PlayInteraction();
            hasInteracted = true;
        }
    }

    void PlayInteraction()
    {
        // 애니메이션 재생
        if (animator != null)
        {
            // 'InteractionTrigger' 트리거를 호출
            animator.SetTrigger("InteractionTrigger");
        }

        // 소리 재생
        if (audioSource != null && interactionSound != null)
        {
            audioSource.clip = interactionSound;
            audioSource.Play();
        }
    }

    // 콜라이더 감지가 필요한 경우 OnTrigger 함수 사용
    void OnTriggerEnter(Collider other)
    {
        // Oculus Rift 컨트롤러와 충돌했을 때
        if (IsController(other.gameObject))
        {
            isGrabbed = true;
            PlayInteraction(); // 충돌 시에도 동작 수행
        }
    }

    // 컨트롤러 여부를 확인하는 함수
    bool IsController(GameObject obj)
    {
        return obj != null && obj.name.Contains("Controller");
    }
}
