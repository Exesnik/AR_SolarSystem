using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] private GameObject disclamerManager;
    private DisclamerManager script;
    private void Start()
    {
       script = disclamerManager.GetComponent <DisclamerManager>();
    }

    // Загрузка сцены по имени
    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadSceneMapSS()
    {
        script.ManagerToCoroutinMaps();
        StartCoroutine(WaitingForLoad());
    }

    public void LoadSceneCreationSS()
    {
        SceneManager.LoadScene("SSCreationScene");
    }

    // Выход из приложения
    public void QuitApplication()
    {
        Application.Quit();
    }

    private IEnumerator WaitingForLoad()
    { 
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainSolarSystem");
    }
}