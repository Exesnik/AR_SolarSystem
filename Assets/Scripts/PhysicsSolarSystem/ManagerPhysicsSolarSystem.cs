using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;


public class ManagerPhysicsSolarSystem : MonoBehaviour
{
    [SerializeField]
    [Header("Prefab for Plane Marker")]
    private GameObject planeMarkerPrefab;

    [SerializeField]
    [Header("Prefab for Object to Spawn")]
    private GameObject objectToSpawn;
    private bool onSolarSystem = false;

    private ARRaycastManager arRaycastManager;





    // ������ �� ��������� NBodySimulation
    public NBodySimulation nBodySimulation;


    // ���� ��� ������������ ��������� ���������
    bool isSimulating = false;

    void Start()
    {

        // ���������, ���������� �� ��������� NBodySimulation
        if (nBodySimulation == null)
        {
            Debug.LogError("��������� NBodySimulation �� ������ �� ManagerPhysicsSolarSystem!");
        }
    }

    // ����� ��� ������� ���������
    public void StartSimulation()
    {
        if (!isSimulating)
        {
            nBodySimulation.enabled = true; // �������� ������ NBodySimulation
            isSimulating = true;
        }
    }

    // ����� ��� ��������� ���������
    public void StopSimulation()
    {
        if (isSimulating)
        {
            nBodySimulation.enabled = false; // ��������� ������ NBodySimulation
            isSimulating = false;
        }
    }
}