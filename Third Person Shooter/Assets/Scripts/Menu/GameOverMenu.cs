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
        backgroundColor.a = 1;
        while (true)
        {
            backgroundColor.a -= increment;
            imageBackground.color = backgroundColor;
            yield return new WaitForSeconds(0.1f * Time.deltaTime);
        }
    }

    IEnumerator FadeIn(float increment)
    {
        backgroundColor.a = 0;
        imageBackground.color = backgroundColor;
        
        while (true)
        {
            backgroundColor.a += increment;          
            imageBackground.color = backgroundColor;
            Debug.Log("Debug: " + backgroundColor.a);
            yield return new WaitForSeconds(0.1f * Time.deltaTime);
        }
    }
}
