using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public static PlayerMove instance;

    public Quaternion rot;
	public float speed = 5.0f;

	private Vector3 rotateCam;
	public float rotateSpeed = 100.0f;

    private bool isMove = true;
    public bool camCheck = true;

    public IEnumerator cor = null;
    // Use this for initialization
    void Start () {
        instance = this;
	}

	// Update is called once per frame
	void Update () {
        if (!camCheck)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
	}

    public IEnumerator SetOffCam(float angle)
    {
        rotateCam.x = 0.0f;
        isMove = false;
        
        yield return new WaitForSeconds(0.0f);
        rot = Quaternion.Euler(0, rotateCam.x, 0);
        camCheck = false;
        Debug.Log("111");
        transform.rotation = Quaternion.Euler(0, angle, 0);
        
        //transform.position = new Vector3(2, 1.23f, 18);
        Debug.Log("222");
        
        yield return new WaitForSeconds(1.1f);
        
        isMove = true;
        camCheck = true;
    }
}