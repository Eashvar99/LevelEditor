using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code by GameDevHQ - Learn Game Dev
//https://www.youtube.com/watch?v=wpq4fYT6J28

//had to make adjustments to try and optimize 
public class PoolManager : MonoBehaviour
{
    public GameObject bulletHole;
    public int spawnCount;
    public List<GameObject> holeList;

    private void Start()
    {
       makeList();
    }

    void makeList()
    {
         for(int i =0; i < spawnCount; i++)
        {
            GameObject temp = Instantiate(bulletHole);   
            holeList.Add(temp);         

            temp.transform.parent = this.transform;
            temp.SetActive(false);
        }
    }
}
