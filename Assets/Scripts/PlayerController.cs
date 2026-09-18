using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed = 5f;

    private Vector2 position;
    private Vector2 velocity;

    void Start()
    {
        position = new Vector2(transform.position.x,transform.position.z);

        velocity = Vector2.zero;
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

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        Vector2 movement = velocity * Time.deltaTime;

        position += movement;

        transform.position = new Vector3(position.x,transform.position.y,position.y);
    }
}
