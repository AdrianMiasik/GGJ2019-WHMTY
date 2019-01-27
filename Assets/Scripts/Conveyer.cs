using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conveyer : MonoBehaviour
{
    private float speed = 5f;
    [SerializeField] private GameObject otherConveyer;
    [SerializeField] private List<GameObject> decoratorPrefabs;
    public GameObject Item;
    private RectTransform rectTransform;

    public List<Transform> ConveyerSlots;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        AddItems();
    }

    private void FixedUpdate()
    {
        float posY = rectTransform.localPosition.y - speed;
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, posY, rectTransform.localPosition.z);

        if (this.name == "Conveyor2")
        {
            if (rectTransform.localPosition.y <= -rectTransform.rect.height) // Reached bottom
            {
                ResetConveyer();
            }
        }
        else
        {
            if (rectTransform.localPosition.y <= -rectTransform.rect.height + speed) // Reached bottom
            {
                ResetConveyer();
            }
        }

    }

    private void ResetConveyer()
    {
        float posY;
        if (this.name == "Conveyor2")
        {
            posY = otherConveyer.GetComponent<RectTransform>().localPosition.y + rectTransform.rect.height;
        }
        else
        {
            posY = otherConveyer.GetComponent<RectTransform>().localPosition.y + rectTransform.rect.height - speed;
        }
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, posY, rectTransform.localPosition.z);
        foreach (Transform slot in ConveyerSlots)
        {
            if (slot.childCount > 0)
            {
                Transform trans = slot.GetChild(0);
                if (trans)
                {
                    trans.SetParent(null);
                    Destroy(trans.gameObject);
                }
            }
        }
        AddItems();
    }

    private void AddItems()
    {
        foreach(Transform t in ConveyerSlots)
        {
            if (t.childCount == 0)
            {
                GameObject item = Instantiate(Item, t);
            }
        }
    } 
}