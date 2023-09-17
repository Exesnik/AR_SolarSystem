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

    [SerializeField]
    [Header("Speed")]
    public Slider _sliderSpeed;
    [SerializeField]
    [Header("Scale")]
    public Slider _sliderScale;

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



}
