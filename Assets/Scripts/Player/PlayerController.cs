using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement m_Movement;

    public InventoryManager inventoryManager;

    private bool isHidden = false;

    public void SetIsHidden(bool hidden)
    {
        isHidden = hidden;
    }

    public bool GetIsHidden()
    {
        return isHidden;
    }

    void Update()
    {
        float dirX = 0;
        float dirY = 0;

        if (Keyboard.current.aKey.isPressed)
        {
            dirX = -1;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            dirX = 1;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            dirY = 1;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            dirY = -1;
        }

        m_Movement.Move(dirX, dirY);

        // Utilisation d'un objet dans l'inventaire avec la touche E
        if (Keyboard.current.eKey.wasPressedThisFrame && inventoryManager.HasItems())
        {
            inventoryManager.UseItem(0, gameObject); // Utilise le premier objet
        }
    }
}
