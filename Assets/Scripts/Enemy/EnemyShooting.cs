using System.Collections;
using System.Collections.Generic;
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
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance<10)
        {
            timer += Time.deltaTime;
        }

        if(timer >2) 
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(fire, firePos.position, Quaternion.identity);
        anim.SetTrigger("isAttack");
    }
}
