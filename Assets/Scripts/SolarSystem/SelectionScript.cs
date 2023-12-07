using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    public Transform Selected_object;
    public float width = 0.5f;
    Camera maincamera;
    // Update is called once per frame

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        maincamera = FindObjectOfType<Camera>();
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
            var heading = Selected_object.transform.position - maincamera.transform.position;
            var distance = heading.magnitude;
            float distance_multiplier = Mathf.Clamp(distance / 10, 0, Mathf.Infinity);
            Vector3 way = heading / distance;
            Vector3 new_scale = new Vector3(Selected_object.transform.localScale.x * width, Selected_object.transform.localScale.y * width, Selected_object.transform.localScale.z * width);
            float average_scale = (new_scale.x + new_scale.y + new_scale.z) / 3f;
            gameObject.transform.localScale = new Vector3(average_scale, average_scale, average_scale);
            gameObject.transform.position = Selected_object.transform.position + way * average_scale * distance / 5;
        }

    }
}