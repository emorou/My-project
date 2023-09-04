using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Kecepatan pergerakan

    void Update()
    {
        // Mendapatkan input horizontal (kiri/kanan)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Mendapatkan input vertikal (atas/bawah)
        float verticalInput = Input.GetAxis("Vertical");

        // Menghitung pergerakan berdasarkan input
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

        // Menggerakkan objek
        transform.Translate(movement);

        // (Opsional) Pembatasan pergerakan di dalam layar
        float minX = -100f; // Batas kiri
        float maxX = 100f; // Batas kanan
        float minY = -100f; // Batas bawah
        float maxY = 100f; // Batas atas

        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );

        transform.position = clampedPosition;
    }
}
