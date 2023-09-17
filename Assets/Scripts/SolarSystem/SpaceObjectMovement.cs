using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceObjectMovement : MonoBehaviour
{
    [SerializeField]
    private Transform ParentObject; //The object around which the rotation occurs
    
    private float speedMultiplier;
    [SerializeField]
    private Vector3 axis;

    private SpaceObject spaceObject;

    private float speed;


    private ProgramManager _programManager;

    private void Start()
    {
        // Finding the SpaceObject component in the same object
        spaceObject = GetComponent<SpaceObject>();
        _programManager = FindObjectOfType<ProgramManager>();
        // Checking that the component is found
        if (spaceObject == null)
        {
            Debug.LogError("SpaceObject component not found!");
        }
        else
        {
            speed = spaceObject.speed;
            
        }
    }

    private void Update()
    {
        if (_programManager != null)
        {
            speedMultiplier = _programManager._sliderSpeed.value;
        }
        else
        {
            Debug.LogWarning("ProgramManager not found!");
        }

        transform.RotateAround(ParentObject.position, axis, spaceObject.speed * speedMultiplier * Time.deltaTime);
    }
}