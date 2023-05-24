using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject fire;
    public Transform firePos;
    private float timer;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >2) 
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(fire, firePos.position, Quaternion.identity);
    }
}
