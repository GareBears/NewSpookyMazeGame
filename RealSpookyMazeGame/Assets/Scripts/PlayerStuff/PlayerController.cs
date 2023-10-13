using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    SceneManagement sceneManagement;
    private AudioSource audioplayer;

    [Header("Movement")]
    [Header("Ground Check")]
    public float moveSpeed;
    public float playerHeight;
    public float groundDrag;
    public float velocity;
    public LayerMask ground;
    bool grounded;
    public bool isGrounded;

    public bool isPaused = false;

    public Transform orientation;

    private float Life = 3;

    float horizontalInput;
    float verticalInput;

    public Vector3 moveDirection;

    Rigidbody rb;

    /////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sceneManagement = GameObject.Find("SceneManager").GetComponent<SceneManagement>();
        rb = GetComponent<Rigidbody>();
        audioplayer = GetComponent<AudioSource>();
        rb.freezeRotation = true;
        isPaused = false;
    }

    /////////////////////////////////////////////////////////////////////////////////

    private void Update()
    {
        MyInput();
        SpeedControl();
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        if(grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        if (isPaused == true)
        {
            audioplayer.enabled = false;
        }
        else if (isPaused == false)
        {
            audioplayer.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    /////////////////////////////////////////////////////////////////////////////////

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    /////////////////////////////////////////////////////////////////////////////////

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void LoseLife()
    {
        if( Life > 0 )
        {
            Life = Life - 1;
            gameManager.LifeCount();
        }
        if( Life <= 0)
        {
            gameManager.PlayerIsDead();
        }
    }

    public void PlayerPause()
    {
        isPaused = true;
    }

    public void PlayerUNPaused()
    {
        isPaused = false;
    }
}
