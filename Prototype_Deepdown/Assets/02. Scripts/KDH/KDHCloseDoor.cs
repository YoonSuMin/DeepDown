using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KDHCloseDoor : MonoBehaviour
{
   
    public GameObject TileTrigger;
 

    KDHCloseDoorTrigger tile;


    public float rotate = 1.0f;
    float rot = 0.0f;
    float angle = 0.0f;

    public bool isOpen;
    bool isClose = false;

    void Start()
    {
        tile = TileTrigger.GetComponent<KDHCloseDoorTrigger>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (tile.GetisOpen() && !isClose)
        {
            isClose = true;
            RotateCloseDoor();
        }
    }

    void RotateCloseDoor()
    {
        //angle++;
        //Vector3 rot = transform.eulerAngles;
        //rot.y += rotate;
        //transform.eulerAngles = rot;
        //if (angle < 90)
        //    Invoke("RotateCloseDoor", Time.deltaTime);
        //Quaternion rot = transform.rotation;
        //transform.rotation = Quaternion.Slerp(rot, Quaternion.Euler(rot.x, rot.y + (angle * 2), rot.z), 5.0f * Time.deltaTime);

        iTween.RotateTo(transform.gameObject, new Vector3(0, angle, 0), 3.0f);

        //StartCoroutine(KDHCloseDoorTrigger.instance.TelePortPlayer());
    }


}
