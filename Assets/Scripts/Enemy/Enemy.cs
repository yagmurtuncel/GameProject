using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject lootDrop;
    public int maxHealth =100;
    int currentHealth;
   


    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        anim.SetTrigger("isHurt");

        if(currentHealth <= 0)
        {
            Die();
            Instantiate(lootDrop, transform.position, Quaternion.identity);
        }
    }

    void Die()
    {
        anim.SetBool("isDead", true);
        Destroy(gameObject,2f);
        
        
    }






}
