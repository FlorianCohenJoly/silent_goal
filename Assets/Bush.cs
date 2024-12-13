using UnityEngine;

public class Bush : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Le joueur est entré dans le buisson.");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Le joueur est entré dans le buisson.");
            collision.GetComponent<PlayerController>().SetIsHidden(true); // Assurez-vous que le joueur a une méthode SetIsHidden.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Le joueur a quitté le buisson.");
            collision.GetComponent<PlayerController>().SetIsHidden(false); // Assurez-vous que le joueur a une méthode SetIsHidden.
        }
    }
}
