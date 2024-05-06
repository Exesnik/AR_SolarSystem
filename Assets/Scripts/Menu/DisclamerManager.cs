using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class DisclamerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> textDisclamer;
    [SerializeField] private List<GameObject> materialDisclamer;
    [SerializeField] private List<GameObject> buttonsMenu;
    [SerializeField] private List<GameObject> textOnButton;
    [SerializeField] private List<GameObject> textMenu;
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;
    [SerializeField] private PostProcessVolume volume;


    private void Start()
    {
        for (int i = 0; i < materialDisclamer.Count; i++)
        {
            materialDisclamer[i].GetComponent<VisibleObject>().InvisibleMaterial();
        }
        volume.weight = 0f;
        StartCoroutine(Manager());
    }

    //private void Awake()
    //{
    //    for (int i = 0; i < textOnButton.Count; i++)
    //    {
    //        textOnButton[i].GetComponent<Visible>().StartVisible();
    //    }
    //    for (int i = 0; i < textMenu.Count; i++)
    //    {
    //        textMenu[i].GetComponent<Visible>().StartVisible();
    //    }
    //    for (int i = 0; i < buttonsMenu.Count; i++)
    //    {
    //        buttonsMenu[i].GetComponent<VisibleButtons>().StartVisible();
    //    }
    //}

    private IEnumerator Manager()
    {
        for (int i = 0; i < textDisclamer.Count; i++)
        {
            textDisclamer[i].GetComponent<Invisible>().StartInvisible();
        }
        yield return new WaitForSeconds(4.5f);
        for (int i = 0; i < textDisclamer.Count; i++)
        {
            textDisclamer[i].GetComponent<Visible>().StartVisible();
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < materialDisclamer.Count; i++)
        {
            materialDisclamer[i].GetComponent<VisibleObject>().StartVisible();
        }
        for (float i = 0; i <= 0.6f; i += 0.05f)
        {
            volume.weight = i;
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(1.7f);
        camera1.SetActive(false);
        yield return new WaitForSeconds(1.7f);
        camera2.SetActive(false);
        yield return new WaitForSeconds(1.8f);
        for (int i = 0; i < textMenu.Count; i++)
        {
            textMenu[i].GetComponent<Invisible>().StartInvisible();
        }
        for (int i = 0; i < textOnButton.Count; i++)
        {
            textOnButton[i].GetComponent<Invisible>().StartInvisible();
        }
        for (int i = 0; i < buttonsMenu.Count; i++)
        {
            buttonsMenu[i].GetComponent<InvisibleButton>().StartInvisible();
        }
    }
}
