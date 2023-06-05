using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject fire;
    public Transform firePos;
    private float timer;
    private GameObject player;
    [SerializeField] Animator anim;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //Starts following
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance<12)
        {
            timer += Time.deltaTime;
        }

        //Attack Timer
        if(timer >2) 
        {
            timer = 0;
            Shoot();
        }
    }
    #region Attack
    void Shoot()
    {
        Instantiate(fire, firePos.position, Quaternion.identity);
        anim.SetTrigger("isAttack");
    }
    #endregion
}//class
