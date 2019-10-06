using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{  
    public Camera FPSCam;
    public Camera LevelCam;

   public void Game()
    {
        LevelCam.enabled = false;
        FPSCam.enabled = true;
    }

}
