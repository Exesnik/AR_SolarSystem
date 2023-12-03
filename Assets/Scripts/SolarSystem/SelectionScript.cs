using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    public Transform Selected_object;
    public float width = 22.2f;
    // Update is called once per frame

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    void Update()
    {   // Кликаем на объект и записивыем его туда
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform != gameObject.transform)
                {
                    Selected_object = hit.transform;
                    Debug.Log(Selected_object.name);
                }
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                Selected_object = null;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (Selected_object != null)
        {
            gameObject.transform.position = Selected_object.transform.position;
            Vector3 new_scale = new Vector3(Selected_object.transform.localScale.x + width, Selected_object.transform.localScale.y + width, Selected_object.transform.localScale.z + width);
            gameObject.transform.localScale = new_scale;
        }

    }
}