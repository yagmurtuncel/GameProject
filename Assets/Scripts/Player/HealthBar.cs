using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;
    public float healthAmount = 1.0f;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource hurtSound;

    void Start()
    {
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        SetSize(PlayerHealth.totalHealth);
        
    }

    public void Damage(float damage)
    {
        if((PlayerHealth.totalHealth -= damage) >= 0f )
        {
            PlayerHealth.totalHealth -= damage;
            hurtSound.Play();
            anim.SetTrigger("isHurt");
        }
        else
        {
            PlayerHealth.totalHealth = 0f;
        }

        if(PlayerHealth.totalHealth < 0.5f )
        {
            barImage.color = Color.yellow;
        } 
        if(PlayerHealth.totalHealth < 0.3f )
        {
            barImage.color = Color.red;
        }
     
        SetSize(PlayerHealth.totalHealth);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }

    public void Heal(float heal)
    {
        if((PlayerHealth.totalHealth += heal) <1f ) 
        {
            PlayerHealth.totalHealth += heal;
        }
        if (PlayerHealth.totalHealth > 0.3f)
        {
            barImage.color = Color.yellow;
        }if (PlayerHealth.totalHealth > 0.5f)
        {
            barImage.color = Color.green;
        }
        

        SetSize(PlayerHealth.totalHealth);

    }
}
