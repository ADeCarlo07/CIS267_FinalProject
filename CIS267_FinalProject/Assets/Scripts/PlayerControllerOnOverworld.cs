using UnityEngine;

public class PlayerControllerOnOverworld : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Vector2 movement;
    public float moveSpeed;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //fixes diagonal movement from being faster
        movement = movement.normalized;
    }

    private void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            playerRB.MovePosition(playerRB.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
