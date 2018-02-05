using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KDHOpenDoor : MonoBehaviour {

    public GameObject TileTrigger;
    public Animator charAni;

    KDHOpenDoorTrigger tile;

    public float rotate = 1.0f;
    float rot = 0.0f;
    public float angle = 0.0f;

    public bool isOpen;
    bool isKeyInput = false;
    void Start()
    {
        tile = TileTrigger.GetComponent<KDHOpenDoorTrigger>();
    }

	// Update is called once per frame
	void Update () {

        if(tile.GetisOpen())
        {
            if(Input.GetKey(KeyCode.F) && !isKeyInput)
            {
                //isKeyInput = true;
                RotateDoor();
            }
        }
    }
    
    void RotateDoor()
    {
        iTween.RotateTo(transform.gameObject, new Vector3(0, angle, 0), 1.0f);

        PlayerMove.instance.cor = PlayerMove.instance.SetOffCam(-90);
        StartCoroutine(PlayerMove.instance.cor);
    }
}
