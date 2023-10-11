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
        // �������� ��������� ARPlaneManager
        ARPlaneManager arPlaneManager = FindObjectOfType<ARPlaneManager>();

        // ���������, ���� �� ARPlaneManager � �����
        if (arPlaneManager == null)
        {
            Debug.LogError("ARPlaneManager �� ������ � �����!");
            return;
        }

        // ������������� �� ������� OnPlaneAdded ��� ARPlaneManager
        arPlaneManager.planesChanged += OnPlanesChangedHandler;
    }

    void OnPlanesChangedHandler(ARPlanesChangedEventArgs eventArgs)
    {
        ARPlane arPlane = null;

        // �������� ������ ����������� ARPlane
        if (eventArgs.added.Count > 0)
        {
            arPlane = eventArgs.added[0];
        }

        // ���������, ��� ARPlane �� ����� null
        if (arPlane == null)
        {
            return;
        }

        // ������� ����� ARPlane � ��� �� �������, ��� � ����������� ARPlane, �� � y-�����������, ����������� �� 1 ����
        Vector3 newPosition = arPlane.transform.position + new Vector3(0f, 1f, 0f);
        newARPlane = Instantiate(arPlanePrefab, newPosition, Quaternion.identity);

        // �������� ��������� MeshRenderer ������ ARPlane
        MeshRenderer meshRenderer = newARPlane.GetComponent<MeshRenderer>();

        // ������������� ����� �������� ��� ������ ARPlane
        meshRenderer.material = newMaterial;

        // ������������� �� ������� OnBoundaryChanged ��� ������������ ARPlane
        arPlane.boundaryChanged += OnBoundaryChangedHandler;
    }

    void OnBoundaryChangedHandler(ARPlaneBoundaryChangedEventArgs eventArgs)
    {
        // ��������� MeshFilter.mesh ������ ARPlane � ������� MeshFilter.mesh ������������ ARPlane
        newARPlane.GetComponent<MeshFilter>().mesh = eventArgs.plane.GetComponent<MeshFilter>().mesh;
    }
}
