using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject shellPrefab;
    public Transform shellSpawner;
    public Shell shell { get; set; }

    public Transform ratingIcons;
    private int customerCount;
    private int totalScore;
    private int averageRating;

    public Transform lifeIcons;
    public int life = 5;

    private void Start()
    {
        CreateNewShell();
        UpdateRatingIcon();
    }

    public void CreateNewShell()
    {
        GameObject shellGO = Instantiate(shellPrefab, shellSpawner);
        shell = shellGO.GetComponent<Shell>();
    }

    /// <summary>
    /// Rates the store.
    /// </summary>
    /// <returns>Average.</returns>
    /// <param name="rate">Rate between 1 - 10, each represent half star.</param>
    public int RateStore(int rate)
    {
        totalScore += rate;
        customerCount++;
        averageRating = totalScore / customerCount;
        UpdateRatingIcon();
        return averageRating;
    }

    private void UpdateRatingIcon()
    {
        for (int i = 0; i < ratingIcons.childCount; i++)
        {
            if (i <= averageRating - 1)
            {
                ratingIcons.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                ratingIcons.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void UpdateLifeIcon()
    {
        for (int i = 0; i < lifeIcons.childCount; i++)
        {
            if (i <= life - 1)
            {
                lifeIcons.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                lifeIcons.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
