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
    

    FlickerControl flickerControl;
    GameManager gameManager;
    PlayerController playerController;

    public bool isFlickeringOK = true;

    private float Life = 3;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        flickerControl = GameObject.Find("PFlasLight").GetComponent<FlickerControl>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        flickerControl = GameObject.Find("PFlasLight").GetComponent<FlickerControl>();
        if (isFlickeringOK == true)
        {
            flickerControl.FlickerOKSettings();
        }
        else if (isFlickeringOK == false)
        {
            flickerControl.FlickerNotOkSettings();
        }
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

    public void LightToggle()
    {
        if (isFlickeringOK == true)
        {
            isFlickeringOK = false;
        }
        else if (isFlickeringOK == false)
        {
            isFlickeringOK = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
        gameManager.GameIsNotRunning();
    }

    public void Level1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
        gameManager.GameIsRunning();
        Life = 3;
    }
}
