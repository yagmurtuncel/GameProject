using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Level1");
    }
}
