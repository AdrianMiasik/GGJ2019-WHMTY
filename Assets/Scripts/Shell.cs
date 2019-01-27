using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    public GameObject Slot;

    private int slotsCount;
    public List<Slot> Slots;

    private RectTransform m_DraggingPlane;

    private void Start()
    {
        InitShell();
    }

    private void InitShell()
    { 
        foreach(Slot slot in Slots)
        {
            slot.InitSlot();
        }
    }

    private void ShrinkShell()
    {
        transform.localScale *= 0.1f;
    }

    private void ResetShell()
    {
        transform.localScale *= 10f;
    } 

    public void OnBeginDrag(PointerEventData eventData)
    {
        ShrinkShell();
        m_DraggingPlane = transform as RectTransform;

        SetDraggedPosition(eventData);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (transform != null)
            SetDraggedPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResetShell();
        SendShellToCustomer();
    }

    private float threshold = 100f;
    private void SendShellToCustomer()
    {
        foreach(Customer c in Main.Instance.customerManager.GetAllCustomers())
        {
            float distance = Vector2.Distance(c.transform.position, transform.position);

            if(distance < threshold)
            {
                c.ReceiveShell(this);
                return;
            }
        }
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        if (data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = transform.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
        }
    }
}
