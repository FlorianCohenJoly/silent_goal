using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public GameObject posA;
    public GameObject posB;
    public float speed = 2.0f;

    private Transform playerTransform = null;
    private bool isPlayerDetected = false;
    private bool movingToB;

    public void Locomotion()
{
    if (isPlayerDetected && playerTransform != null)
    {
        // Suivre le joueur détecté
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }
    else
    {
        // Mouvement de patrouille entre posA et posB
        transform.position = Vector3.MoveTowards(transform.position, (movingToB ? posB : posA).transform.position, speed * Time.deltaTime);

        // Vérifie si l'ennemi est proche de posA ou posB
        if (Vector3.Distance(transform.position, posB.transform.position) < 0.1f)
        {
            // Oriente l'ennemi pour qu'il regarde vers posA sur l'axe Z et inverse la direction
            transform.rotation = Quaternion.Euler(0, 0, 180);  // Regarde vers posA
            movingToB = false;
        }
        else if (Vector3.Distance(transform.position, posA.transform.position) < 0.1f)
        {
            // Oriente l'ennemi pour qu'il regarde vers posB sur l'axe Z et inverse la direction
            transform.rotation = Quaternion.Euler(0, 0, 0);  // Regarde vers posB
            movingToB = true;
        }
    }
}


    void Update()
    {
        Locomotion();
    }

    public void DetectPlayer(Transform player)
    {
        isPlayerDetected = true;
        playerTransform = player;
    }

    public void LosePlayer()
    {
        isPlayerDetected = false;
        playerTransform = null;
    }
}
