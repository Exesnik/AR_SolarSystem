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





    // Ссылка на компонент NBodySimulation
    public NBodySimulation nBodySimulation;


    // Флаг для отслеживания состояния симуляции
    bool isSimulating = false;

    void Start()
    {

        // Проверяем, прикреплен ли компонент NBodySimulation
        if (nBodySimulation == null)
        {
            Debug.LogError("Компонент NBodySimulation не найден на ManagerPhysicsSolarSystem!");
        }
    }

    // Метод для запуска симуляции
    public void StartSimulation()
    {
        if (!isSimulating)
        {
            nBodySimulation.enabled = true; // Включаем скрипт NBodySimulation
            isSimulating = true;
        }
    }

    // Метод для остановки симуляции
    public void StopSimulation()
    {
        if (isSimulating)
        {
            nBodySimulation.enabled = false; // Выключаем скрипт NBodySimulation
            isSimulating = false;
        }
    }
}