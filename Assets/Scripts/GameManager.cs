using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    public void CloseButton()
    {
        infoPanel.SetActive(false);
    }
}
