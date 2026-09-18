using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed = 5f;
    public float friction = 5f;

    public float gravity = 9.81f;
    public float floorHeight = 0.5f;

    public float jumpForce = 5f;
    private bool isGrounded;

    private Vector2 position;
    private Vector2 velocity;

    private float verticalVelocity;

    void Start()
    {
        position = new Vector2(transform.position.x,transform.position.z);

        velocity = Vector2.zero;
        verticalVelocity = 0f;

        isGrounded = true;
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(x, y);

        if (input.magnitude > 1f)
        {
            input.Normalize();
        }

        Vector2 accelerationVector = input * acceleration;

        velocity += accelerationVector * Time.deltaTime;

        if (input == Vector2.zero) 
        { 
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, friction * Time.deltaTime); 
        }

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        Vector2 movement = velocity * Time.deltaTime;

        position += movement;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            verticalVelocity = jumpForce;
            isGrounded = false;
        }

        verticalVelocity -= gravity * Time.deltaTime;

        float newY = transform.position.y + verticalVelocity * Time.deltaTime;

        if (newY < floorHeight)
        {
            newY = floorHeight;
            verticalVelocity = 0f;
            isGrounded = true;
        }

        transform.position = new Vector3(position.x,newY,position.y);
    }
}
