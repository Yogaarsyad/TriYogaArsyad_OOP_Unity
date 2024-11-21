using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkTimes = 7;  // Jumlah kedipan saat invincibility aktif.
    [SerializeField] private float blinkDuration = 0.1f;  // Durasi interval kedipan.
    [SerializeField] private Material invincibilityMaterial;  // Material untuk kedipan saat invincibility.

    private SpriteRenderer spriteRenderer;  // Referensi ke komponen SpriteRenderer.
    private Material defaultMaterial;  // Menyimpan material asli objek.

    private bool isInvincible = false;  // Menyimpan status apakah objek sedang invincible.

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Mengambil komponen SpriteRenderer pada objek.
        defaultMaterial = spriteRenderer.material;  // Menyimpan material asli objek.
    }

    public void ActivateInvincibility()
    {
        if (!isInvincible)  // Pastikan invincibility dimulai hanya jika objek belum invincible.
        {
            StartCoroutine(HandleInvincibility());  // Memulai coroutine untuk menangani invincibility.
        }
    }

    private IEnumerator HandleInvincibility()
    {
        isInvincible = true;  // Menandakan objek dalam kondisi invincible.

        for (int i = 0; i < blinkTimes; i++)
        {
            ToggleBlinkMaterial(true);  // Ganti material untuk menunjukkan kedipan.
            yield return new WaitForSeconds(blinkDuration / 2);  // Tunggu selama setengah durasi kedipan.
            ToggleBlinkMaterial(false);  // Kembalikan material asli.
            yield return new WaitForSeconds(blinkDuration / 2);  // Tunggu lagi untuk setengah durasi kedipan.
        }

        ResetMaterial();  // Kembalikan material objek ke keadaan semula setelah kedipan selesai.
        isInvincible = false;  // Menandakan objek tidak lagi invincible.
    }

    private void ToggleBlinkMaterial(bool isBlinking)
    {
        spriteRenderer.material = isBlinking ? invincibilityMaterial : defaultMaterial;  // Tentukan material yang digunakan.
    }

    private void ResetMaterial()
    {
        spriteRenderer.material = defaultMaterial;  // Kembalikan material objek ke material asli.
    }
}
