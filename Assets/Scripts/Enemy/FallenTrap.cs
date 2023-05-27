using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FallenTrap : MonoBehaviour
{
    [SerializeField] Animator anim;
    public HealthBar healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("isFall");
            healthBar.Damage(0.010f);
            Destroy(gameObject,0.25f);
        }
    }
}
