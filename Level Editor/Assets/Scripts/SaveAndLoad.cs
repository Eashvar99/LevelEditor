using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class SaveAndLoad : MonoBehaviour
{
    const string DLL_NAME = "Tutorial2";

    [DllImport(DLL_NAME)]
    static extern Vector4[] locLoad();

    [DllImport(DLL_NAME)]
    static extern void locSave([In, Out] Vector4[] vecArray, int vecSize);
    
    Vector4[]  loc;

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

        LoadLocation();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.O))
        {
            SaveLocation();
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
        
        locSave(test.ToArray(), test.Count);
    }

    public void LoadLocation()
    {
        loc = locLoad();

        Debug.Log(loc[0].x + " " + loc[0].y + " " + loc[0].z + " " + loc[0].w);
        Debug.Log(loc[1].x + " " + loc[1].y + " " + loc[1].z + " " + loc[1].w);
        Debug.Log(loc[2].x + " " + loc[2].y + " " + loc[2].z + " " + loc[2].w);
        Debug.Log(loc.Length);

       // GameObject temp;

        //temp = factory.Spawn(Box);

       /*  boxList.Add(factory.Spawn(Box));
        boxList[0].transform.localPosition = new Vector3(loc[0].x,loc[0].y, loc[0].z);

        boxList.Add(factory.Spawn(Box));
        boxList[1].transform.localPosition = new Vector3(loc[0].x + 2.0f,loc[0].y, loc[0].z - 4.0f); */
        int boxNum = 0, enemyNum = 0;

        for(int i = 0; i < 3; i++)
        {
            if(loc[i].w == 1.0f)
            {
               Debug.Log("Box Spawn");
               boxList.Add(factory.Spawn(Box));
               boxList[boxNum].transform.localPosition = new Vector3(loc[i].x,loc[i].y, loc[i].z);
               
               boxNum++;
            }
            else if(loc[i].w == 2.0f)
            {
               Debug.Log("Enemy Spawn");
               enemyList.Add(factory.Spawn(Enemy));;

               enemyList[enemyNum].transform.localPosition = new Vector3(loc[i].x,loc[i].y, loc[i].z);
               Debug.Log("Enemy " + enemyNum);

               
               enemyNum++;
            }
        }
    }

}
