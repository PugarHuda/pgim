using UnityEngine;
using UnityEngine.SceneManagement;


    public class TriggerSceneChanger : MonoBehaviour
{
    public string targetSceneName = "GameScene"; // Nama scene tujuan


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Pastikan objek memiliki tag "Player"
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}


