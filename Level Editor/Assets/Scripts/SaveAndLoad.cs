using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class SaveAndLoad : MonoBehaviour
{
    const string DLL_NAME = "Tutorial2";
 
     [DllImport(DLL_NAME)]
    static extern void locLoad();

    /* [DllImport(DLL_NAME)]
    static extern void locSave([In, Out] Vector4[] vecArray, int vecSize); */

    [DllImport(DLL_NAME)]
    static extern System.IntPtr getPos();

    float[]  loc;

    List<Vector4> test = new List<Vector4>();

    //class objects
    Factory factory;
    //////////////////////
    public GameObject Box;
    public GameObject Enemy;

    List<GameObject> boxList = new List<GameObject>();
    List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {
        factory = GetComponent<Factory>();

        //LoadLocation();
    }

    // Update is called once per frame
    void Update()
    {
/* 
        if (Input.GetKeyUp(KeyCode.O))
        {
            SaveLocation();
        } */
        if (Input.GetKeyUp(KeyCode.P))
        {
            LoadLocation();
        }

    }
    /* public void SaveLocation()
    {
        Debug.Log(level.boxList[0].transform.localPosition.x);
        boxList = level.getBoxList();
        enemyList = level.getEnemyList();

        for(int i = 0; i < boxList.Count; i++)
        {
            Vector4 temp = new Vector4(boxList[i].transform.localPosition.x, boxList[i].transform.localPosition.y, boxList[i].transform.localPosition.z, 1.0f);
            test.Add(temp);
        }

         for(int i =0; i < enemyList.Count; i++)
        {
            Vector4 temp = new Vector4(enemyList[i].transform.localPosition.x, enemyList[i].transform.localPosition.y, enemyList[i].transform.localPosition.z, 2.0f);
            test.Add(temp);
        }

        test.ToArray();
        
        locSave(test.ToArray(), (test.Count * 4));
    }
 */
    public void LoadLocation()
    {
        loc = new float[12];

        locLoad();
        
        Marshal.Copy(getPos(), loc, 0, 12);
 
        int boxNum = 0, enemyNum = 0;

        for(int i = 0; i < 12; i+=4)
        {
            Debug.Log(loc[i+3]);
            
            if(loc[i+3] == 1.0f)
            {
             Debug.Log("Box Spawn");
             boxList.Add(factory.Spawn(Box));
             boxList[boxNum].transform.localPosition = new Vector3(loc[i],loc[i+1], loc[i+2]);
               
               boxNum++;
            }
            else if(loc[i+3] == 2.0f)
            {
               Debug.Log("Enemy Spawn");
               enemyList.Add(factory.Spawn(Enemy));;

               enemyList[enemyNum].transform.localPosition = new Vector3(loc[i],loc[i+1], loc[i+2]);
               
               enemyNum++;
            }
        }
    }

}
