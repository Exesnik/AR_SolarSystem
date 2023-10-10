using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CreationGridManager : MonoBehaviour
{
    // ������ �� ������ ARPlane
    public GameObject arPlanePrefab;

    // ����� �������� ��� ARPlane
    public Material newMaterial;

    // ������ �� ����� ARPlane
    private GameObject newARPlane;

    void Start()
    {
        // ������� ����� ARPlane � ��� �� �������, ��� � ������������ ARPlane
        newARPlane = Instantiate(arPlanePrefab, arPlanePrefab.transform.position, Quaternion.identity);

        // �������� ��������� MeshRenderer ������ ARPlane
        MeshRenderer meshRenderer = newARPlane.GetComponent<MeshRenderer>();

        // ������������� ����� �������� ��� ������ ARPlane
        meshRenderer.material = newMaterial;

        // ������������� �� ������� OnBoundaryChanged ��� ������������� ARPlane
        arPlanePrefab.GetComponent<ARPlane>().boundaryChanged += OnBoundaryChangedHandler;
    }

    void OnBoundaryChangedHandler(ARPlaneBoundaryChangedEventArgs eventArgs)
    {
        // ��������� MeshFilter.mesh ������ ARPlane � ������� MeshFilter.mesh ������������� ARPlane
        newARPlane.GetComponent<MeshFilter>().mesh = arPlanePrefab.GetComponent<MeshFilter>().mesh;
    }
}
