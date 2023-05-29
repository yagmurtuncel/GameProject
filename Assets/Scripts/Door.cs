using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] Animator anim;
    public static bool doorOpen = false;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Handle.handlePush)
        {
            anim.SetTrigger("doorOpen");
            doorOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(doorOpen)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
