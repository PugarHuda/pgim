using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pindah : MonoBehaviour {
    AudioSource adsTombol, adsBacksound;
    AudioClip clTombol, clBacksound;
      public float introDuration = 5f; // Durasi intro dalam detik
    public string startScreenSceneName= "StartScreen"; // Nama scene start screen

    void Start() {
         Invoke("LoadStartScreen", introDuration);
        // Tambahkan AudioSource pada gameObject
        adsTombol = gameObject.AddComponent<AudioSource>();
        adsBacksound = gameObject.AddComponent<AudioSource>();

        // Load audio clip dari folder Resources
        clTombol = Resources.Load<AudioClip>("Sound/Suara Tombol");
        clBacksound = Resources.Load<AudioClip>("Sound/soundPlay1");

        // Konfigurasi AudioSource untuk backsound
        adsBacksound.loop = true;
        adsBacksound.clip = clBacksound;
        adsBacksound.Play();
    }

void LoadStartScreen() {
    SceneManager.LoadScene(startScreenSceneName);
}
    public void pindah(string tujuan) {
        // Mainkan suara tombol sebelum pindah scene
        if (clTombol != null) {
            adsTombol.PlayOneShot(clTombol);
        }

        // Pindah scene setelah suara tombol selesai (opsional, tergantung kebutuhan)
        StartCoroutine(PindahSceneSetelahSuara(tujuan));
        
    }

    private IEnumerator PindahSceneSetelahSuara(string tujuan) {
        // Tunggu hingga suara tombol selesai
        if (clTombol != null) {
            yield return new WaitForSeconds(clTombol.length);
        }

        // Pindah ke scene tujuan
        SceneManager.LoadScene(tujuan);
    }

     public void play(string level2) {
        // Mainkan suara tombol sebelum pindah scene
        if (clTombol != null) {
            adsTombol.PlayOneShot(clTombol);
        }

        // Pindah scene setelah suara tombol selesai (opsional, tergantung kebutuhan)
        StartCoroutine(PindahSceneSetelahSuaraa(level2));
    }

    private IEnumerator PindahSceneSetelahSuaraa(string level2) {
        // Tunggu hingga suara tombol selesai
        if (clTombol != null) {
            yield return new WaitForSeconds(clTombol.length);
        }

        // Pindah ke scene tujuan
        SceneManager.LoadScene(level2);
    }
}
