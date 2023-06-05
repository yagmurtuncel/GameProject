using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] GameObject lootDrop;
    [SerializeField] GameObject sr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sr.SetActive(false);
            Instantiate(lootDrop, transform.position, Quaternion.identity);
        }
    }
}
