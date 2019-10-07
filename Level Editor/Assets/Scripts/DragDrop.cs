using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code by Learn Everything Fast
//https://www.youtube.com/watch?v=7XdEVawBpo4
public class DragDrop : MonoBehaviour
{
    GameObject movingObj;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 posOfScreen;

    void Update()
    {
        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            movingObj = ReturnClickedObject(out hitInfo);
            //if we actually hit something
            if (movingObj != null)
            {
                GameObject temp;
                temp = movingObj;
                    //check if what hit is the movable objects
                if (movingObj.tag == "Movable")
                {
                    isMouseDragging = true;
                    //Converting world position to screen position.
                    posOfScreen = Camera.main.WorldToScreenPoint(movingObj.transform.position);
                    offsetValue = movingObj.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, posOfScreen.z));
                }
            }
        }

        //Drop the object when we let go Left Button
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
        }

        //Are we dragging the mouse around?
        if (isMouseDragging)
        {
            //tracking mouse position.
            Vector3 currentScreen= new Vector3(Input.mousePosition.x, Input.mousePosition.y, posOfScreen.z);
            //changes the screen pos to worldspace positions
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreen) + offsetValue;

            //update the target position will draggin
            movingObj.transform.position = currentPos;

            //we tried to have it so we can move it from a forward perspective
            //we ran into issues so we had to use a top down instead
        }
    }

    //Check which movable object we hit
    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        //the ray emitting from the mouse postion
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //check if we hit the desired object
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

}
