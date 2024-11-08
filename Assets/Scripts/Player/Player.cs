using UnityEngine;

public class Player : MonoBehaviour
{
    // Player Singleton.
    public static Player Instance;

    // Reference untuk PlayerMovement dan Animator.
    public PlayerMovement playerMovement;
    private Animator animator;

    // Fungsi Awake untuk inisialisasi Singleton.
    void Awake()
    {
        // Menjaga hanya satu instance Player..
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Mengambil komponen PlayerMovement dan Animator.
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Memanggil Move pada PlayerMovement untuk bergerak.
        playerMovement.Move();
    }

    void LateUpdate()
    {
        // Mengatur parameter IsMoving pada Animator sesuai status pergerakan Player.
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}
