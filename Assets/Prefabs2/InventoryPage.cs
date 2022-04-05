using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    [SerializeField]
    private InventoryItem itemPrefab;
    [SerializeField]
    private RectTransform contentPanel;

    List<InventoryItem> listOfUIItems = new List<InventoryItem>();

    public void InitializeInventoryUI(int inventorysize)
    {
        for (int i = 0; i < inventorysize; i++)
        {
            InventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    private void HandleShowItemActions(InventoryItem obj)
    {
        
    }

    private void HandleEndDrag(InventoryItem obj)
    {
        
    }

    private void HandleSwap(InventoryItem obj)
    {
        
    }

    private void HandleBeginDrag(InventoryItem obj)
    {
        
    }

    private void HandleItemSelection(InventoryItem obj)
    {
        Debug.Log(obj.name);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}