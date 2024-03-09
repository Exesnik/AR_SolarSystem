using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JSONController;

public class JSONController : MonoBehaviour
{
    public TextAsset textJSON;

    [System.Serializable]

    public class InfoAboutObject {
        public byte id;
        public string nameObject;
        public float speed;
        public string textInfo;

    }

    [System.Serializable]

    public class ListInfoAboutObject {

        public InfoAboutObject[] infoAboutObject;

    }

    public ListInfoAboutObject listInfoAboutObject = new ListInfoAboutObject();

    private void Start()
    {
        listInfoAboutObject = JsonUtility.FromJson<ListInfoAboutObject>(textJSON.text);
    }
}
