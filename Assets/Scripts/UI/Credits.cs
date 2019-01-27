using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Credits : MonoBehaviour
{
    private TextMeshProUGUI tmpUGUI;

    private void Awake()
    {
        tmpUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        float speed = 500f;
        RectTransform rectTransform = GetComponent<RectTransform>();
        StartCoroutine(ShowCredits(rectTransform, speed));
    }

    private IEnumerator ShowCredits(RectTransform rectTransform, float scrollSpeed)
    {
        while(rectTransform.localPosition.y <= 0)
        {
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, rectTransform.localPosition.y + scrollSpeed * Time.deltaTime, rectTransform.localPosition.z);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        tmpUGUI.text = "Created by Melted Pixel\n" + "\n" +
        	"Global Game Jam, 2019";
        tmpUGUI.alignment = TextAlignmentOptions.Center;

        yield return new WaitForSeconds(2f);

        LoadMainMenu();
    }

    private void LoadMainMenu()
    {
        Debug.Log("Loading Main Menu!");
    }
}
