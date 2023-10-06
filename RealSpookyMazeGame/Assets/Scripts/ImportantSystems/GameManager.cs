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
    EnemyAI enemyAI;
    PlayerController playerController;

    private bool isPaused = false;
    private bool gameRunning = false;

    private float keys = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        enemyAI = GameObject.Find("Enemy").GetComponent<EnemyAI>();
        enemyAI.AudioUNPause();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape) && isPaused == false|| Input.GetKey(KeyCode.U) && isPaused == false)
        {
            PauseGame();
            //PauseGame();
        }
        if (Input.GetKey(KeyCode.Escape) && isPaused == true || Input.GetKey(KeyCode.U) && isPaused == true)
        {
            //StartCoroutine(Resumegame());
            //ResumeGame();
        }
        if (Input.GetKey(KeyCode.P))
        {
            PlayerIsDead();
        }
        //if (isPaused == true)
        //{
            //Cursor.lockState = CursorLockMode.Confined;
        //}
        //if (isPaused == false)
        //{
            //Cursor.lockState = CursorLockMode.Locked;
        //}
        if (keys >= 3)
        {
            PlayerHasWon();
        }
    }

    public void GameIsRunning()
    {
        gameRunning = true;
    }

    public void GameIsNotRunning()
    {
        gameRunning = false;
    }

    public void PauseGame()
    {
        enemyAI.AudioPause();
        playerController.PlayerPause();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //yield return new WaitForSeconds(0.05f);
        //yield return null;
        isPaused = true;
    }

    public void ResumeGame()
    {
        enemyAI.AudioUNPause();
        playerController.PlayerUNPaused();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }

    //IEnumerator Resumegame()
    //{
    //enemyAI.AudioUNPause();
    //playerController.PlayerUNPaused();
    //pauseMenu.SetActive(false);
    //Time.timeScale = 1f;
    //Cursor.visible = false;
    //Cursor.lockState = CursorLockMode.Locked;
    //yield return new WaitForSeconds(0.05f);
    //yield return null;
    //isPaused = false;
    //}

    public void ItemUpdate()
    {
        keys = keys + 1;
    }

    public void PlayerIsDead()
    {
        Cursor.lockState = CursorLockMode.Confined;
        enemyAI.AudioPause();
        GameIsNotRunning();
        youAreDead.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        isPaused = true;
    }

    public void PlayerHasWon()
    {
        Cursor.lockState = CursorLockMode.Confined;
        enemyAI.AudioPause();
        GameIsNotRunning();
        youHaveWon.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        isPaused = true;
    }
}
