using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public Image leftStar;
    public Image rightStar;
    public Sprite emptyStar;
    public Sprite halfStar;
    public Sprite fullStar;

    private void Start()
    {
        ShowEmptyStar();
    }

    public void ShowEmptyStar()
    {
        leftStar.sprite = emptyStar;
        rightStar.sprite = emptyStar;
    }

    public void ShowHalfStar()
    {
        leftStar.sprite = halfStar;
        rightStar.sprite = emptyStar;
    }

    public void ShowFullStar()
    {
        leftStar.sprite = halfStar;
        rightStar.sprite = fullStar;
    }
}
