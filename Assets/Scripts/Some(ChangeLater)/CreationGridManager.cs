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
        // Создаем новый ARPlane в той же позиции, что и существующий ARPlane
        newARPlane = Instantiate(arPlanePrefab, arPlanePrefab.transform.position, Quaternion.identity);

        // Получаем компонент MeshRenderer нового ARPlane
        MeshRenderer meshRenderer = newARPlane.GetComponent<MeshRenderer>();

        // Устанавливаем новый материал для нового ARPlane
        meshRenderer.material = newMaterial;

        // Подписываемся на событие OnBoundaryChanged для существующего ARPlane
        arPlanePrefab.GetComponent<ARPlane>().boundaryChanged += OnBoundaryChangedHandler;
    }

    void OnBoundaryChangedHandler(ARPlaneBoundaryChangedEventArgs eventArgs)
    {
        // Обновляем MeshFilter.mesh нового ARPlane с помощью MeshFilter.mesh существующего ARPlane
        newARPlane.GetComponent<MeshFilter>().mesh = arPlanePrefab.GetComponent<MeshFilter>().mesh;
    }
}
