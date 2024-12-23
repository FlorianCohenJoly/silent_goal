using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TeleportationOnNextGround : MonoBehaviour
{
    private bool isTeleporting = false;

    public GameObject doorExit;


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

        player.transform.position = doorExit.transform.position;

        // Petit délai pour éviter une nouvelle téléportation instantanée
        yield return new WaitForSeconds(0.5f);

        isTeleporting = false;
    }



}
