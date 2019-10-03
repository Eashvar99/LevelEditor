using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{   
    private Factory factory;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        factory = GetComponent<Factory>();
    }

    public void addBox()
    {
         factory.Spawn(obj);
    }
}
