using UnityEngine;

public class CarController : MonoBehaviour
{
    bool move = false;
    bool isGrounded = false;

    public Rigidbody2D rb;

    public float speed = 20f;
    public float rotationSpeed = 2f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            move = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            move = false;
        }
    }
    void FixedUpdate()
    {
        if (move == true)
        {
            if (isGrounded == true)
            {
                rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }else
            {
                rb.AddTorque(rotationSpeed * rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
        }
    }

    private void OnCollisionEnter2D()
    {
        
        isGrounded = true;
        
    }

    private void OnCollisionExit2D()
    {
        
        isGrounded = false;
        
    }

    
}
