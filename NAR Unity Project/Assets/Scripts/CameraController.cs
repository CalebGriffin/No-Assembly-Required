using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera innerVCam;
    public CinemachineVirtualCamera outerVCam;

    public GameObject firstFloor1;
    public GameObject firstFloor2;


    // Update is called once per frame
    void Update()
    {
        if (firstFloor1.activeSelf == true || firstFloor2.activeSelf == true)
        {
            ZoomOut();
        }
        else
        {
            ZoomIn();
        }
        
    }

    public void ZoomOut()
    {
        outerVCam.m_Priority = 10;
        innerVCam.m_Priority = 9; 
    }

    public void ZoomIn()
    {
        outerVCam.m_Priority = 9;
        innerVCam.m_Priority = 10; 
    }
}
