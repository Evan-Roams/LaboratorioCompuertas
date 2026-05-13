using System.Collections.Generic;
using UnityEngine;

public class MultipleCamSystem : MonoBehaviour
{
    public GameObject[] cameras;
    public int currentCameraID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCameraID = -1;
        nextCam();
    }

    public void nextCam()
    {
        if (currentCameraID+1 > cameras.Length-1)
        {
            currentCameraID = 0;
        }
        else
        {
            currentCameraID = currentCameraID + 1;
        }

        foreach (GameObject cam in cameras)
        {
            cam.SetActive(false);
        }
        cameras[currentCameraID].SetActive(true);

    }

    public void previusCam()
    {
        if (currentCameraID-1 < 0)
        {
            currentCameraID = cameras.Length-1;
        }
        else
        {
            currentCameraID = currentCameraID - 1;
        }

        foreach (GameObject cam in cameras)
        {
            cam.SetActive(false);
        }
        cameras[currentCameraID].SetActive(true);
    }
}
