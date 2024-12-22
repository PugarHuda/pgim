using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3; // Jumlah nyawa pemain

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Periksa apakah objek yang bersentuhan adalah musuh
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
        }
    }

    private void LoseLife()
    {
        health--; // Kurangi nyawa pemain
        Debug.Log("Nyawa tersisa: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Game Over!");
        // Tambahkan logika untuk mengakhiri permainan atau restart level
    }
}
