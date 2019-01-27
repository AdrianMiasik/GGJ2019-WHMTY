using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    // target item
    public bool IsAttached { get { return attachedItem; } }
    [SerializeField] private Item.ItemType targetItem;
    private Item attachedItem;

    public bool IsMatchItem()
    {
        if(attachedItem != null && (int)targetItem != 0 && (int)attachedItem.Type != 0)
        {
            return targetItem == attachedItem.Type;
        }
        else
        {
            return false;
        }
    }
    
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
        attachedItem = item;
    }
}
