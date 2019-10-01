using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{   
    private Factory factory;


    // Start is called before the first frame update
    void Start()
    {
        factory = GetComponent<Factory>();
    }

    public void addBox()
    {
         factory.Spawn();
    }
}
