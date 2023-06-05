using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject lootDrop;
    public int maxHealth = 100;
    int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    #region Damage
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
    #endregion
    #region Die
    void Die()
    {
        anim.SetBool("isDead", true);
        Destroy(gameObject,1f);
    }
    #endregion

}//class
