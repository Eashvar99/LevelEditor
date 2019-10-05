using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{   
    private Factory factory;
    public GameObject box;
    public GameObject Enemy;

    public List<GameObject> boxList;
    public List<GameObject> enemyList;

    // Start is called before the first frame update
    void Start()
    {
        factory = GetComponent<Factory>();
    }

    public void addBox()
    {
         boxList.Add(factory.Spawn(box));
    }

    public void addEnemy()
    {
         enemyList.Add(factory.Spawn(Enemy));
    }
}
