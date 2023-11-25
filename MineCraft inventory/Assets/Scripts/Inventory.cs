using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // This struct holds the information about an object in the inventory:
    public struct InventoryItem
    {
        // This is a reference to the item info provided by your class
        // It should contain information on the item type, and also a picture for use in the inventory.
        public GameObject Item_Info;

        // Quantity of item held:
        public int Number_Held;

        // Location of the item in the inventory grid:
        public int X_Location;
        public int Y_Location;

        public InventoryItem(GameObject item, int number, int x_Loc, int y_Loc)
        {
            Item_Info = item;
            Number_Held = number;
            X_Location = x_Loc;
            Y_Location = y_Loc;
        }

        // Increase the number of objects held (or decrease, by passing a negative number):
        public void IncreaseNumber(int number)
        { 
            Number_Held += number;
        }
    }

    public Dictionary<string, InventoryItem> m_Inventory = new Dictionary<string, InventoryItem>();

    int next_Free_X = 0;
    int next_Free_Y = 0;
    int width = 9;

    void OnTriggerEnter(Collider pCollider)
    {
        // Check that the object can be picked up here
        if (true)
        {
            // If we already have this object, increase the number we have
            if (m_Inventory.ContainsKey(pCollider.name))
            {
                m_Inventory[pCollider.name].IncreaseNumber(1);
            }
            else
            {
                // If we don't have this object, add a new entry to the inventory
                m_Inventory.Add(pCollider.name, new InventoryItem(GetItemInfo(pCollider), 1, next_Free_X, next_Free_Y));

                // Find the next free inventory slot for new items:
                next_Free_X++;
                if (next_Free_X >= width)
                {
                    next_Free_X = 0;
                    next_Free_Y++;
                }
            }
            // Destroy the object picked up:
            Destroy(pCollider.gameObject);
        }
    }

    private GameObject GetItemInfo(Collider pCollider)
    {
        // You will need to implement this, you could either have a central list (contained in a gameObject)
        // holding references to all possible items, or you could retrieve the information from the object you hit
        // with:
        return pCollider.GetComponent<GameObject>();
    }
}
