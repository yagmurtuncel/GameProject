using UnityEngine;

public class PlayerTopDownMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    [SerializeField] Animator anim;
    bool isRunning = false;
    bool facingRight = true;
    
    private Vector2 moveDirection;

    public HealthBar healthBar;
    public GameObject lastPanel, gameOverPanel;
    public AudioSource deathSound;

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(h, v).normalized;

        Move();
        PlayerRunAnimation(h);
        PlayerTurn(h);
    }
    #region Move
    private void Move()
    {
        rb.velocity=new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    #endregion
    #region RunAnimation
    void PlayerRunAnimation(float h)
    {
        if (h != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        anim.SetBool("isRun", isRunning);
    }
    #endregion
    #region Flip
    void PlayerTurn(float h)
    {

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
    }
    public void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    #endregion
    #region TriggerEnter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FinalChest"))
        {
            lastPanel.SetActive(true);
        }
    }
    #endregion
    #region TriggerStay
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Trap" || collision.tag == "Enemy")
        {
            healthBar.Damage(0.0009f);
            if (PlayerHealth.totalHealth <= 0f)
            {
                anim.SetBool("isDead", true);
                deathSound.Play();
                gameOverPanel.SetActive(true);
                Destroy(gameObject, 2f);
            }
        }
    }
    #endregion
}//class
