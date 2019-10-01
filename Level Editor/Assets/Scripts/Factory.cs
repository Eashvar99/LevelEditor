using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
     //references the object needed to be produced
    public GameObject model;
    
    //creates new object
    public GameObject Spawn()
    {
        return Instantiate(model);
        
    }
}
