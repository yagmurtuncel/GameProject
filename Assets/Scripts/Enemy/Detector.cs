using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] Animator anim;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isAttackk", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isAttackk", false);
        }
    }
}//class
