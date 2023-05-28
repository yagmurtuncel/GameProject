using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    public static bool isRestart = false;
    public static bool isStart = true;
    public void CloseButton()
    {
        infoPanel.SetActive(false);
    }
    public void BackMenuButton()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("health", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
    }
    public void RestartGame()
    {
        isRestart = true;
        PlayerHealth.totalHealth=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        SceneManager.LoadScene(PlayerPrefs.GetInt("health"));
        Player.isStart = true;
    }
   
    public void QuitGame()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("health", SceneManager.GetActiveScene().buildIndex);
        Application.Quit();
    }
}
