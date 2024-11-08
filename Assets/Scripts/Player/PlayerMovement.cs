using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Field untuk pengaturan pergerakan.
    [SerializeField] private Vector2 maxSpeed;              // Kecepatan maksimum.
    [SerializeField] private Vector2 timeToFullSpeed;       // Waktu untuk mencapai kecepatan penuh.
    [SerializeField] private Vector2 timeToStop;            // Waktu untuk berhenti.
    [SerializeField] private Vector2 stopClamp;             // Batas kecepatan minimum sebelum berhenti.
    [SerializeField] private Vector2 moveFriction;          // Gaya gesek saat bergerak.
    [SerializeField] private Vector2 stopFriction;          // Gaya gesek saat berhenti.

    // Variabel untuk perhitungan pergerakan.
    private Vector2 moveDirection;                          // Arah gerakan.
    private Vector2 moveVelocity;                           // Kecepatan yang diterapkan ke Player.
    private Rigidbody2D rb;                                 // Referensi ke Rigidbody2D.

    void Start()
    {
        // Mengambil Rigidbody2D yang terpasang pada objek.
        rb = GetComponent<Rigidbody2D>();
    }

    // Method untuk menangani pergerakan Player.
    public void Move()
    {
        // Mengambil input dari pemain.
        float horizontalInput = Input.GetAxis("Horizontal");  // A/D atau Left/Right Arrow.
        float verticalInput = Input.GetAxis("Vertical");      // W/S atau Up/Down Arrow.

        // Menentukan arah pergerakan berdasarkan input.
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Menghitung kecepatan pergerakan berdasarkan input dan waktu untuk mencapai kecepatan penuh.
        if (moveDirection.magnitude > 0) // Jika ada input pergerakan.
        {
            moveVelocity = Vector2.Lerp(moveVelocity, maxSpeed, Time.deltaTime / timeToFullSpeed.x);
        }
        else // Jika tidak ada input.
        {
            moveVelocity = Vector2.Lerp(moveVelocity, Vector2.zero, Time.deltaTime / timeToStop.x);
        }

        // Menambahkan gesekan berdasarkan kecepatan.
        moveVelocity -= GetFriction() * Time.deltaTime;

        // Membatasi kecepatan agar tidak melebihi maxSpeed.
        moveVelocity = Vector2.ClampMagnitude(moveVelocity, maxSpeed.magnitude);

        // Menggunakan Rigidbody2D untuk menggerakkan Player.
        rb.velocity = new Vector2(moveVelocity.x, moveVelocity.y);

        // Jika kecepatan turun di bawah stopClamp, berhenti bergerak.
        if (moveVelocity.magnitude < stopClamp.magnitude)
        {
            moveVelocity = Vector2.zero; // Player berhenti.
        }
    }

    // Method untuk mengembalikan gaya gesek.
    public Vector2 GetFriction()
    {
        // Mengembalikan gesekan berdasarkan apakah Player bergerak atau tidak.
        return (moveVelocity.magnitude > 0) ? moveFriction : stopFriction;
    }

    // Method untuk memeriksa apakah Player sedang bergerak.
    public bool IsMoving()
    {
        // Mengembalikan true jika Player bergerak, false jika tidak.
        return moveVelocity.magnitude > 0;
    }

    // Method untuk membatasi pergerakan, saat ini kosong.
    public void MoveBound()
    {
        // Method kosong untuk sementara.
    }
}
