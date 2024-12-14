using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Kecepatan bergerak ke kanan/kiri
    public float jumpForce = 10f; // Kekuatan lompatan

    [Header("Ground Check")]
    public Transform groundCheck; // Objek GroundCheck (di bawah karakter)
    public float groundCheckRadius = 0.1f; // Radius deteksi tanah
    public LayerMask groundLayer; // Layer untuk tanah

    private Rigidbody2D rb; // Komponen Rigidbody2D karakter
    private bool isGrounded; // Status apakah karakter di tanah

    void Start()
    {
        // Ambil komponen Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input gerakan horizontal (kanan/kiri)
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Menggerakkan karakter

        // Membalik arah sprite karakter sesuai arah gerakan
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1); // Menghadap kanan
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Menghadap kiri

        // Deteksi apakah karakter berada di tanah
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log("Is Grounded: " + isGrounded); // Debug log untuk mengetahui status grounded

        // Lompat jika tombol lompat ditekan dan karakter di tanah
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Menambahkan kecepatan vertikal untuk lompat
        }
    }

    // Visualisasi GroundCheck di Editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
