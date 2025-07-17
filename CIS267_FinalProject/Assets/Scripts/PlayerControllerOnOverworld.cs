using UnityEngine;

public class PlayerControllerOnOverworld : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Vector2 movement;
    public float moveSpeed;
    private Animator animator;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //fixes diagonal movement from being faster
        movement = movement.normalized;

        if (movement != Vector2.zero)
        {

            animator.SetFloat("XInput", movement.x);
            animator.SetFloat("YInput", movement.y);
        }
        
        animator.SetBool("isWalking", movement != Vector2.zero);
    }

    private void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            playerRB.MovePosition(playerRB.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
