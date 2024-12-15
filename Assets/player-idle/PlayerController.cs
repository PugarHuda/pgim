using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.5f;    // Kecepatan gerakan
    public float jumpForce = 1f;   // Kekuatan lompat

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Ambil Rigidbody2D
    }

    void Update()
    {
        // Input horizontal untuk gerakan kanan/kiri
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Logika membalik karakter sesuai arah gerakan
        if (moveInput > 0) // Jika bergerak ke kanan
        {
            transform.localScale = new Vector3(1, 1, 1); // Menghadap kanan
        }
        else if (moveInput < 0) // Jika bergerak ke kiri
        {
            transform.localScale = new Vector3(-1, 1, 1); // Menghadap kiri
        }

        // Lompat jika tombol spasi ditekan dan karakter di tanah
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah karakter menyentuh tanah
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Jika karakter tidak lagi menyentuh tanah
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
