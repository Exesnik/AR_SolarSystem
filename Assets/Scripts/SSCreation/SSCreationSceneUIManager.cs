using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;

public class SSCreationSceneUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject UI_ObjectValueSetting;
    [SerializeField]
    private GameObject UI_SetUpObjectOnScene;

    [Space]

    [SerializeField]
    [Header("Radius")]
    public TMP_InputField radiusInputField;
    [SerializeField]
    [Header("SurfaceGravity")]
    public TMP_InputField surfaceGravityInputField;
    [Header("InitalVelocity")]
    [SerializeField]
    public TMP_InputField initialVelocityInputField;


    public bool OnSpawnObjectMode = true;


    // buttons
    public void btn_Open_UI_ObjectValueSetting()
    {
        UI_ObjectValueSetting.SetActive(true);
        UI_SetUpObjectOnScene.SetActive(false);

        OnSpawnObjectMode = false;
    }
    public void btn_Open_UI_SetUpObjectOnScene()
    {
        UI_SetUpObjectOnScene.SetActive(true);
        UI_ObjectValueSetting.SetActive(false);

        OnSpawnObjectMode = true;
    }

    //input field





}
