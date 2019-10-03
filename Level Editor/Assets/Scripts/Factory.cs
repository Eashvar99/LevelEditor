using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
     //references the object needed to be produced
    
    //creates new object
    public GameObject Spawn(GameObject obj)
    {
        return Instantiate(obj);
    }
}
