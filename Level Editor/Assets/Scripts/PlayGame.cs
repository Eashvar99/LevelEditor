using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{  
    public Camera cam;

    public void changeCamera()
    {
        cam.transform.localPosition = new Vector3(-0.8f, 15.4f, -27.8f);

    cam.transform.eulerAngles = new Vector3(
    cam.transform.eulerAngles.x - 63.94f,
    cam.transform.eulerAngles.y,
    cam.transform.eulerAngles.z);

    }
}
