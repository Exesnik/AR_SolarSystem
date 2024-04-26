using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisibleButton : MonoBehaviour
{
    private Image button;

    private void Start()
    {
        button = GetComponent<Image>();
    }

    private IEnumerator InvisibleButtons()
    {
        for (float i = 0.05f; i <= 1; i += 0.05f)
        {
            Color color = button.color;
            color.a = i;
            button.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartInvisible()
    {
        StartCoroutine(InvisibleButtons());
    }
}
