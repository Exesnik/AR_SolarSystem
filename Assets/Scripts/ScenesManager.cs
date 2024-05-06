using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // �������� ����� �� �����
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

    // ����� �� ����������
    public void QuitApplication()
    {
        Application.Quit();
    }
}