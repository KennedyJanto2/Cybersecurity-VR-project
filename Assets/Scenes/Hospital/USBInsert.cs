using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class USBInsert : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject blackoutCanvas;
    public TextMeshProUGUI textCon;
    public TextMeshProUGUI textObj;

    public float fadeInDuration = 1f;

    private void Awake()
    {
        // Deactivate canvases by default
        blackoutCanvas.SetActive(false);
    }

    public void OnInsert(string consequences)
    {
        // Start the fade-in coroutine
        StartCoroutine(FadeInBlackoutCanvas(fadeInDuration));

        // Update the text
        textObj.text = "";
        textCon.text = consequences;
    }

    private IEnumerator FadeInBlackoutCanvas(float duration)
    {
        // Get the panel's Image component
        Image panelImage = blackoutCanvas.GetComponentInChildren<Image>();

        // Set the initial alpha value to 0
        Color panelColor = panelImage.color;
        panelColor.a = 0f;
        panelImage.color = panelColor;

        // Activate the blackout canvas
        blackoutCanvas.SetActive(true);

        // Fade in the panel over the specified duration
        float startTime = Time.time;
        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            panelColor.a = Mathf.Lerp(0f, 1f, t);
            panelImage.color = panelColor;

            yield return null;
        }

        // Ensure the final alpha value is set to 1
        panelColor.a = 1f;
        panelImage.color = panelColor;
    }
}
