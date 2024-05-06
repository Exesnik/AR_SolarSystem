using System.Collections;
using System.Collections.Generic;
using TMPro;
<<<<<<< HEAD
=======

>>>>>>> 151ddb1d0c5d24f742396f03318c0175fd845edd
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
