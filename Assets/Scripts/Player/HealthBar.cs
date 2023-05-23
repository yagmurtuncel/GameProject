using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;
    [SerializeField] Animator anim;

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

    
}
