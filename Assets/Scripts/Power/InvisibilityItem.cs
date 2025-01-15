using System.Collections;
using UnityEngine;

public class InvisibilityItem : MonoBehaviour, IUsable
{
    public float hologramDuration = 3f;

    // Couleur ou matériau pour l'effet hologramme
    public Color hologramColor = new Color(0, 1, 1, 0.5f); // Cyan transparent
    private Color originalColor;

    public void Use(GameObject player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.StartCoroutine(HologramRoutine(player));
        }
    }

    private IEnumerator HologramRoutine(GameObject player)
    {
        // Obtenir le SpriteRenderer du joueur
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        if (playerRenderer != null)
        {
            // Sauvegarder la couleur d'origine
            originalColor = playerRenderer.color;

            // Appliquer la couleur hologramme
            playerRenderer.color = hologramColor;
        }

        // Empêcher la détection
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetIsHidden(true);
        }

        // Attendre la durée spécifiée
        yield return new WaitForSeconds(hologramDuration);

        // Restaurer la couleur d'origine
        if (playerRenderer != null)
        {
            playerRenderer.color = originalColor;
        }

        // Réactiver la détection
        if (playerController != null)
        {
            playerController.SetIsHidden(false);
        }
    }
}
