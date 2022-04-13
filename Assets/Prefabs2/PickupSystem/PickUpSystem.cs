using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    public InventorySO inventoryData;

    private void OnTriggerEnter(Collider collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            int reminder = inventoryData.AddItem(item.InventoryItemUI, item.Quantity);
            if (reminder == 0)
            {
                item.DestroyItem();
            }
            else
                item.Quantity = reminder;
        }
    }

}
