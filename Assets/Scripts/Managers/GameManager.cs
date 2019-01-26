using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject shellPrefab;
    public Transform shellSpawner;
    public Shell shell;

    public TMPro.TextMeshProUGUI scoreText;
    public int score;

    public Transform lifeIcons;
    public int life = 5;

    private void Start()
    {
        CreateNewShell();
        UpdateScore();
    }

    public void CreateNewShell()
    {
        GameObject shellGO = Instantiate(shellPrefab, shellSpawner);
        shell = shellGO.GetComponent<Shell>();
    }

    private void UpdateScore()
    {
        scoreText.text = string.Format("Score: {0}", score);
    }

    private void UpdateLife()
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
