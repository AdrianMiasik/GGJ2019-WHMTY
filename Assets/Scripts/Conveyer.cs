using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conveyer : MonoBehaviour
{
    [SerializeField] private float speed = 75f;
    [SerializeField] private GameObject otherConveyer;
    [SerializeField] private List<GameObject> decoratorPrefabs;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
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
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}