using UnityEngine;

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
}//class
