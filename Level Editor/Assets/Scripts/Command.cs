/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//allow us to

//this class will allow us to create a queue to save a list of actions that have been done
public class Command : MonoBehaviour
{
    static List<GameObject> currentObj;
    static List<GameObject> removedObj;
    static int counter;

    private void Start()
    {
        currentObj = new List<GameObject>();
        currentObj = new List<GameObject>();
    }

    public static void AddCommand(ICommand command)
    {
            while (commandHistory.Count > counter)
            {
            commandHistory.RemoveAt(counter);
            }
        commonBuffer.Enqueue(command);
    }

    void Update()
    {
        if (commonBuffer.Count > 0)
        {
            ICommand c = commonBuffer.Dequeue();
            c.Execute();

            commandHistory.Add(c);
            counter++;
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (counter > 0)
                {
                    counter--;
                    commandHistory[counter].Undo();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (counter < commandHistory.Count)
                {
                    commandHistory[counter].Execute();
                    counter++;
                }
            }
        }
       
    }
}
 */