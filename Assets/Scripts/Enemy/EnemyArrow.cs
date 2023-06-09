using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private float timer;

    void Start()
    {
        //Arrow Movement
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * force;
    }
    void Update()
    {
        //Shoot Timer
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);
        }
    }
}//class