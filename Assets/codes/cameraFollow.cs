using UnityEngine;

public class cameraFollow : MonoBehaviour
{
  public Transform target; // Takip edilecek karakter (Player)
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Kameranın karakterin arkasındaki mesafesi
    public float smoothSpeed = 0.125f; // Takip etme yumuşaklığı

    void LateUpdate()
    {
        if (target == null) return;

        // Hedef pozisyonu hesapla
        Vector3 desiredPosition = target.position + offset;
        
        // Kameranın mevcut pozisyonundan hedef pozisyona yumuşak bir şekilde geçiş yap
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    
}
