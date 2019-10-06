using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;   

public class LevelEditor : MonoBehaviour
{   
     [DllImport(DLL_NAME)]
    static extern void locLoad([In, Out] int size);

    [DllImport(DLL_NAME)]
    static extern System.IntPtr getPos();

    [DllImport(DLL_NAME)]
    static extern int getSize();

    const string DLL_NAME = "Tutorial2";
     [DllImport(DLL_NAME)]
    static extern void locSave([In, Out] Vector4[] vecArray, int vecSize);

    private Factory factory;
    public GameObject box;
    public GameObject Enemy;

    private GameObject temp;
    static private List<GameObject> boxList = new List<GameObject>();
    static private List<GameObject> enemyList = new List<GameObject>();
    
    List<Vector4> test = new List<Vector4>();
    Vector4 tempVec;
    
    float[] loc;

    int size;

    public Camera FPSCam;
    public Camera levelCam;

    int boxNum;
    int enemyNum;
    // Start is called before the first frame update
    void Start()
    {
        factory = GetComponent<Factory>();
        FPSCam.enabled = false;
        levelCam.enabled = true;
        boxNum = 0;
        enemyNum = 0;
    }

    void Update()
    {
        size = (test.Count * 4);
    }

    public void addBox()
    {
        boxNum++;
        temp = factory.Spawn(box);
        temp.name = "Box";
        //temp.tag = boxNum.ToString();
        boxList.Add(temp);
    }

    public void addEnemy()
    {
        enemyNum++;
        temp = factory.Spawn(Enemy);
        temp.name = "Enemy";
        enemyList.Add(temp);
    }

    public void SaveLocation()
    {
         for(int i = 0; i < boxList.Count; i++)
        {
            tempVec = new Vector4(boxList[i].transform.localPosition.x, boxList[i].transform.localPosition.y, boxList[i].transform.localPosition.z, 1.0f);
            test.Add(tempVec);
        } 

         for(int i = 0; i < enemyList.Count; i++)
        {
            tempVec = new Vector4(enemyList[i].transform.localPosition.x, enemyList[i].transform.localPosition.y, enemyList[i].transform.localPosition.z, 2.0f);
            test.Add(tempVec);
        } 

        test.ToArray();
        
        locSave(test.ToArray(), (test.Count * 4));

    }

    public void LoadLocation()
    {
        boxList.Clear();
        enemyList.Clear();

        size = getSize();

        Debug.Log(size);

        loc = new float[size];

        locLoad(size);
        
        Marshal.Copy(getPos(), loc, 0, size);
 
        int boxNum = 0, enemyNum = 0;

        for(int i = 0; i < size; i+=4)
        {
            if(loc[i+3] == 1.0f)
            {
             boxList.Add(factory.Spawn(box));
             boxList[boxNum].transform.localPosition = new Vector3(loc[i],loc[i+1], loc[i+2]);
               
               boxNum++;
            }
            else if(loc[i+3] == 2.0f)
            {
               enemyList.Add(factory.Spawn(Enemy));;

               enemyList[enemyNum].transform.localPosition = new Vector3(loc[i],loc[i+1], loc[i+2]);
               
               enemyNum++;
            }
        }
    }

}
