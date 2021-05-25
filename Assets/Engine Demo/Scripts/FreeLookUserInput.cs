using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class FreeLookUserInput : MonoBehaviour
{

  private bool canDrag = false;
    // private bool _freeLookActive;
    public CinemachineFreeLook[] freeLookCameras;
     // Use this for initialization
     private void Start()
     {
       freeLookCameras = GetComponentsInChildren<CinemachineFreeLook>();
       // CinemachineCore.GetInputAxis = GetInputAxis;
     }

    private void Update()
    {
      for (int i = 0; i < freeLookCameras.Length; i++)
      {
        UpdateFreeLookAxis(freeLookCameras[i]);
      }
    }

    public void ResetCamera(CinemachineFreeLook freeLookCamera)
    {
      freeLookCamera.m_RecenterToTargetHeading.RecenterNow();
    }

    private void UpdateFreeLookAxis(CinemachineFreeLook freeLookCamera)
    {
      var xAxisState = freeLookCamera.m_XAxis;
      var yAxisState = freeLookCamera.m_YAxis;
      if (Input.GetMouseButtonDown(0))
      {

      canDrag = !EventSystem.current.IsPointerOverGameObject();

      }

      if (Input.GetMouseButtonUp(0))
      {

        canDrag = false;

      }

    if (canDrag) // 0 = left mouse btn or 1 = right
      {
        yAxisState.m_InputAxisValue = Input.GetAxis("Mouse Y");
        xAxisState.m_InputAxisValue = Input.GetAxis("Mouse X");
    }
      else
      {
        yAxisState.m_InputAxisValue = 0;
        xAxisState.m_InputAxisValue = 0;
      }

      freeLookCamera.m_YAxis = yAxisState;
      freeLookCamera.m_XAxis = xAxisState;
  }

    //private float GetInputAxis(string axisName)
    //{
    //    return !_freeLookActive ? 0 : Input.GetAxis(axisName == "Mouse Y" ? "Mouse Y" : "Mouse X");
    //}
}
