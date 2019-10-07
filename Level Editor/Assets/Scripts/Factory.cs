using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this Factory class will hold our main Spawning function
public class Factory : MonoBehaviour
{
    public GameObject box;
    public GameObject enemy;

    //creates new object
    public GameObject Spawn(GameObject obj)
    {
        return Instantiate(obj);
    }
}

//allows us to institate Box objects
class Box : Factory
{
    public GameObject spawnBox()
    {
        return Spawn(box);
    }
}

//allows us to institate Box objects
class Enemy : Factory
{
    public GameObject spawnEnemy()
    {
        return Spawn(enemy);
    }
}
