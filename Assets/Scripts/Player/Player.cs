
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] Animator anim;
    bool isRunning = false;
    bool facingRight = true;
    

    public static bool isStart = true;
    public HealthBar healthBar;

    [SerializeField] GameObject infoButton, triggerPanel, howToPlayPanel, gameoverPanel;
    [SerializeField] AudioSource deathSound;

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Mover(h);
        PlayerRunAnimation(h);
        PlayerTurn(h);
        
    }

    void Mover(float h)
    {
        rb.velocity=new Vector2(h*speed*Time.deltaTime, rb.velocity.y);
    }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Books"))
        {
           infoButton.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Handle"))
        {
            triggerPanel.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            anim.SetTrigger("doorOpen");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.CompareTag("Trigger"))
        {
            howToPlayPanel.SetActive(true);
        }
        if (collision.tag == "Trap")
        {
            healthBar.Damage(0.0009f);
            if (PlayerHealth.totalHealth <= 0f)
            {
                anim.SetBool("isDead", true);
                deathSound.Play();
                gameoverPanel.SetActive(true);
                Destroy(gameObject, 1f);
            }
        }
        if(collision.tag == "Heal")
        {
            healthBar.Heal(0.05f);
            Destroy(collision.gameObject,1f);
        }
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "FireTrap")
        {
            healthBar.Damage(0.0009f);
            if (PlayerHealth.totalHealth <= 0f)
            {
                
                anim.SetBool("isDead", true);
                deathSound.Play();
                gameoverPanel.SetActive(true);
                Destroy(gameObject, 2f);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Books"))
        {
            infoButton.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Handle"))
        {
            triggerPanel.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Trigger"))
        {
            howToPlayPanel.SetActive(false);
        }
    }
  
   
    public void PlayGame()
    {
        SceneManager.LoadScene("FirstScene");
        PlayerHealth.totalHealth = 1f;
        
    }






}
