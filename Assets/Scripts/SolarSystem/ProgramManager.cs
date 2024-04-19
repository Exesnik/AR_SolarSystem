using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;

public class ProgramManager : MonoBehaviour
{
    [SerializeField]
    [Header("Prefab for Plane Marker")]
    private GameObject planeMarkerPrefab;

    [SerializeField]
    [Header("Prefab for Object to Spawn")]
    private GameObject objectToSpawn;
    private bool onSolarSystem = false;

    private ARRaycastManager arRaycastManager;

    // //// //// //// //// //
    [Header("UI")]
    [SerializeField]
    private GameObject ui_LookingMode;
    [SerializeField]
    private GameObject ui_ReadMode;

    [SerializeField]
    private GameObject btn_ShowInfo;
    [SerializeField]
    private GameObject btn_NotShowInfo;

    [SerializeField]
    private GameObject infoScrollView;
    [SerializeField]
    private GameObject text_infoScrollView;

    [Header("Sliders")]

    public Slider _sliderSpeed;
    public Slider _sliderScale;

    // //// //// //// //// //


    private float scaleMultiplier;


    private void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        planeMarkerPrefab.SetActive(false);


    }

    private void Update()
    {
        ShowMarker();



        scaleMultiplier = _sliderScale.value;


        GameObject solarSystem = GameObject.FindWithTag("Solar System");

        if (solarSystem != null)
        {
            solarSystem.transform.localScale = new Vector3(1f * scaleMultiplier, 1f * scaleMultiplier, 1f * scaleMultiplier);
        }


        //

        RaycastHit hit;
        if (CheckRaycastToObject("TrackingObject", out hit))
        {
            OnTrackingObjectHit(hit);
        }
        else
        {
            btn_ShowInfo.SetActive(false);
        }

    }


    public void SpawnOrDestroyOnMarker()
    {

        Debug.Log("try Spawn");

        GameObject solarSystem = GameObject.FindWithTag("Solar System");

        if (solarSystem != null)
        {
            // ������� ������ ������ Solar System
            Destroy(solarSystem);
            Debug.Log("Destroy");
            onSolarSystem = false;
        }
        else
        {
            // ������� ����� ������ �� ������� �������
            try
            {
                onSolarSystem = true;
                Debug.Log("Spawn");
                Instantiate(objectToSpawn, planeMarkerPrefab.transform.position, planeMarkerPrefab.transform.rotation);
            }
            catch (System.Exception e)
            {
                Debug.LogError("������ ��� ������: " + e.Message);
            }
        }
    }

    private void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);



        if (hits.Count > 0) // ���� �� ����� ��� ��� ������� �� ���������� ������
        {
            planeMarkerPrefab.transform.position = hits[0].pose.position;
            planeMarkerPrefab.SetActive(true);
        }
        else
        {
            planeMarkerPrefab.SetActive(false);
        }

        if (onSolarSystem == true) // ���� ���� ��������� �������� �� ��� �������
        {
            planeMarkerPrefab.SetActive(false);
        }

    }

    private bool CheckRaycastToObject(string objectTag, out RaycastHit hit)
    {
        // �������� ���� �� ������ ������
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        // �������� ������������ ���� � ��������
        return Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.gameObject.tag == objectTag;
    }

    private SpaceObject currentSpaceObject;

    private void OnTrackingObjectHit(RaycastHit hit)
    {
        Debug.Log("������ � ����� 'TrackingObject' ������!");
        currentSpaceObject = hit.collider.gameObject.GetComponent<SpaceObject>();

        if (currentSpaceObject != null)
        {
            btn_ShowInfo.SetActive(true);
            // Update info immediately on hit
            currentSpaceObject.UpdateInfo();
            text_infoScrollView.GetComponent<TextMeshProUGUI>().text = currentSpaceObject.textInfo;
        }
    }

    float saveSpeed;

    public void ShowInfo()
    {
        saveSpeed = _sliderSpeed.value;
        _sliderSpeed.value = 0;

       // bool onShowInfo = true;
        
        infoScrollView.SetActive(true);
        btn_ShowInfo.SetActive(false);
        btn_NotShowInfo.SetActive(true);
        

        currentSpaceObject.UpdateInfo();

        Debug.Log(
        $"ID: {currentSpaceObject.id}, " +
        $"��������: {currentSpaceObject.nameObject}, " +
        $"��������: {currentSpaceObject.speed}, " +
        $"��������: {currentSpaceObject.textInfo}"
    );


        text_infoScrollView.GetComponent<TextMeshProUGUI>().text = currentSpaceObject.textInfo;




 /*       if (onShowInfo == true)
        {
            onShowInfo = false;
            Debug.Log("����������� � ������� �����");
            btn_ShowInfo.SetActive(true);
            infoScrollView.SetActive(false);
            _sliderSpeed.value = saveSpeed;
        }*/

    }

    public void NotShowInfo()
    {
        Debug.Log("����������� � ������� �����");

        infoScrollView.SetActive(false);

        btn_ShowInfo.SetActive(true);

        btn_NotShowInfo.SetActive(false);


    }

}
