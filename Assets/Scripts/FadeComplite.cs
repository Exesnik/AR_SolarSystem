using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeComplite : MonoBehaviour
{
    [SerializeField] private Image fadeDisplay;
    [SerializeField] private GameObject display;
    private void Awake()
    {
        display.SetActive(true);
        Color color = fadeDisplay.color;
        color.a = 1;
        fadeDisplay.color = color;
    }
    void Start()
    {
        StartCoroutine(FadeOnComplite());
    }

    private IEnumerator FadeOnComplite()
    {
        yield return new WaitForSeconds(2f);
        for (float i = 1f; i >= -0.01; i -= 0.01f)
        {
            Color color = fadeDisplay.color;
            color.a = i;
            fadeDisplay.color = color;
            yield return new WaitForSeconds(0.002f);
        }
        display.SetActive(false);
    }
}
