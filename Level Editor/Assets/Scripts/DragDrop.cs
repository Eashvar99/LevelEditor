using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Command command;
    //Initialize Variables
    GameObject movingObject;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;

    void Start()
    {
        command = GetComponent<Command>();
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
                    //command.Chosen(true, temp.transform);

                    isMouseDragging = true;
                    //Converting world position to screen position.
                    positionOfScreen = Camera.main.WorldToScreenPoint(movingObject.transform.position);
                    offsetValue = movingObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
                }
                else {
               // command.Chosen(false,  temp.transform);
                }
            }
        }

        //Right Mouse Button Press Down
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;
            movingObject = ReturnClickedObject(out hitInfo);
            if (movingObject != null)
            {
                if (movingObject.tag == "Moveable")
                {
                    Destroy(movingObject);
                }
            }
        }

        //Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
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
