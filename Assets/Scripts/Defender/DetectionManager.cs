using UnityEngine;

public class DetectionManager : MonoBehaviour
{
    public Defender defenderScript; // Référence au script de l'ennemi
    public float detectionAngle = 45f; // Angle du cône de vision
    public float detectionRange = 5f;  // Portée du cône de vision

    void Update()
    {
        DetectPlayerInCone();
    }

    void DetectPlayerInCone()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        // Vérifie si le joueur est caché
        PlayerController playerScript = player.GetComponent<PlayerController>();
        if (playerScript != null && playerScript.GetIsHidden())
        {
            defenderScript.LosePlayer(); // L'ennemi perd la trace du joueur
            return;
        }

        // Calcul des distances et angles pour la détection
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
    }
}
