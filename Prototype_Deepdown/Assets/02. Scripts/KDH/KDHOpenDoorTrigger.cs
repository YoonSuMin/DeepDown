using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KDHOpenDoorTrigger : MonoBehaviour {

    bool isOpen;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Open");
            isOpen = true;
        }
    }
 
    public bool GetisOpen()
    {
        return isOpen;
    }
}
