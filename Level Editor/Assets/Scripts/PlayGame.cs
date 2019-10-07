using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{  
    public Camera FPSCam;
    public Camera LevelCam;

    public Canvas canvas;

    public Transform player;

    void Start()
    {
        canvas = GameObject.FindObjectOfType<Canvas>();
    }
    
    void Update()
    {
        if(FPSCam.enabled)
        {
          if(Input.GetKey(KeyCode.Escape))
            {
                canvas.enabled = true;
                FPSCam.enabled = false;
                LevelCam.enabled = true;
                player.transform.position = new Vector3(0,-1.5f,0);

                Cursor.lockState = CursorLockMode.None;
                 Cursor.visible = true;
            }
        }
    }
   public void Game()
    {
        player.position = new Vector3(0,1.5f,0);

        canvas.enabled = false;
        LevelCam.enabled = false;
        FPSCam.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

}
