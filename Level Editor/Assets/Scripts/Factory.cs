using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    //creates new object
    public GameObject Spawn(GameObject obj)
    {
        return Instantiate(obj);
    }
}
