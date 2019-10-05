//Inspired by:  toddisarockstar
//https://answers.unity.com/questions/1598974/how-to-make-an-undo-redo-system-in-runtime-with-ga.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    
    public bool chosen;
    LevelEditor level; 
    Transform selectedTrans;

    public class setting {
         public GameObject Obj;
         public Vector3 Pos;
         public Quaternion Rot;
         public bool Deleted;
         
         public void Restore(){
             Obj.transform.position = Pos;
             Obj.transform.rotation = Rot;
             Obj.SetActive (Deleted);
         }
         public setting(GameObject g){
             Obj = g;
             Pos = g.transform.position;
             Rot = g.transform.rotation;
             Deleted = g.activeSelf;
             
         }

        

        
         
    }
     

     public List<setting> UndoList;
     
     public void AddUndo (GameObject g){
         setting s = new setting (g);
         UndoList.Add (s);
     }
     
     public void Undo (){
         if (UndoList.Count > 0) {
             UndoList[UndoList.Count-1].Restore();
             UndoList.RemoveAt(UndoList.Count-1);
         }}
 
     void Start () 
     {
         level = GetComponent<LevelEditor>();
         UndoList = new List<setting> ();
     }

     void Update()
     {
         //for(int i =0; i < level.boxList.Count; i++)
         //{
         //    if(level.boxList[i].transform == selectedTrans)
         //    {
         //        if(Input.GetMouseButton(0))
         //        {
         //           level.boxList[i].transform.localPosition = new Vector3(0f,1f,0f);
         //        }
         //    }
         //}
     }
 
     public void Chosen(bool select, Transform trans)
    {
        chosen = select;
        selectedTrans = trans;
    }

}
