using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    private float m_tolerance = 10f;
    private float m_timer;
    private Image m_customerImage;

    [SerializeField] private Sprite m_angryFace;

    private void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer >= m_tolerance * 0.5f)
        {
            GetAngry();
        }

        if (m_timer >= m_tolerance)
        {
            WalkAway();
        }
    }

    private void GetAngry()
    {
        m_customerImage.sprite = m_angryFace;
    }

    private void WalkAway()
    {
        //TODO: Lose Score
        //TODO: Clear customer slot
        //TODO: Show Walkaway animation
    }
}
    