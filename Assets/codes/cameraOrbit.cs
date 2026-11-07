using UnityEngine;
using UnityEngine.InputSystem;

public class KameraOrbit : MonoBehaviour
{
    [Header("Hedef Ayarları")]
    public Transform target; 
    public float distance = 5.0f;
    public float rotationSpeed = 200f; 

    private float currentX = 0f;
    private float currentY = 0f;
    
   
    public float minYAngle = -10f;
    public float maxYAngle = 70f;

    void LateUpdate()
    {
        if (target == null) return;

        if (Mouse.current != null && Mouse.current.rightButton.isPressed)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            
            currentX += mouseDelta.x * rotationSpeed * Time.deltaTime;
            currentY -= mouseDelta.y * rotationSpeed * Time.deltaTime; 

           
            currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
        }

       
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

       
        Vector3 position = target.position - (rotation * Vector3.forward * distance);

      
        transform.position = position;
        transform.rotation = rotation;
    }

}
