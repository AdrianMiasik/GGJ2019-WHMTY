using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemType Type;
    private RectTransform m_DraggingPlane;
    private Vector3 m_dragOffset;
    private bool isAttached;

    public enum ItemType
    {
        one = 1,
        two,
        three,
        four
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isAttached) return;

        m_DraggingPlane = transform as RectTransform;
        transform.SetParent(transform.parent.parent, true);

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, eventData.position, eventData.pressEventCamera, out m_dragOffset))
        {
            m_dragOffset = transform.GetComponent<RectTransform>().position - m_dragOffset;
        }
        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isAttached) return;

        if (transform != null)
        {
            SetDraggedPosition(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isAttached) return;

        CheckIntoSlot();
    }

    private float threshold = 40f;
    private void CheckIntoSlot()
    {
        foreach(Slot slot in GameManager.Instance.shell.Slots)
        {
            float distance = Vector2.Distance(slot.transform.position, transform.position);
            
            if (distance < threshold)
            {
                Debug.LogError("find one slot");
                PutItemInSlot(slot);
                break;
            }
        }
    }

    private void PutItemInSlot(Slot slot)
    {
        if (slot.IsAttached)
        {
            Destroy(gameObject);
            return;
        }
        isAttached = true;
        slot.AttachItem(this);
        transform.SetParent(slot.transform);
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        if (data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = transform.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos + m_dragOffset;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Type = (ItemType)Random.Range(1, 4);
    }
}
