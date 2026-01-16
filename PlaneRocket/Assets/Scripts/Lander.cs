using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.InputSystem;


public class Lander : MonoBehaviour
{
   

    private Rigidbody2D landerRigidbody2D;




    public void Awake()    // hàm này sẽ chạy 1 lần duy nhất khi đối tượng được khởi tạo chạy trước hàm Start()
    {
        landerRigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

   

    private void FixedUpdate()    // Sẽ chạy ổn định với chuyển động vật lí mặc định 50 lần/giây mọi máy tính
    {
         
        float thrustForce = 700f;
        float rotationSpeed = 100f;

        // Bay lên bằng phím W
        if (Keyboard.current.wKey.isPressed)
        {
            landerRigidbody2D.AddForce(transform.up * thrustForce * Time.deltaTime);
        }


        // Xoay sang Trái bằng phím A
        if (Keyboard.current.aKey.isPressed)
        {
            landerRigidbody2D.AddTorque(rotationSpeed * Time.deltaTime);
            Debug.Log("Nhấn A - Xoay Trái");
        }

        // Xoay sang Phải bằng phím D
        if (Keyboard.current.dKey.isPressed)
        {
            landerRigidbody2D.AddTorque(-rotationSpeed * Time.deltaTime);
            Debug.Log("Nhấn D - Xoay Phải");
        }

        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        

        Debug.Log("other.relativeVelocity.magnitude");

    }



    void Update()
    {
       
    }
}
