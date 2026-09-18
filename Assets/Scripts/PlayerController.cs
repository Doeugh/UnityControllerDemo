using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 position;

    void Start()
    {
        position = new Vector2(transform.position.x,transform.position.z);
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(x, y);

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        Vector2 deltaPosition = movement * moveSpeed * Time.deltaTime;

        position.x += deltaPosition.x;
        position.y += deltaPosition.y;

        transform.position = new Vector3(position.x,transform.position.y,position.y
        );
    }
}
