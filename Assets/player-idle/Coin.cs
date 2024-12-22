using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip collectSound; // File suara untuk efek koleksi
    private AudioSource audioSource;

    void Start()
    {
        // Ambil komponen AudioSource
        audioSource = GetComponent<AudioSource>();

         // Pastikan volume diatur ke 1 (maksimal)
        audioSource.volume = 1f;
    }

    public void Collect()
{
    Debug.Log("Coin collected!");

    if (collectSound != null && audioSource != null)
    {
        Debug.Log("Playing sound");
        audioSource.PlayOneShot(collectSound); // Mainkan suara
    }
    else
    {
        Debug.Log("Audio or collectSound is null");
    }

    Destroy(gameObject, collectSound.length); // Hapus koin setelah suara selesai
}
}
