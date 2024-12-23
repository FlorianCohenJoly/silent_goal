using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public GameObject posA;
    public GameObject posB;
    public float speed = 2.0f;
    public float chaseRange = 5.0f; // Portée de poursuite

    private Transform playerTransform = null;
    private bool isPlayerDetected = false;
    private bool movingToB;

    private int yellowCard = 0; // Le joueur commence sans carton
    public PlayerComportment playerComportment;



    void Update()
    {
        Locomotion();
    }

    public void Locomotion()
    {
        if (isPlayerDetected && playerTransform != null)
        {
            // Suivre le joueur détecté
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);



            if (distanceToPlayer <= chaseRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

                // Oriente l'ennemi vers le joueur
                Vector3 directionToPlayer = playerTransform.position - transform.position;
                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                LosePlayer();
            }
        }
        else
        {
            if (posA == null || posB == null) return;
            // Mouvement de patrouille entre posA et posB
            transform.position = Vector3.MoveTowards(transform.position, (movingToB ? posB : posA).transform.position, speed * Time.deltaTime);

            // Vérifie si l'ennemi est proche de posA ou posB
            if (Vector3.Distance(transform.position, posB.transform.position) < 0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180); // Regarde vers posA
                movingToB = false;
            }
            else if (Vector3.Distance(transform.position, posA.transform.position) < 0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0); // Regarde vers posB
                movingToB = true;
            }
        }
    }

    public void DetectPlayer(Transform player)
    {
        isPlayerDetected = true;
        playerTransform = player;
        //Debug.Log("player detecter, poursuite en cours");
    }

    public void LosePlayer()
    {
        isPlayerDetected = false;
        playerTransform = null;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isPlayerDetected) // L'ennemi touche le joueur uniquement s'il le poursuit
            {
                yellowCard++;
                Debug.Log($"Player received yellow card {yellowCard}!");

                if (yellowCard == 1)
                {
                    LosePlayer(); // Le joueur reçoit un carton jaune, l'ennemi arrête de le poursuivre
                    playerComportment.Respawn();
                }
                else if (yellowCard >= 2)
                {
                    Debug.Log("Player received a red card and game over!");

                }
            }
        }
    }


}
