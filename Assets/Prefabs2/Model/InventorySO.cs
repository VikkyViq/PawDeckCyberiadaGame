using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class InventorySO : ScriptableObject
    {
        [SerializeField]
        private List<InventoryItemUI> inventoryItems;

        [field: SerializeField]
        public int Size { get; private set; } = 10;

        public event Action<Dictionary<int, InventoryItemUI>> OnInventoryUpdated;

        public void Initialize()
        {
            inventoryItems = new List<InventoryItemUI>();
            for (int i = 0; i < Size; i++)
            {
                inventoryItems.Add(InventoryItemUI.GetEmptyItem());
            }
        }

        public void AddItem(ItemSO item, int quantity)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                {
                    inventoryItems[i] = new InventoryItemUI()
                    {
                        item = item,
                        quantity = quantity
                    };
                    return;
                }
            }
        }

        public void AddItem(InventoryItemUI item)
        {
            AddItem(item.item, item.quantity);
        }

        public Dictionary<int, InventoryItemUI> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItemUI> returnValue = new Dictionary<int, InventoryItemUI>();
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmpty)
                    continue;
                returnValue[i] = inventoryItems[i];
            }
            return returnValue;
        }

        public InventoryItemUI GetItemAt(int itemIndex)
        {
            return inventoryItems[itemIndex];
        }

        public void SwapItems(int itemIndex_1, int itemIndex_2)
        {
            InventoryItemUI item1 = inventoryItems[itemIndex_1];
            inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
            inventoryItems[itemIndex_2] = item1;
            InformAboutChange();
        }

        private void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
        }
    }

    [Serializable]
    public struct InventoryItemUI
    {
        public int quantity;
        public ItemSO item;

        public bool IsEmpty => item == null;
        public InventoryItemUI ChangeQuantity(int newQuantity)
        {
            return new InventoryItemUI
            {
                item = this.item,
                quantity = newQuantity,
            };
        }
        public static InventoryItemUI GetEmptyItem()
             => new InventoryItemUI
             {
                 item = null,
                 quantity = 0,
             };
    }
}