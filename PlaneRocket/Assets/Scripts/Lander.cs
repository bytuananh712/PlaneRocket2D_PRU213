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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "LandingPad")
        {

        }


        float softLandingVelocityMagnitude = 4f; // Ngưỡng vận tốc để xác định hạ cánh êm ái hay mạnh
        float relativeVelocityMagnitude = other.relativeVelocity.magnitude;  // Lấy vận tốc tương đối khi va chạm giữa hai vật thể
        if (relativeVelocityMagnitude > softLandingVelocityMagnitude)  // Đo vận tốc tương đối khi va chạm để kiểm tra độ mạnh yếu của cú hạ cánh
        {
            Debug.Log("Hạ cánh quá mạnh! BÙM!");
        }



        float dotLevel = Vector2.Dot(Vector2.up, transform.up);  // Tính toán mức độ thẳng đứng của tàu so với phương thẳng đứng (Vector2.up)

        if (dotLevel > 0.98f)
        {
            Debug.Log("Hạ cánh thẳng tắp! Tuyệt vời.");
        }
        else if (dotLevel > 0.90f)
        {
            Debug.Log("Hơi nghiêng nhưng vẫn ổn.");
        }
        else
        {
            Debug.Log("Hạ cánh bằng sườn rồi! BÙM!");
        }



        // Tính Điểm hạ cánh có tốt không có bị lệch không hehe

        float maxScoreAmountLandingAngle = 100;
        float scoreDotVectorMultiplier = 10f;
        float ladingAngleScore = maxScoreAmountLandingAngle - Mathf.Abs(dotLevel - 1f) * scoreDotVectorMultiplier * maxScoreAmountLandingAngle; // Kiểm tra độ lệch nhiều hay ít so với thẳng đứng 

        //Abs(0.95 - 1) = 0.05
        //0.05 × 10 × 100 = 50
        //Điểm cuối = 100 - 50 = 50 

        // Tính điểm tốc độ hạ cánh 
        float maxScoreAmountLandingSpeed = 100;
        float landingSpeedScore =   (softLandingVelocityMagnitude - relativeVelocityMagnitude) * maxScoreAmountLandingAngle ;

        Debug.Log("Điểm hạ cánh theo góc: " + ladingAngleScore + " | Điểm hạ cánh theo tốc độ: " + landingSpeedScore);




    }



    void Update()
    {
       
    }
}
