using UnityEngine;

public class ConveyorBelt3D : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private Vector3 direction = Vector3.right; // İleri yön

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Bandın kendisi fizik kurallarıyla uçmasın
        }
    }

    // Bant üzerindeki nesnelerle temas halindeyken çalışır
    void OnCollisionStay(Collision collision)
    {
        // Temas eden objenin Rigidbody'si var mı diye bakıyoruz
        Rigidbody colRb = collision.collider.GetComponent<Rigidbody>();
        if (colRb != null)
        {
            // Bandın hareket yönünü dünya koordinatına çeviriyoruz
            Vector3 moveDirection = transform.TransformDirection(direction.normalized);
            
            // Objeyi bant hızında hareket ettiriyoruz
            colRb.MovePosition(colRb.position + moveDirection * speed * Time.fixedDeltaTime);
        }
    }
}