using UnityEngine;

public class LookAtPlayerUI : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        // Ensure the playerTransform is assigned
        if (playerTransform == null)
        {
            Debug.LogError("Player transform not assigned!");
            return;
        }

        // Make the UI face the player on the XZ plane (Y rotation only)
        Vector3 lookAtPosition = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        transform.LookAt(lookAtPosition);
    }
}
