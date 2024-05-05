using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class Invisible : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    private IEnumerator InvisibleSprite()
    {
        for (float i = 0.05f; i <= 1; i += 0.05f)
        {
            Color color = text.color;
            color.a = i;
            text.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartInvisible()
    {
        StartCoroutine(InvisibleSprite());
    }

}
