using UnityEngine;

public class hareketkarakter : MonoBehaviour
{
    [SerializeField] private float WalkSpeed= 15f;
    [SerializeField] private float RunSpeed= 50f;
    [SerializeField] private float JumpHeight= 20f;
    private float CurrentSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hareket();
        SpeedControl();
    }
    void SpeedControl()
    {
       CurrentSpeed = WalkSpeed;
       if (Input.GetKey(KeyCode.LeftShift))
       {
        CurrentSpeed=RunSpeed;
       }
    }
    
    void Hareket()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward*CurrentSpeed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position +=Vector3.back*CurrentSpeed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position +=Vector3.left*CurrentSpeed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position +=Vector3.right*CurrentSpeed*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up*CurrentSpeed*Time.deltaTime;
        }
    }
}
