using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 2f;
    public LayerMask enemyLayers;
    [SerializeField] AudioSource swordSound;

    public int attackDamage = 20;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }
    #region Attack
    void Attack()
    {
        swordSound.Play();
        anim.SetTrigger("isAttack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    #endregion
    #region SwordGizmos
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    #endregion
}//class
