using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverEffect : MonoBehaviour
{
    public float fadeDuration;

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Image image = GetComponent<Image>();
        Color initialColor = image.color;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = 1f - (t / fadeDuration);
            image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            yield return null;
        }
        image.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);
        gameObject.SetActive(false);
    }
}
