using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject pauseMenu;
    public GameObject Title;
    public GameObject PlayButton;
    public GameObject SettingsButton;
    public GameObject QuitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        Title.SetActive(true);
        PlayButton.SetActive(true);
        SettingsButton.SetActive(true);
        QuitButton.SetActive(true);
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void Settings()
    {
        Title.SetActive(false);
        PlayButton.SetActive(false);
        SettingsButton.SetActive(false);
        QuitButton.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }

    public void Level1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
