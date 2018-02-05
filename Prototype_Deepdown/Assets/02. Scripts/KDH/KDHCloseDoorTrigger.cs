using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KDHCloseDoorTrigger : MonoBehaviour {

    //public static KDHCloseDoorTrigger instance;

    public GameObject pMo;

    bool isOpen;
    PlayerMove Pmove;
    public Transform Tele;
    public Transform OpenDoor;
    public float CamY = 0.0f;

    bool isFirst = true;

    void Start()
    {
        //instance = this;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {  
            if(isFirst)
            {
                isOpen = true;
                Pmove = col.GetComponent<PlayerMove>();
                StartCoroutine(TelePortPlayer(col.gameObject));

                Pmove.rot = Quaternion.Euler(0, CamY, 0);
                Pmove.transform.rotation = Pmove.rot;
                col.transform.position = Tele.position;

                iTween.RotateTo(col.gameObject, Vector3.zero, 0.0f);
                PlayerMove.instance.camCheck = true;


                //////////////////////////////////////////////////////////////
                iTween.RotateTo(OpenDoor.gameObject, new Vector3(0, 90, 0), 3.0f);
                isFirst = false;
            }
        }
    }

    public bool GetisOpen()
    {
        return isOpen;
    }

    IEnumerator TelePortPlayer(GameObject obj)
    {
        yield return new WaitForSeconds(0.0f);
        Debug.Log("3333");
        
        //obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        

        //obj.GetComponent<PlayerMove>().cor = obj.GetComponent<PlayerMove>().SetOffCam(-90);
        StopCoroutine(obj.GetComponent<PlayerMove>().cor);
       
    }
}
