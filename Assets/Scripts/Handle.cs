using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject triggerPanel;
    

    
    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("handlePush");
            triggerPanel.SetActive(false);
            
        }
    }

  
}
