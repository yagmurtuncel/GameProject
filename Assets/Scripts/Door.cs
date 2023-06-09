using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject doorInfoPanel;
    public static bool doorOpen;

    private void Start()
    {
        doorOpen = false;
        Handle.handlePush = false;
    }
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
        else
        {
            doorInfoPanel.SetActive(true);
        }
        return;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!doorOpen)
        {
            doorInfoPanel.SetActive(false);
        }
    }
}//class
