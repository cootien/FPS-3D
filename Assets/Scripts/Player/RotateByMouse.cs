using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    public float anglePerSecond;
    public float minPitch;
    public float maxPitch;

    private float pitch;

    public float mouseSensitivity = 100f;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        UpdatePitch();
        UpdateYaw();
    }
    private void UpdateYaw()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float deltaYaw = mouseX * anglePerSecond;
        transform.Rotate(0, deltaYaw, 0);
    }

    void UpdatePitch()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaPitch = -mouseY * anglePerSecond;
        pitch = Mathf.Clamp(pitch + deltaPitch, minPitch, maxPitch);
        cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);

    }
}
