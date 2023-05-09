using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    [SerializeField] Animator anim;
    bool isRunning = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        Mover(h);
        PlayerRunAnimation(h);
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
}
