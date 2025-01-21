using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationOnNextGround : MonoBehaviour
{
    private bool isTeleporting = false;

    public GameObject doorExit;
    public GameObject particleEffect; // GameObject des particules

    public AudioSource goalSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTeleporting)
        {
            StartCoroutine(TeleportPlayer(collision));
        }
    }

    private IEnumerator TeleportPlayer(Collider2D player)
    {
        isTeleporting = true;

        // Activer les particules
        particleEffect.SetActive(true);

        // Jouer le son
        goalSound.Play();

        // Délai pour jouer les particules
        yield return new WaitForSeconds(2f); // Ajuster la durée selon vos besoins

        // Désactiver les particules après le délai
        particleEffect.SetActive(false);

        // Téléportation
        player.transform.position = doorExit.transform.position;

        // Petit délai pour éviter une nouvelle téléportation instantanée
        yield return new WaitForSeconds(2f);

        isTeleporting = false;
    }
}
