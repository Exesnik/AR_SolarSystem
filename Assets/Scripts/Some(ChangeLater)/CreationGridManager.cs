using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CreationGridManager : MonoBehaviour
{
    // Ссылка на префаб ARPlane
    public GameObject arPlanePrefab;

    // Новый материал для ARPlane
    public Material newMaterial;

    // Ссылка на новый ARPlane
    private GameObject newARPlane;

    void Start()
    {
        // Получаем компонент ARPlaneManager
        ARPlaneManager arPlaneManager = FindObjectOfType<ARPlaneManager>();

        // Проверяем, есть ли ARPlaneManager в сцене
        if (arPlaneManager == null)
        {
            Debug.LogError("ARPlaneManager не найден в сцене!");
            return;
        }

        // Подписываемся на событие OnPlaneAdded для ARPlaneManager
        arPlaneManager.planesChanged += OnPlanesChangedHandler;
    }

    void OnPlanesChangedHandler(ARPlanesChangedEventArgs eventArgs)
    {
        ARPlane arPlane = null;

        // Получаем первый добавленный ARPlane
        if (eventArgs.added.Count > 0)
        {
            arPlane = eventArgs.added[0];
        }

        // Проверяем, что ARPlane не равен null
        if (arPlane == null)
        {
            return;
        }

        // Создаем новый ARPlane в той же позиции, что и добавленный ARPlane, но с y-координатой, увеличенной на 1 метр
        Vector3 newPosition = arPlane.transform.position + new Vector3(0f, 1f, 0f);
        newARPlane = Instantiate(arPlanePrefab, newPosition, Quaternion.identity);

        // Получаем компонент MeshRenderer нового ARPlane
        MeshRenderer meshRenderer = newARPlane.GetComponent<MeshRenderer>();

        // Устанавливаем новый материал для нового ARPlane
        meshRenderer.material = newMaterial;

        // Подписываемся на событие OnBoundaryChanged для добавленного ARPlane
        arPlane.boundaryChanged += OnBoundaryChangedHandler;
    }

    void OnBoundaryChangedHandler(ARPlaneBoundaryChangedEventArgs eventArgs)
    {
        // Обновляем MeshFilter.mesh нового ARPlane с помощью MeshFilter.mesh добавленного ARPlane
        newARPlane.GetComponent<MeshFilter>().mesh = eventArgs.plane.GetComponent<MeshFilter>().mesh;
    }
}
