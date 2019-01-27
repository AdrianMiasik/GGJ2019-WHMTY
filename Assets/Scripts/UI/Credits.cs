using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Credits : MonoBehaviour
{
    private TextMeshProUGUI tmpUGUI;
    private float alpha = 1;

    private void Awake()
    {
        tmpUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        float speed = 50;
        RectTransform rectTransform = GetComponent<RectTransform>();
        StartCoroutine(ShowCredits(rectTransform, speed));
    }

    private IEnumerator ShowCredits(RectTransform rectTransform, float scrollSpeed)
    {
        while(rectTransform.localPosition.y <= 1325)
        {
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, rectTransform.localPosition.y + scrollSpeed * Time.deltaTime, rectTransform.localPosition.z);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        tmpUGUI.text = "\nCreated by Melted Pixel\n" + "\n" +
        	"Global Game Jam, 2019";
        tmpUGUI.alignment = TextAlignmentOptions.Center;

        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, 0, rectTransform.localPosition.z);

        yield return new WaitForSeconds(1.5f);

        while (tmpUGUI.color.a > 0)
        {
            alpha -= 0.25f * Time.deltaTime;
            tmpUGUI.color = new Color(tmpUGUI.color.r, tmpUGUI.color.g, tmpUGUI.color.b, alpha);
            yield return null;
        }

        tmpUGUI.color = new Color(tmpUGUI.color.a, tmpUGUI.color.g, tmpUGUI.color.b, 0);

        yield return new WaitForSeconds(1f);

        LoadMainMenu();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
