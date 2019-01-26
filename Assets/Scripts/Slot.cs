using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    enum SlotType
    {
        one = 1,
        two,
        three,
        four
    }

    // target item
    private SlotType targetItem;
    private SlotType attachedItem;

    public void InitSlot()
    {
        AssignTargetItem();
    }

    public void AssignTargetItem()
    {
        targetItem = (SlotType)Random.Range(1, 4);
    }
    
    private void AttachItem(SlotType item)
    {
        attachedItem = item;
    }

    private void DetachItem()
    {
        attachedItem = 0;
    }
}
