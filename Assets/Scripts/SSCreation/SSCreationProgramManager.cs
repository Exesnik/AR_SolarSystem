using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;

public class SSCreationProgramManager : MonoBehaviour
{
    private SSCreationSceneUIManager sceneUIManager;
    private ARRaycastManager arRaycastManager;

    [SerializeField]
    [Header("Prefab for Plane Marker")] 
    private GameObject planeMarkerPrefab; // ������ �������

    [SerializeField]
    [Header("Prefab for Plane Marker")]
    private GameObject spaceObjectPrefab; // ������ ������� ������������ �������


    private float scaleMultiplier;

    private void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        sceneUIManager = FindObjectOfType<SSCreationSceneUIManager>();

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



        if (hits.Count > 0) // ���� �� ����� ��� ��� ������� �� ���������� ������
        {
            planeMarkerPrefab.transform.position = hits[0].pose.position;
            planeMarkerPrefab.SetActive(true);
        }
        else
        {
            planeMarkerPrefab.SetActive(false);
        }

        // � ����������� �� ������ ��������� ������
        if (sceneUIManager.OnSpawnObjectMode == true)
        {
            planeMarkerPrefab.SetActive(true);
        } 
        else 
        { 
            planeMarkerPrefab.SetActive(false);
        }

        // ����� �������




    }

    public void SetGameObject()
    {
        Debug.Log("SetGameObject");

            GameObject spaceObject = Instantiate(spaceObjectPrefab, planeMarkerPrefab.transform.position, planeMarkerPrefab.transform.rotation);
            CelestialBody celestialBody = spaceObject.GetComponent<CelestialBody>();

        Debug.Log("ValidationValueCelestialBody");
            
            celestialBody.radius = sceneUIManager.radiusCelestialBody;
            
            celestialBody.radius = sceneUIManager.surfaceGravityCelestialBody;
            
            celestialBody.radius = sceneUIManager.initialVelocityCelestialBody;

    }


}
