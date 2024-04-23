/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisclamerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> textList;
    [SerializeField] List<GameObject> materialList;
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;

    private void Start()
    {
        for (int i = 0; i < materialList.Count; i++)
        {
            materialList[i].GetComponent<VisibleObject>().InvisibleMaterial();
        }
        StartCoroutine(Manager());
    }

    private IEnumerator Manager()
    { 
        for(int i = 0;i < textList.Count;i++) 
        {
            textList[i].GetComponent<Invisible>().StartInvisible();
        }
        yield return new WaitForSeconds(5);
        for (int i = 0; i < textList.Count; i++)
        {
            textList[i].GetComponent<Visible>().StartVisible();
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < materialList.Count; i++)
        {
            materialList[i].GetComponent<VisibleObject>().StartVisible();
        }
        yield return new WaitForSeconds(1.7f);
        camera1.SetActive(false);
        yield return new WaitForSeconds(1.7f);
        camera2.SetActive(false);
    }
}
*/