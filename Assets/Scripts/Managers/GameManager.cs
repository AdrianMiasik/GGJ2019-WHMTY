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
    private int averageRating;  // Rating 1 = 0.5 Star, Rating 10 = 5 Star

    public TMPro.TextMeshProUGUI timerText;
    private float timer = 60;

    private void Start()
    {
        CreateNewShell();
        UpdateRatingIcon();
        UpdateTimerText();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        UpdateTimerText();
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
        //averageRating
        int numOfFullStar = averageRating / 2;
        bool halfStar = (averageRating % 2 == 1) ? true : false;

        for (int i = 0; i < ratingIcons.childCount; i++)
        {
            Star star = ratingIcons.GetChild(i).GetComponent<Star>();
            if (i < numOfFullStar)
            {
                star.ShowFullStar();
            }

            if (halfStar && i == numOfFullStar)
            {
                star.ShowHalfStar();
            }

            if (i > numOfFullStar)
            {
                star.ShowEmptyStar();
            }
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = string.Format("Time Left: {0}", ((int)timer).ToString());
    }

    public void AddTime(float time)
    {
        timer += time;
    }
}
