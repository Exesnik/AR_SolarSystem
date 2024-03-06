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
    private GameObject planeMarkerPrefab; // префаб маркера

    [SerializeField]
    [Header("Prefab for Plane Marker")]
    private GameObject spaceObjectPrefab; // префаб шаблона космического обьекта


    private float scaleMultiplier;

    public SSCreationSceneUIManager SSCreationSceneUIManager
    {
        get => default;
        set
        {
        }
    }

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

        // Спавн обьекта




    }

    public void SetGameObject()
    {
        Debug.Log("SetGameObject");

            GameObject spaceObject = Instantiate(spaceObjectPrefab, planeMarkerPrefab.transform.position, planeMarkerPrefab.transform.rotation);
            CelestialBody celestialBody = spaceObject.GetComponent<CelestialBody>();

        Debug.Log("ValidationValueCelestialBody");
            
            celestialBody.radius = sceneUIManager.radiusCelestialBody;
            
            celestialBody.surfaceGravity = sceneUIManager.surfaceGravityCelestialBody;

            celestialBody.initialVelocity = new Vector3(0, sceneUIManager.initialVelocityCelestialBody, 0);

        spaceObject.GetComponent<CelestialBody>().radius = sceneUIManager.radiusCelestialBody;
        spaceObject.GetComponent<CelestialBody>().surfaceGravity = sceneUIManager.surfaceGravityCelestialBody;
        spaceObject.GetComponent<CelestialBody>().initialVelocity = new Vector3(0, sceneUIManager.initialVelocityCelestialBody, 0);
    }


}
