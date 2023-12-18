using UnityEngine;
using UnityEngine.InputSystem;

public class VRObjectInteraction : MonoBehaviour
{
    public Animator animator;           // �ν����Ϳ��� ������ �ִϸ�����
    public AudioClip interactionSound;  // �ν����Ϳ��� ������ �Ҹ� Ŭ��
    private AudioSource audioSource;

    private bool isGrabbed = false;
    private bool hasInteracted = false;

    void Start()
    {
        // ����� �ҽ� �ʱ�ȭ
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Oculus Rift ��Ʈ�ѷ��� �׷� ��ư�� ������ ���� ����
        if (isGrabbed && Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame && !hasInteracted)
        {
            PlayInteraction();
            hasInteracted = true;
        }
    }

    void PlayInteraction()
    {
        // �ִϸ��̼� ���
        if (animator != null)
        {
            // 'InteractionTrigger' Ʈ���Ÿ� ȣ��
            animator.SetTrigger("InteractionTrigger");
        }

        // �Ҹ� ���
        if (audioSource != null && interactionSound != null)
        {
            audioSource.clip = interactionSound;
            audioSource.Play();
        }
    }

    // �ݶ��̴� ������ �ʿ��� ��� OnTrigger �Լ� ���
    void OnTriggerEnter(Collider other)
    {
        // Oculus Rift ��Ʈ�ѷ��� �浹���� ��
        if (IsController(other.gameObject))
        {
            isGrabbed = true;
            PlayInteraction(); // �浹 �ÿ��� ���� ����
        }
    }

    // ��Ʈ�ѷ� ���θ� Ȯ���ϴ� �Լ�
    bool IsController(GameObject obj)
    {
        return obj != null && obj.name.Contains("Controller");
    }
}
