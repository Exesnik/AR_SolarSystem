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
    public float radiusCelestialBody;
    public float surfaceGravityCelestialBody;
    public float initialVelocityCelestialBody;



    public bool OnSpawnObjectMode = true;



    private void Start()
    {
        
    }

    // buttons
    public void btn_Open_UI_ObjectValueSetting()
    {
        Debug.Log("btn_Open_UI_ObjectValueSetting");

        UI_ObjectValueSetting.SetActive(true);
        UI_SetUpObjectOnScene.SetActive(false);

        OnSpawnObjectMode = false;
    }
    public void btn_Open_UI_SetUpObjectOnScene()
    {
        Debug.Log("btn_Open_UI_SetUpObjectOnScene");

        UI_SetUpObjectOnScene.SetActive(true);
        UI_ObjectValueSetting.SetActive(false);

        OnSpawnObjectMode = true;

        

    }

    //input field ���������� ������


    public void AssignInputToVariable()
    {
        Debug.Log("AssignInputToVariable");

        radiusCelestialBody = float.Parse(radiusInputField.text);
        surfaceGravityCelestialBody = float.Parse(surfaceGravityInputField.text);
        initialVelocityCelestialBody = float.Parse(initialVelocityInputField.text);        
    }



}
