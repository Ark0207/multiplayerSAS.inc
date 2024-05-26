using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fading : MonoBehaviour
{
    public TextMeshProUGUI gameName;
    public float fadeDuration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadingText());
    }
    IEnumerator fadingText()
    {
        yield return new WaitForSeconds(2);
        Color originalcolor = gameName.color;
        float currentTime = 0;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, currentTime / fadeDuration);
            gameName.color = new Color(originalcolor.r, originalcolor.g, originalcolor.b, alpha);
            yield return null;
        }

        gameName.gameObject.SetActive(true);
    }
}
