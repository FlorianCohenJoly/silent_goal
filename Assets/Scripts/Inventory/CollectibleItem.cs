using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public GameObject itemPrefab; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryManager inventory = collision.GetComponent<PlayerController>().inventoryManager;
            IUsable usableItem = itemPrefab.GetComponent<IUsable>();

            if (inventory != null && usableItem != null)
            {
                inventory.AddItem(usableItem);
                Destroy(gameObject);
            }
        }
    }
}
