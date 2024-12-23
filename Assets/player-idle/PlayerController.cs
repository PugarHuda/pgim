using UnityEngine;

public class coin : MonoBehaviour
{
    public void Collect()
    {
        Debug.Log("Coin collected!");
        Destroy(gameObject); // Hapus objek setelah dikoleksi
    }
}

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;     // Kecepatan gerakan
    public float jumpForce = 1f;     // Kekuatan lompat
    public float gravityScale = 2f;  // Pengaturan gravitasi (sesuaikan jika perlu)

    private Rigidbody2D rb;
    private bool isGrounded;

    // Ground check variables (Opsional)
    public Transform groundCheck;
    public float checkRadius = 0.2f; // Radius deteksi tanah
    public LayerMask whatIsGround;   // Layer yang dianggap tanah

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Ambil Rigidbody2D
        rb.gravityScale = gravityScale;   // Atur gravitasi
    }

    void Update()
    {
        // Input horizontal untuk gerakan kanan/kiri
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Update kecepatan horizontal

        // Logika membalik karakter sesuai arah gerakan
        if (moveInput > 0) // Jika bergerak ke kanan
        {
            transform.localScale = new Vector3(1, 1, 1); // Menghadap kanan
        }
        else if (moveInput < 0) // Jika bergerak ke kiri
        {
            transform.localScale = new Vector3(-1, 1, 1); // Menghadap kiri
        }

        // Cek apakah karakter berada di tanah
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        }

        // Lompat jika tombol spasi ditekan dan karakter di tanah
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Lompat dengan kekuatan yang ditentukan
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah karakter menyentuh tanah (Backup jika tanpa groundCheck)
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

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("coin"))
        {
            collision.GetComponent<Coin>().Collect();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Gambar radius deteksi tanah di editor (Opsional)
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}
