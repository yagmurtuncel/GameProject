using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTopDownMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Inputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2 (moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity=new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
