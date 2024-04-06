using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateByMouse : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    public float anglePerSecond;
    //anglerPerSecond : how many degrees the camera should rotate per second based on mouse's movement.

    public float minPitch;
    public float maxPitch;

    private float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // locked
        Cursor.visible = false; // hide cursor in game 
    }
    private void Update()
    {
        UpdateYaw();
        UpdatePitch();
    }
    private void UpdateYaw() //xoay ngang
    {
        float mouseX = Input.GetAxis("Mouse X");
        float yaw = mouseX * anglePerSecond;
        transform.Rotate(0, yaw, 0); // placed on Y position
        //in 3d, turning left & right is based on Y axis ( truc doc )
    }
    private void UpdatePitch() // looking up & down
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaPitch = -mouseY * anglePerSecond; // current pitch
        //the negative in mouseY : when mouse Y down => the vertical ( camera looks up & vice versa )
        //adding the negative to invert the direction

        pitch = Mathf.Clamp(pitch + deltaPitch, minPitch, maxPitch);
        //mathf.Clamp : is to ensure the result pitch stays within a specified range.
        // pitch + deltaPitch : keep updating the current pitch into next move 
        cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);      
    }
}
