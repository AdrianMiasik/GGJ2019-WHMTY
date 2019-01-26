using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private TextMeshProUGUI m_scoreText;

    private int m_score;

    public void AddScore(int Score)
    {
        m_score += Score;
        m_scoreText.text = m_score.ToString(); 
    }
}