    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    



public class SpaceObject : MonoBehaviour
{
    public int id;
    public string nameObject;
    public float speed;
    public string textInfo;

    private SolarSystemObject data;

    public void UpdateInfo()
    {
        SolarSystemDataManager dataManager = FindObjectOfType<SolarSystemDataManager>();
        data = dataManager.GetObjectById(id);

        if (data == null)
        {
            Debug.LogError($"Failed to find data for space object with ID: {id}");
            textInfo = "Информация не найдена"; // Default text if data is not found
        }
        else
        {
            // Update textInfo with the data from SolarSystemDataManager
            nameObject = data.nameObject;
            speed = data.speed;
            textInfo = data.textInfo;
        }
    }
}