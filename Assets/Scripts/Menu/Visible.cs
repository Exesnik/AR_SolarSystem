using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Visible : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        Color color = text.color;
        color.a = 0f;
        text.color = color;
    }

    private IEnumerator VisibleSprite()
    {
        for (float i = 1f; i >= -0.05f; i -= 0.05f)
        {
            Color color = text.color;
            color.a = i;
            text.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void StartVisible()
    {
        StartCoroutine("VisibleSprite");
    }

}
