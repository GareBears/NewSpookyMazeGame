using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject youAreDead;
    [SerializeField] GameObject youHaveWon;
    PlayerCam playerCam;
    private bool isPaused = false;

    private float keys = 0f;

    // Start is called before the first frame update
    void Start()
    {
       playerCam = GameObject.Find("Player Camera").GetComponent<PlayerCam>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
        if (Input.GetKey(KeyCode.LeftControl) && isPaused)
        {
            ResumeGame();
        }
        if (Input.GetKey(KeyCode.P))
        {
            PlayerIsDead();
        }
        if (isPaused == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            playerCam.DisableSound();
        }
        if (isPaused == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerCam.EnableSound();
        }
        if (keys >= 3)
        {
            PlayerHasWon();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        isPaused = false;
    }

    public void ItemUpdate()
    {
        keys = keys + 1;
    }

    public void PlayerIsDead()
    {
        youAreDead.SetActive(true);
        playerCam.DisableSound();
        Time.timeScale = 0f;
        Cursor.visible = true;
        isPaused = true;
    }

    public void PlayerHasWon()
    {
        youHaveWon.SetActive(true);
        playerCam.DisableSound();
        Time.timeScale = 0f;
        Cursor.visible = true;
        isPaused = true;
    }
}
