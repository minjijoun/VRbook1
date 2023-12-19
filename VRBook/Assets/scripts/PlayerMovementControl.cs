using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovementControl : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider continuousMoveProvider;

    void Start()
    {
        // continuousMoveProvider�� �Ҵ��ؾ� ��ũ��Ʈ�� �����մϴ�.
        if (continuousMoveProvider == null)
        {
            Debug.LogError("Continuous Move Provider is not assigned!");
            return;
        }

        // �÷��̾� �̵� ��Ȱ��ȭ
        continuousMoveProvider.enabled = false;
    }

    void Update()
    {
        // ����: � ���ǿ��� �÷��̾� �̵� Ȱ��ȭ
        // Input.GetKeyDown ��� Keyboard.current�� ���
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            EnablePlayerMovement();
        }
    }

    void EnablePlayerMovement()
    {
        // �÷��̾� �̵� Ȱ��ȭ
        continuousMoveProvider.enabled = true;
    }
}
