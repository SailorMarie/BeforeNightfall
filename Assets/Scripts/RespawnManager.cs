using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider player)
    {
        // Check if the object entering the trigger is the player
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Reset position to the respawn point
            player.transform.position = respawnPoint.position;

            // Optional: If using Rigidbody, reset velocity to stop falling movement
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null) rb.linearVelocity = Vector3.zero;
        }
    }
}
