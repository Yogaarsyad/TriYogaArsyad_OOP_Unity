using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Fields
    [SerializeField] private Vector2 maxSpeed = new Vector2(5f, 5f); // Kecepatan maksimum yang dapat dicapai Player
    [SerializeField] private Vector2 timeToFullSpeed = new Vector2(1f, 1f); // Waktu untuk mencapai kecepatan maksimum
    [SerializeField] private Vector2 timeToStop = new Vector2(1f, 1f); // Waktu untuk berhenti
    [SerializeField] private Vector2 stopClamp = new Vector2(0.1f, 0.1f); // Batas kecepatan minimum sebelum Player berhenti

    private Vector2 moveDirection; // Arah gerakan Player
    private Vector2 moveVelocity; // Gaya pergerakan yang diterapkan
    private Vector2 moveFriction; // Gaya gesek saat Player bergerak
    private Vector2 stopFriction; // Gaya gesek saat Player berhenti
    private Rigidbody2D rb; // Referensi ke komponen Rigidbody2D

    // Methods
    void Start()
    {
        // Mengambil komponen Rigidbody2D dari GameObject ini
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) // Memastikan Rigidbody2D tersedia
        {
            Debug.LogError("Rigidbody2D component not found!"); // Log error jika tidak ditemukan
            return; // Keluar dari method jika tidak ada Rigidbody2D
        }

        // Menghitung nilai awal untuk moveVelocity, moveFriction, dan stopFriction
        moveVelocity = 2 * (maxSpeed / timeToFullSpeed); // Gaya gerakan berdasarkan kecepatan maksimum dan waktu
        moveFriction = -2 * (maxSpeed / (timeToFullSpeed * timeToFullSpeed)); // Gaya gesek saat bergerak
        stopFriction = -2 * (maxSpeed / (timeToStop * timeToStop)); // Gaya gesek saat berhenti

        // Debug logs untuk memeriksa nilai awal
        Debug.Log("Move Velocity: " + moveVelocity);
        Debug.Log("Move Friction: " + moveFriction);
        Debug.Log("Stop Friction: " + stopFriction);
    }

    public void Move()
    {
        // Mengambil input dari pengguna untuk gerakan horizontal dan vertikal
        moveDirection.x = Input.GetAxis("Horizontal"); // Input horizontal (A/D atau Arrow Keys)
        moveDirection.y = Input.GetAxis("Vertical"); // Input vertikal (W/S atau Arrow Keys)

        moveDirection.Normalize(); // Normalisasi vektor arah untuk menjaga konsistensi

        // Jika ada input gerakan
        if (moveDirection.magnitude > 0)
        {
            // Mengatur kecepatan berdasarkan input dan gaya pergerakan
            rb.velocity = new Vector2(
                Mathf.Clamp(rb.velocity.x + moveVelocity.x * moveDirection.x, -maxSpeed.x, maxSpeed.x),
                Mathf.Clamp(rb.velocity.y + moveVelocity.y * moveDirection.y, -maxSpeed.y, maxSpeed.y)
            );
        }
        else // Jika tidak ada input
        {
            rb.velocity += GetFriction(); // Terapkan gaya gesek untuk berhenti
        }

        // Debug log untuk memeriksa kecepatan saat ini
        Debug.Log("Current Velocity: " + rb.velocity);
    }

    public Vector2 GetFriction()
    {
        // Mengembalikan gaya gesek
        if (rb.velocity.magnitude < stopClamp.magnitude) // Jika kecepatan kurang dari batas minimum
        {
            return Vector2.zero; // Tidak ada gaya gesek
        }
        return new Vector2(moveFriction.x, moveFriction.y); // Kembali gaya gesek
    }

    public void MoveBound()
    {
        // Kosongkan dulu
    }

    public bool IsMoving()
    {
        // Kembalikan true jika Player bergerak, false jika tidak
        return rb.velocity.magnitude > 0;
    }
}