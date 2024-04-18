using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturnRotation : MonoBehaviour
{
    [SerializeField]private float axisX = 0f;
    [SerializeField]private float axisY = 0f;
    [SerializeField]private float axisZ = 0f;

    private void Update()
    {
        transform.Rotate(axisX, axisY, axisZ);
    }
}
