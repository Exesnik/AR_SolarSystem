using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // Загрузка сцены по имени
    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadSceneMapSS()
    {
        SceneManager.LoadScene("MainSolarSystem");
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
}