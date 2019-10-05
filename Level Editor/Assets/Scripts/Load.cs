using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    LevelEditor level;
    // Start is called before the first frame update
    void Start()
    {
        level = new LevelEditor();
        level.LoadLocation();
    }
}
