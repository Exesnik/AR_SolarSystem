using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VisibleObject : MonoBehaviour
{
    [SerializeField]private Material objectMaterial;
    //private void Start()
    //{
    //    objectMaterial = GetComponent<Material>();
    //}

    private IEnumerator VisibleSprite()
    {
        for (float i = 1f; i >= -0.01f; i -= 0.01f)
        {
            Color color = objectMaterial.color;
            color.a = i;
            objectMaterial.color = color;
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void StartVisible()
    {
        StartCoroutine("VisibleSprite");
    }

    public void InvisibleMaterial()
    {
        Color color = objectMaterial.color;
        color.a = 1;
        objectMaterial.color = color;
    }
}
