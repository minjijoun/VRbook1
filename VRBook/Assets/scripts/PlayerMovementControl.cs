using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovementControl : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider continuousMoveProvider;

    void Start()
    {
        // continuousMoveProvider를 할당해야 스크립트가 동작합니다.
        if (continuousMoveProvider == null)
        {
            Debug.LogError("Continuous Move Provider is not assigned!");
            return;
        }

        // 플레이어 이동 비활성화
        continuousMoveProvider.enabled = false;
    }

    void Update()
    {
        // 예시: 어떤 조건에서 플레이어 이동 활성화
        // Input.GetKeyDown 대신 Keyboard.current를 사용
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            EnablePlayerMovement();
        }
    }

    void EnablePlayerMovement()
    {
        // 플레이어 이동 활성화
        continuousMoveProvider.enabled = true;
    }
}
