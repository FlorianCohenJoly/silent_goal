using UnityEngine;

public class DetectionManager : MonoBehaviour
{
    public Defender defenderScript;
    public float detectionAngle = 45f; 
    public float detectionRange = 5f;  
    private bool isPlayerHidden = false;

    void Update()
    {
        DetectPlayerInCone();
    }

    void DetectPlayerInCone()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        // Vérifie si le joueur est dans un bush
        isPlayerHidden = IsPlayerInBush(player);

        if (isPlayerHidden)
        {
            defenderScript.LosePlayer();
            return;
        }

        Vector2 directionToPlayer = player.transform.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer <= detectionRange)
        {
            float angleToPlayer = Vector2.Angle(transform.right, directionToPlayer);

            if (angleToPlayer <= detectionAngle / 2)
            {
                Debug.Log("Player detected!");
                defenderScript.DetectPlayer(player.transform);
            }
            else
            {
                defenderScript.LosePlayer();
            }
        }
        else
        {
            defenderScript.LosePlayer();
        }
    }

    bool IsPlayerInBush(GameObject player)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, 0.1f);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("bush"))
            {
                return true;
            }
        }
        return false;
    }

    // Affiche le cône de vision dans l'éditeur Unity
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 startPosition = transform.position;
        Vector3 directionRight = Quaternion.Euler(0, 0, detectionAngle / 2) * transform.right;
        Vector3 directionLeft = Quaternion.Euler(0, 0, -detectionAngle / 2) * transform.right;

        Gizmos.DrawLine(startPosition, startPosition + directionRight * detectionRange);
        Gizmos.DrawLine(startPosition, startPosition + directionLeft * detectionRange);
        Gizmos.DrawWireSphere(startPosition, detectionRange);

        int segments = 20;
        for (int i = 0; i < segments; i++)
        {
            float angle = -detectionAngle / 2 + (detectionAngle / segments) * i;
            float nextAngle = -detectionAngle / 2 + (detectionAngle / segments) * (i + 1);
            Vector3 currentDir = Quaternion.Euler(0, 0, angle) * transform.right;
            Vector3 nextDir = Quaternion.Euler(0, 0, nextAngle) * transform.right;

            Gizmos.DrawLine(startPosition + currentDir * detectionRange, startPosition + nextDir * detectionRange);
        }
    }
}
