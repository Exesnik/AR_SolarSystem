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


    [SerializeField]
    [Header("Prefab for Plane Marker")] 
    private GameObject planeMarkerPrefab;

    [SerializeField]
    [Header("Prefab for Object to Spawn")]
    private GameObject objectToSpawn;

    private bool onSolarSystem = false;

    private ARRaycastManager arRaycastManager;


    private float scaleMultiplier;

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



        if (hits.Count > 0) // если не видит пол для спавнаб не показывает маркер
        {
            planeMarkerPrefab.transform.position = hits[0].pose.position;
            planeMarkerPrefab.SetActive(true);
        }
        else
        {
            planeMarkerPrefab.SetActive(false);
        }

        // в зависимости от режима отключает маркер
        if (sceneUIManager.OnSpawnObjectMode == true)
        {
            planeMarkerPrefab.SetActive(true);
        } 
        else 
        { 
            planeMarkerPrefab.SetActive(false);
        }

    }



}
