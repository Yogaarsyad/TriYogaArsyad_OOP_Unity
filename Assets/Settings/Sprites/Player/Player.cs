using UnityEngine;

public class Player : MonoBehaviour
{
    // Fields.
    private PlayerMovement playerMovement; // Referensi ke script PlayerMovement
    private Animator animator; // Referensi ke komponen Animator.
    private SpriteRenderer spriteRenderer; // Tambahkan SpriteRenderer untuk mengatur tampilan sprite

    // Singleton instance
    public static Player Instance { get; private set; } // Instance dari Player untuk mengimplementasikan Singleton

    // Methods
    void Awake()
    {
        // Singleton pattern
        if (Instance == null) // Jika belum ada instance
        {
            Instance = this; // Set instance saat ini
            DontDestroyOnLoad(gameObject); // Jangan hancurkan object ini saat loading scene baru
        }
        else // Jika sudah ada instance
        {
            Destroy(gameObject); // Hancurkan object ini untuk menjaga satu instance
        }
    }

    void Start()
    {
        // Mengambil komponen yang diperlukan
        playerMovement = GetComponent<PlayerMovement>(); // Ambil script PlayerMovement dari GameObject ini
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>(); // Ambil Animator dari GameObject EngineEffect
        spriteRenderer = GetComponent<SpriteRenderer>(); // Ambil SpriteRenderer dari GameObject ini


        // Debug log untuk memastikan komponen ditemukan
        Debug.Log(animator != null ? "Animator found!" : "Animator not found!"); // Log status Animator
        Debug.Log(spriteRenderer != null ? "SpriteRenderer found!" : "SpriteRenderer not found!"); // Log status SpriteRenderer
    }

    void FixedUpdate()
    {
        playerMovement.Move(); // Panggil method Move dari PlayerMovement untuk menggerakkan player
    }

    void LateUpdate()
    {
        // Mengatur status animasi berdasarkan apakah Player bergerak atau tidak
        animator.SetBool("IsMoving", playerMovement.IsMoving()); // Set parameter IsMoving di Animator
    }
}