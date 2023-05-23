using DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    [SerializeField] Animator anim;
    bool isRunning = false;
    bool facingRight = true;
    

    public static bool isStart = true;
    private DialogueHolder dialogue;

    [SerializeField] GameObject infoButton, triggerPanel, doorPanel, howToPlayPanel;

    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        Mover(h);
        PlayerRunAnimation(h);
        PlayerTurn(h);
        
    }

    void Mover(float h)
    {
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
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

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("isAttack", true);
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
    }

   

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Dead(collision);
    //}

    //private void Dead(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        anim.SetTrigger("isDead");
    //        Destroy(gameObject, 2f);
    //    }
    //}

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
        if(collision.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.CompareTag("Trigger"))
        {
            howToPlayPanel.SetActive(true);
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
        SceneManager.LoadScene("Level1");
        
    }






}
