using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioSource footstepSound;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstepSound.enabled = true;
        }
        else
        {
            footstepSound.enabled = false;
        }
    }
}
