using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;
    public static bool isRestart = false;
    public static bool isStart = true;

    #region PanelCloseButton
    public void CloseButton()
    {
        infoPanel.SetActive(false);
    }
    #endregion
    #region BackMenuButton
    public void BackMenuButton()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("health", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
    }
    #endregion
    #region Restart
    public void RestartGame()
    {
        isRestart = true;
        PlayerHealth.totalHealth=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
    #region Continue
    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        SceneManager.LoadScene(PlayerPrefs.GetInt("health"));
        Player.isStart = true;
    }
    #endregion
    #region Quit
    public void QuitGame()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("health", SceneManager.GetActiveScene().buildIndex);
        Application.Quit();
    }
    #endregion
}//class
