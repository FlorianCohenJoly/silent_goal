using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_Player;

    [SerializeField]
    private Vector3 m_Offset;

    [SerializeField]
    private float m_Smoothing = 5f; // Assurez-vous que cette valeur est suffisante pour une transition fluide.

    // Utiliser FixedUpdate pour des calculs de position
    void FixedUpdate()
    {
        Vector3 target = m_Player.position + m_Offset;

        // Appliquer le lissage directement sans distance pour un suivi plus constant
        target = Vector3.Lerp(transform.position, target, m_Smoothing * Time.deltaTime);

        // Forcer la limite sur l'axe Y
        target.y = Mathf.Max(2, target.y);

        // Mettre à jour la position de la caméra
        transform.position = target;
    }
}
