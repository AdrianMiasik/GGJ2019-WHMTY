using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ImageRandomColorOnStart : MonoBehaviour
{
    public Image image;

    private void Reset()
    {
        if (image == null)
        {
            // Attempt to get an image
            image = GetComponent<Image>();
        }

        if (image == null)
        {
            Debug.LogAssertion("Could not find a image component.");
        }
    }

    public void GenerateRandomColor()
    {
        image.color = Random.ColorHSV();
    }
}
