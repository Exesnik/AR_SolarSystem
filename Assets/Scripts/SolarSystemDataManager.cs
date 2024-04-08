using System.Linq;
using UnityEngine;

[System.Serializable]
public class SolarSystemObject
{
    public int id;
    public string nameObject;
    public int speed;
    public string textInfo;
}

public class SolarSystemDataManager : MonoBehaviour
{
    private SolarSystemObject[] solarSystemObjects;

    public SolarSystemObject SolarSystemObject
    {
        get => default;
        set
        {
        }
    }

    void Start()
    {
        TextAsset jsonData = Resources.Load<TextAsset>("SolarSystemData");

        if (jsonData == null)
        {
            Debug.LogError("Failed to load SolarSystemData.json!");
            return;
        }

        solarSystemObjects = JsonHelper.FromJson<SolarSystemObject>(jsonData.text);

/*
        foreach (SolarSystemObject obj in solarSystemObjects)
        {
            Debug.Log(
                $"ID: {obj.id}, " +
                $"Название: {obj.nameObject}, " +
                $"Скорость: {obj.speed}, " +
                $"Описание: {obj.textInfo}"
            );

        }*/

    }

    public SolarSystemObject GetObjectById(int id)
    {
        if (solarSystemObjects == null)
        {
            Debug.LogError("Solar system data not loaded!");
            return null;
        }

        return solarSystemObjects.FirstOrDefault(obj => obj.id == id);
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.infoAboutObject;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] infoAboutObject;
    }
}