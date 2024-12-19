using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objek yang akan diikuti (karakter)
    public Vector3 offset; // Jarak kamera terhadap karakter
    public float smoothSpeed = 0.125f; // Kecepatan kamera mengikuti karakter

    void LateUpdate()
    {
        if (target != null)
        {
            // Posisi yang diinginkan kamera
            Vector3 desiredPosition = target.position + offset;
            // Smooth transition ke posisi baru
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
