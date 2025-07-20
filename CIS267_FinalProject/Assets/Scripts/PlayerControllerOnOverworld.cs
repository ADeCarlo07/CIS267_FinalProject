using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (movement != Vector2.zero && !PauseMenu.isPaused && !InventoryAndAbilities.buttonPressed)
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SlicePickUp"))
        {
            GameManager.instance.FindSlice();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ShutDownPickUp"))
        {
            GameManager.instance.FindShutDown();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("SeedShotPickUp"))
        {
            GameManager.instance.FindSeedShot();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            if (collision.gameObject.CompareTag("Level01_Enemy01"))
            {
                GameManager.instance.SavePlayerPos(transform.position);
                SceneManager.LoadScene("Level01_CombatGrid01");
            }

            if (collision.gameObject.CompareTag("Level01_Enemy02"))
            {
                GameManager.instance.SavePlayerPos(transform.position);
                SceneManager.LoadScene("Level01_CombatGrid02");
            }

            if (collision.gameObject.CompareTag("Level01_Enemy03"))
            {
                GameManager.instance.SavePlayerPos(transform.position);
                SceneManager.LoadScene("Level01_CombatGrid03");
            }

        }

        if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (collision.gameObject.CompareTag("Level02_Enemy01"))
            {
                GameManager.instance.SavePlayerPos(transform.position);
                SceneManager.LoadScene("Level02_CombatGrid01");
            }

            if (collision.gameObject.CompareTag("Level02_Enemy02"))
            {
                GameManager.instance.SavePlayerPos(transform.position);
                SceneManager.LoadScene("Level02_CombatGrid02");
            }

            if (collision.gameObject.CompareTag("Level02_Enemy03"))
            {
                GameManager.instance.SavePlayerPos(transform.position);
                SceneManager.LoadScene("Level02_CombatGrid03");
            }

        }

        if (SceneManager.GetActiveScene().name == "Level03")
        {
            if (collision.gameObject.CompareTag("Level03_Enemy01"))
            {
                GameManager.instance.SavePlayerPos(transform.position);
                SceneManager.LoadScene("Level03_CombatGrid01");
            }

            if (collision.gameObject.CompareTag("Level03_Enemy02"))
            {
                GameManager.instance.SavePlayerPos(transform.position);
                SceneManager.LoadScene("Level03_CombatGrid02");
            }

            if (collision.gameObject.CompareTag("Level03_Enemy03"))
            {
                GameManager.instance.SavePlayerPos(transform.position);
                SceneManager.LoadScene("Level03_CombatGrid03");
            }
        }

       
    }
}
