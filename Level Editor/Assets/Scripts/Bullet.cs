using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//allows the bulletholes to be disabled after 2 seconds
public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Disable", 2.0f);
    }

    private void Disable()
    {
        this.transform.gameObject.SetActive(false);
    }

}
