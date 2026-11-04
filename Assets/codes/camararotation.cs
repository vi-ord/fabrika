using UnityEngine;

public class camararotation : MonoBehaviour
{
    public Transform target; // Takip edilecek karakter (Player)
    public float distance = 5.0f; // Karaktere olan başlangıç mesafesi
    public float xSpeed = 120.0f; // Yatay dönme hızı
    public float ySpeed = 120.0f; // Dikey dönme hızı
    
    public float yMinLimit = -20f; // Kameranın çok fazla yere girmemesi için alt sınır
    public float yMaxLimit = 80f;  // Kameranın çok fazla tepeye çıkmaması için üst sınır

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void LateUpdate()
    {
        if (!target) return;

        // SADECE FARESİNİN SAĞ TUŞUNA BASILI TUTULDUĞUNDA DÖNDÜR
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
        }

        // Kameranın dikey açısını sınırlar (takla atmasını önler)
        y = ClampAngle(y, yMinLimit, yMaxLimit);

        // Kameranın yeni pozisyonunu ve rotasyonunu hesapla
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        
        // Karakterin merkezine 1.5 birim yukarıdan bakar (gövde/kafa hizası)
        Vector3 trueTargetPosition = target.position + Vector3.up * 1.5f;
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + trueTargetPosition;

        transform.rotation = rotation;
        transform.position = position;
    }

    // Açı sınırlandırma yardımcı fonksiyonu
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
