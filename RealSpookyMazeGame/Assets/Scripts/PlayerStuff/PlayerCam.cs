using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    private AudioListener listener;

    public float sensX;
    public float sensY;

    float xRotation;
    float yRotation;

    public Transform oreientation;

    // Start is called before the first frame update
    private void Start()
    {
        listener = GetComponent<AudioListener>();
        listener.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        oreientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void DisableSound()
    {
        listener.enabled = !listener.enabled;
    }
    public void EnableSound()
    {
        listener.enabled = listener.enabled;
    }
}
