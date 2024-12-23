using System.Collections;
using UnityEngine;

public class InvisibilityItem : MonoBehaviour, IUsable
{
    public float invisibleDuration = 5.0f;

    public void Use(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.StartCoroutine(InvisibilityRoutine(player));
        }
    }

    private IEnumerator InvisibilityRoutine(GameObject player)
    {
        // Désactiver l'apparence
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        if (playerRenderer != null)
        {
            playerRenderer.enabled = false;
        }

        // Empêcher la détection
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetIsHidden(true);
        }

        yield return new WaitForSeconds(invisibleDuration);

        // Réactiver l'apparence
        if (playerRenderer != null)
        {
            playerRenderer.enabled = true;
        }

        // Réactiver la détection
        if (playerController != null)
        {
            playerController.SetIsHidden(false);
        }
    }
}
