using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI title;
    public GameObject buttons;

    private void Start()
    {
        buttons.SetActive(false);
        title.color = new Color(title.color.a, title.color.g, title.color.b, 0);
        float alpha = new float();
        StartCoroutine(ShowTitle(alpha));
    }

    private IEnumerator ShowTitle(float alpha)
    {
        while (title.color.a < 1)
        {
            alpha += 0.5f * Time.deltaTime;
            title.color = new Color(title.color.r, title.color.g, title.color.b, alpha);
            yield return null;
        }

        title.color = new Color(title.color.a, title.color.g, title.color.b, 255);
        ShowButtons();
    }

    private void ShowButtons()
    {
        buttons.SetActive(true);
    }

    public void OnPlayButtonPress()
    {
        SceneManager.LoadScene("CustomerDemo");
    }

    public void OnSettingsButtonPress()
    {

    }

    public void OnCreditButtonPress()
    {
        SceneManager.LoadScene("Credits");
    }
}
