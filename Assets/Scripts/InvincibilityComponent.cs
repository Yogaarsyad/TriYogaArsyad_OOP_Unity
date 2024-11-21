using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 7;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Material blinkMaterial;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;

    public bool isInvincible = false;

    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void TriggerInvincibility()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(blinkInterval / 2);
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(blinkInterval / 2);
        }

        spriteRenderer.material = originalMaterial;

        isInvincible = false;
    }
}
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 7; // Jumlah kedipan saat invincibility aktif.
    [SerializeField] private float blinkInterval = 0.1f; // Interval waktu kedipan.
    [SerializeField] private Material blinkMaterial; // Material yang digunakan saat objek berkedip.

    private SpriteRenderer spriteRenderer; // Referensi ke komponen SpriteRenderer.
    private Material originalMaterial; // Menyimpan material asli dari sprite.

    public bool isInvincible = false; // Menyimpan status apakah objek sedang dalam kondisi invincible.

    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Mengambil komponen SpriteRenderer pada objek.
        originalMaterial = spriteRenderer.material; // Menyimpan material asli objek.
    }

    public void TriggerInvincibility()
    {
        if (!isInvincible) // Memastikan invincibility hanya dimulai jika objek belum invincible.
        {
            StartCoroutine(InvincibilityCoroutine()); // Memulai coroutine invincibility.
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true; // Menandakan objek dalam kondisi invincible.

        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial; // Mengganti material sprite menjadi material kedipan.
            yield return new WaitForSeconds(blinkInterval / 2); // Menunggu setengah interval waktu kedipan.
            spriteRenderer.material = originalMaterial; // Mengembalikan material asli sprite.
            yield return new WaitForSeconds(blinkInterval / 2); // Menunggu setengah interval waktu kedipan lagi.
        }

        spriteRenderer.material = originalMaterial; // Mengembalikan material asli setelah kedipan selesai.

        isInvincible = false; // Menandakan objek tidak lagi invincible.
    }
}
