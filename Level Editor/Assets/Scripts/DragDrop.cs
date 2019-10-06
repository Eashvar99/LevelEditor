using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct CommandCoord
{
   public float x,y,z;
   public int item,num;
}


public class DragDrop : MonoBehaviour
{
    //Initialize Variables
    GameObject movingObject;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;
    //Command Design Variables
    static List<CommandCoord> commandPos;
    /////////////////////////////////

    void Start()
    {
        commandPos = new List<CommandCoord>();
    }
    void Update()
    {
        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            movingObject = ReturnClickedObject(out hitInfo);
            if (movingObject != null)
            {
                GameObject temp;
                temp = movingObject;

                if (movingObject.tag == "Moveable")
                {
                    isMouseDragging = true;
                    //Converting world position to screen position.
                    positionOfScreen = Camera.main.WorldToScreenPoint(movingObject.transform.position);
                    offsetValue = movingObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
                }
            }
        }

        //Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;

            CommandCoord save = new CommandCoord();
            save.x = movingObject.transform.localPosition.x;
            save.y = movingObject.transform.localPosition.y;
            save.z = movingObject.transform.localPosition.z;

            if(movingObject.name == "Box")
            {
                save.item = 1;
            }
            else
            {
                save.item = 2;
            }
               
            save.num = 0; //int.Parse(movingObject.tag);

            commandPos.Add(save);

            Debug.Log(commandPos[0].x);
            Debug.Log(commandPos[0].z);
            Debug.Log(commandPos[0].item);
            Debug.Log(commandPos[0].num);
        }

        //Is mouse Moving
        if (isMouseDragging)
        {
            //tracking mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
            //converting screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

            //It will update target gameobject's current postion.
            movingObject.transform.position = currentPosition;
        }
    }

    //Method to Return Clicked Object
    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

}
