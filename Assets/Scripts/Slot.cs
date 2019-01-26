using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    // target item
    public bool IsAttached { get { return attachedItem; } }
    private Item.ItemType targetItem;
    private Item attachedItem;

    public void InitSlot()
    {
        AssignTargetItem();
    }

    public void AssignTargetItem()
    {
        targetItem = (Item.ItemType)Random.Range(1, 4);
    }
    
    public void AttachItem(Item item)
    {
        Debug.LogError("Attached item: " + (int)item.Type);
        attachedItem = item;
    }
}
