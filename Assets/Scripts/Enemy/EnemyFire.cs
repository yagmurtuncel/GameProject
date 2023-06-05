using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    public float force;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        //Fire Movement
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot+ -15); 
    }

    void Update()
    {
        //Fire Timer
        timer += Time.deltaTime;
        if(timer>3)
        {
            Destroy(gameObject);
        }
    }
}//class
