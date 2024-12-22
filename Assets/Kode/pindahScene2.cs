using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardSceneChanger : MonoBehaviour
{
    public string targetSceneName = "GameScene 1"; // Nama scene tujuan

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Jika tombol Space ditekan
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
