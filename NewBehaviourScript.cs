using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Hareket hızı için ayarlanabilir bir değişken
    [SerializeField] private float moveSpeed;
    // Rigidbody bileşenine referans
    private Rigidbody playerRigidbody;

    // Seviye geçişleri için GameObject referansları
    public GameObject firstLevel;
    public GameObject secondLevel;

    // Oyunun başlangıcında Rigidbody bileşenini al
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Her karede çağrılan güncelleme metodu
    void Update()
    {
        // Yatay ve dikey girişleri al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Girişe dayalı bir yön vektörü oluştur ve normalize et
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        // Rigidbody'nin hızını yön ve hızla çarpılarak ayarla
        playerRigidbody.velocity = moveDirection * moveSpeed;

        // Eğer hareket yönü sıfır değilse, karakterin yönünü hareket yönüne çevir
        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }

    // Çarpışma olduğunda çağrılan metot
    private void OnCollisionEnter(Collision collision)
    {
        // Eğer çarpışılan nesnenin etiketi "Finish" ise
        if (collision.gameObject.CompareTag("Finish"))
        {
            // İkinci seviyeyi yükle
            SceneManager.LoadScene("secondLevel");
        }
    }
}
