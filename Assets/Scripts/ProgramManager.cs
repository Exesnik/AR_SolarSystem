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
    public Slider _slider;

    private void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        planeMarkerPrefab.SetActive(false);
    }

    private void Update()
    {
        ShowMarker();
    }

    private void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (onSolarSystem == true) // ���� ���� ��������� �������� �� ��� �������
        {
            planeMarkerPrefab.SetActive(false);
        }
        

        if (hits.Count > 0) // ���� �� ����� ��� ��� ������� �� ���������� ������
        {
            planeMarkerPrefab.transform.position = hits[0].pose.position;
            planeMarkerPrefab.SetActive(true);
        }
        else
        {
            planeMarkerPrefab.SetActive(false);
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


}
