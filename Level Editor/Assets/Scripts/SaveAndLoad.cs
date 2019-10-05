using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class SaveAndLoad : MonoBehaviour
{
    const string DLL_NAME = "Tutorial2";
 
     [DllImport(DLL_NAME)]
    static extern void locLoad();

    [DllImport(DLL_NAME)]
    static extern void locSave([In, Out] Vector4[] vecArray, int vecSize);

    [DllImport(DLL_NAME)]
    static extern System.IntPtr getPos();

    float[]  loc;

    List<Vector4> test = new List<Vector4>();

    Factory factory;
    public GameObject Box;
    public GameObject Enemy;

    List<GameObject> boxList = new List<GameObject>();
    List<GameObject> enemyList = new List<GameObject>();

    //GameObject[] boxList;
    //GameObject[] enemyList;
    void Start()
    {
        factory = GetComponent<Factory>();
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.O))
        {
            SaveLocation();
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            LoadLocation();
        }

    }
    public void SaveLocation()
    {
        Debug.Log("I was pressed");
        Vector4 Test1 = new Vector4(1.344f, 2.345f, 3.456f, 1.0f);
        Vector4 Test2 = new Vector4(4.344f, 5.345f, 6.456f, 2.0f);
        Vector4 Test3 = new Vector4(2.344f, 1.345f, 8.456f, 1.0f);

        test.Add(Test1);
        test.Add(Test2);
        test.Add(Test3);
        test.ToArray();
        
        locSave(test.ToArray(), (test.Count * 4));
    }

    public void LoadLocation()
    {
        loc = new float[12];

        locLoad();
        
        Marshal.Copy(getPos(), loc, 0, 12);
    
        for(int i = 0; i < 12; i++)
        {
            Debug.Log(loc[i]);
        }

       /*  Debug.Log(loc[0]);
        Debug.Log(loc[1]);
        Debug.Log(loc[2]);
        Debug.Log(loc[3]); */

       //// GameObject temp;

       // //temp = factory.Spawn(Box);

       ///*  boxList.Add(factory.Spawn(Box));
       // boxList[0].transform.localPosition = new Vector3(loc[0].x,loc[0].y, loc[0].z);

       // boxList.Add(factory.Spawn(Box));
       // boxList[1].transform.localPosition = new Vector3(loc[0].x + 2.0f,loc[0].y, loc[0].z - 4.0f); */
       // int boxNum = 0, enemyNum = 0;

       // for(int i = 0; i < 3; i++)
       // {
       //     if(loc[i].w == 1.0f)
       //     {
       //        Debug.Log("Box Spawn");
       //        boxList.Add(factory.Spawn(Box));
       //        boxList[boxNum].transform.localPosition = new Vector3(loc[i].x,loc[i].y, loc[i].z);
               
       //        boxNum++;
       //     }
       //     else if(loc[i].w == 2.0f)
       //     {
       //        Debug.Log("Enemy Spawn");
       //        enemyList.Add(factory.Spawn(Enemy));;

       //        enemyList[enemyNum].transform.localPosition = new Vector3(loc[i].x,loc[i].y, loc[i].z);
       //        Debug.Log("Enemy " + enemyNum);

               
       //        enemyNum++;
       //     }
       // }
    }

}
