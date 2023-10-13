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

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;
    public bool has3health = true;
    public bool has2health = false;
    public bool has1health = false;

    private bool isPlayerAlive;
    private bool isPaused = false;
    private bool gameRunning = false;

    private float keys = 0f;
    private float Life = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
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
            //Life = 2;
        }
        if (Input.GetKey(KeyCode.J))
        {
            PlayerHasWon();
        }
        if (keys >= 3)
        {
            PlayerHasWon();
        }

        //LIFE COUNTERS//

        if (Life == 3 && !isPaused)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
            has3health = true;
        }
        else if (Life == 2 && !isPaused)
        {
            Life3.SetActive(false);
            has3health = false;
            has2health = true;
        }
        else if (Life == 1 && !isPaused)
        {
            Life2.SetActive(false);
            has2health = false;
            has1health = true;
        }
        else if (Life == 0 && !isPaused)
        {
            Life1.SetActive(false);
            has1health = false;
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

        Life1.SetActive(false);
        Life2.SetActive(false);
        Life3.SetActive(false);
        Key1.SetActive(false);
        Key2.SetActive(false);
        Key3.SetActive(false);

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

        Key1.SetActive(true);
        Key2.SetActive(true);
        Key3.SetActive(true);

        if(has3health == true)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
        }
        else if (has2health == true)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
        }
        else if (has1health == true)
        {
            Life1.SetActive(true);
        }

        isPaused = false;
    }

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
        Life1.SetActive(false);
        Life2.SetActive(false);
        Life3.SetActive(false);
        isPaused = true;
        playerController.PlayerPause();
    }

    public void PlayerHasWon()
    {
        Cursor.lockState = CursorLockMode.Confined;
        enemyAI.AudioPause();
        GameIsNotRunning();
        youHaveWon.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Life1.SetActive(false);
        Life2.SetActive(false);
        Life3.SetActive(false);
        isPaused = true;
        playerController.PlayerPause();
    }

    public void LifeCount()
    {
        Life = Life - 1;
    }
}
