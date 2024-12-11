using System.Collections;
using UnityEngine;
using TMPro; // Pastikan menggunakan TextMeshPro

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text targetText; // Komponen TMP_Text untuk menampilkan teks
    public float typingSpeed = 0.05f; // Kecepatan mengetik (dalam detik)

    private string fullText; // Menyimpan teks lengkap
    private string currentText = ""; // Menyimpan teks yang sudah ditampilkan

    void Start()
    {
        if (targetText != null)
        {
            fullText = targetText.text; // Simpan teks lengkap
            targetText.text = ""; // Kosongkan teks awal
            StartCoroutine(TypeText()); // Mulai efek mengetik
        }
    }

    IEnumerator TypeText()
    {
        foreach (char c in fullText)
        {
            currentText += c; // Tambahkan karakter satu per satu
            targetText.text = currentText; // Perbarui teks yang terlihat
            yield return new WaitForSeconds(typingSpeed); // Tunggu sesuai kecepatan mengetik
        }
    }
}
