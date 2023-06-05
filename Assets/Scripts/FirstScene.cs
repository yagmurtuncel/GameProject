using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Level1");
    }
}//class
