using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<IUsable> inventory = new List<IUsable>();

    public void AddItem(IUsable item)
    {
        inventory.Add(item);
        Debug.Log("Item added to inventory!");
    }

    public void UseItem(int index, GameObject player)
    {
        if (index >= 0 && index < inventory.Count)
        {
            inventory[index].Use(player);
            inventory.RemoveAt(index);
            Debug.Log("Item used and removed from inventory.");
        }
        else
        {
            Debug.Log("Invalid item index!");
        }
    }

    public bool HasItems()
    {
        return inventory.Count > 0;
    }
}
