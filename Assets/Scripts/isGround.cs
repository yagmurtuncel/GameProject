using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGround : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] Rigidbody2D rb;
    public float jumpSpeed = 8f;
    [SerializeField] bool yerdeMiyiz=true;
    [SerializeField] Animator anim;
    
    void Update()
    {
        
        RaycastHit2D carpiyorMu = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, layer);

        if (carpiyorMu)
        {
            yerdeMiyiz = true;
            anim.SetBool("isJump", false);
            
        }
        else
        {
            yerdeMiyiz = false;
            anim.SetBool("isJump", true);
        }
        if (yerdeMiyiz == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
