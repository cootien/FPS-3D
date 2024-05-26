using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : Singleton<CameraSwitcher>
{

    [SerializeField] private CinemachineVirtualCameraBase vcam;
    [SerializeField] private CinemachineVirtualCameraBase targetCam;


    public void PrimaryCam()
    {
        vcam.Priority = 10;
        targetCam.Priority = 0;

    }
    public void TargetCam()
    {
        vcam.Priority = 0;
        targetCam.Priority = 10;

    }
}
