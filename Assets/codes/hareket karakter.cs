
using UnityEngine;

public class hareketkarakter : MonoBehaviour
{
    //değişken atama
    [SerializeField] private float WalkSpeed= 5f;
    [SerializeField] private float RunSpeed= 10f;
    [SerializeField] private float JumpHeight= 10f;
    [SerializeField] private float turnSpeed = 100f;
    private float currentSpeed;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    
    void Update()
    {
        //fonksiyon çağırma 
        Hareket();
        SpeedControl();
        fixedPosition();
    }
     

    void SpeedControl() 
    {
       currentSpeed = WalkSpeed;
       if (Input.GetKey(KeyCode.LeftShift))
       {
        currentSpeed=RunSpeed;
       }
    }

    void fixedPosition()
    {
    if (Input.GetKeyDown(KeyCode.F))
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
    }

    void Hareket()
    {
    if (Input.GetKey(KeyCode.W))
    {
    transform.position -= transform.forward * currentSpeed * Time.deltaTime;
    }

    if (Input.GetKey(KeyCode.S))
    {
    transform.position += transform.forward * currentSpeed * Time.deltaTime;
    }

    if (Input.GetKey(KeyCode.D))
    {
    transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }

    if (Input.GetKey(KeyCode.A))
    {
    transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime);
    }

    if (Input.GetKey(KeyCode.Space))
    { 
    transform.position += Vector3.up * JumpHeight * Time.deltaTime;
    }
    }
}
