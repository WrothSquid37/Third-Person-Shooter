using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Transform container;
    public Transform background;
    public Image imageBackground;
    public Color backgroundColor;
    Color c;

    private void Start()
    {
        container.gameObject.SetActive(false);
        StartCoroutine(FadeOut(0.025f));
        c = backgroundColor;
    }

    public void ShowMenu()
    {
        container.gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(FadeIn(0.025f));
    }

    IEnumerator FadeOut(float increment)
    {
        imageBackground.color = c;
        float t = 0;
        while (true)
        {
            backgroundColor.a -= increment;
            yield return new WaitForSeconds(Time.deltaTime);
            t += increment;
            imageBackground.color = backgroundColor;            
        }
    }
    IEnumerator FadeIn(float increment)
    {
        float t = 0;
        backgroundColor.a = 0;
        imageBackground.color = backgroundColor;
        while (true)
        {
            backgroundColor.a += increment;
            yield return new WaitForSeconds(Time.deltaTime);
            t += increment;
            imageBackground.color = backgroundColor;
        }
    }
}
