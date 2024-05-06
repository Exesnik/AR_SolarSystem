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
    private TMP_InputField radiusInputField;
    [SerializeField]
    [Header("SurfaceGravity")]
    private TMP_InputField surfaceGravityInputField;
    [Header("InitalVelocity")]
    [SerializeField]
    private TMP_InputField initialVelocityInputField;


    // create Input celestial body
    [HideInInspector]
    public float radiusCelestialBody;
    [HideInInspector]
    public float surfaceGravityCelestialBody;
    [HideInInspector]
    public float initialVelocityCelestialBody;

    public bool OnSpawnObjectMode = true;

    [SerializeField]
    private GameObject orbitDebugDisplay;

    // buttons
    public void btn_Open_UI_ObjectValueSetting()
    {
        Debug.Log("btn_Open_UI_ObjectValueSetting");

        UI_ObjectValueSetting.SetActive(true);
        UI_SetUpObjectOnScene.SetActive(false);

        OnSpawnObjectMode = false;

        orbitDebugDisplay.SetActive(false);
    }
    public void btn_Open_UI_SetUpObjectOnScene()
    {
        Debug.Log("btn_Open_UI_SetUpObjectOnScene");

        UI_SetUpObjectOnScene.SetActive(true);
        UI_ObjectValueSetting.SetActive(false);

        OnSpawnObjectMode = true;

        orbitDebugDisplay.SetActive(true);


    }

    //input field обновление данных


    public void AssignInputToVariable()
    {
        Debug.Log("AssignInputToVariable");

        radiusCelestialBody = float.Parse(radiusInputField.text);
        surfaceGravityCelestialBody = float.Parse(surfaceGravityInputField.text);
        initialVelocityCelestialBody = float.Parse(initialVelocityInputField.text);

      
    }



}
