using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleButtons : MonoBehaviour
{
    private Image button;

    private void Start()
    {
        button = GetComponent<Image>();
        Color color = button.color;
        color.a = 0f;
        button.color = color;
    }

    private IEnumerator InvisibleButtons()
    {
        for (float i = 1f; i >= -0.05f; i -= 0.05f)
        {
            Color color = button.color;
            color.a = i;
            button.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartVisible()
    {
        StartCoroutine(InvisibleButtons());
    }
}
