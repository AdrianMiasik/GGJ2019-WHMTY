using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conveyer : MonoBehaviour
{
    private float speed = 175f;
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

    private void Update()
    {
        float posY = rectTransform.localPosition.y - Time.deltaTime * speed;
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, posY, rectTransform.localPosition.z);

        if (rectTransform.localPosition.y <= -1248) // Reached bottom
        {
            ResetConveyer();
        }
    }

    private void ResetConveyer()
    {
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, 1248, rectTransform.localPosition.z);
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