using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JSONController;

public class SpaceObject : MonoBehaviour
{
    
    public byte id;
    public string nameObject;
    public  float speed;
    public string textInfo;

    public ListInfoAboutObject listInfoAboutObject = new ListInfoAboutObject();

    public void InfoUpdate()
    {
        
        InfoAboutObject objectInfo = GetObjectInfoById(id);

        if (objectInfo != null)
        {
            nameObject = objectInfo.nameObject;
            speed = objectInfo.speed;
            textInfo = objectInfo.textInfo;
        }
        else
        {
            Debug.LogError($"Объект с ID {id} не найден.");
        }
    }

 
    private InfoAboutObject GetObjectInfoById(byte objectId)
    {
        foreach (var obj in listInfoAboutObject.infoAboutObject)
        {
            if (obj.id == objectId)
            {
                return obj;
            }
        }
        return null; // Объект не найден
    }
}
