using UnityEngine;

public class Handle : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject triggerPanel;

    public static bool handlePush = false;
    private void Update()
    {
        OpenDoor();
    }
    public void OpenDoor()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("handlePush");
            handlePush = true;
            triggerPanel.SetActive(false);
        }
    }
}//class
