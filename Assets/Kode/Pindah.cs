using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pindah : MonoBehaviour {
    AudioSource adsTombol, adsBacksound;
    AudioClip clTombol, clBacksound;

    void Start() {
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
}
