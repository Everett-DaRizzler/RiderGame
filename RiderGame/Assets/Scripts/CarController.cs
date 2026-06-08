using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    bool move = false;
    bool isGrounded = false;
    Vector2 groundNormal = Vector2.up;

    public Rigidbody2D rb;

    public float speed = 20f;
    public float rotationSpeed = 2f;
    public float upsideDownThreshold = -0.5f;

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
        if (isGrounded == true && Vector2.Dot(transform.up, groundNormal) < upsideDownThreshold)
        {
            RestartCurrentScene();
        }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UpdateGroundedState(collision);
        isGrounded = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        UpdateGroundedState(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        isGrounded = false;
        
    }

    private void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateGroundedState(Collision2D collision)
    {
        Vector2 normalTotal = Vector2.zero;

        for (int i = 0; i < collision.contactCount; i++)
        {
            normalTotal += collision.GetContact(i).normal;
        }

        groundNormal = normalTotal.normalized;
    }

    
}
