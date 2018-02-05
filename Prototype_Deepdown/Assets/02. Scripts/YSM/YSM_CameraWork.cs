using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

public class YSM_CameraWork : MonoBehaviour {
    public Text txt;
    public VideoPlayer VideoPlayer;

    private void Start()
    {
        Init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            VideoPlayer.enabled = false;
        }
    }

    private void Init()
    {
        txt.enabled = false;
        //VideoPlayer = GameObject.Find("NearCameraVideo").GetComponent<VideoPlayer>();
        VideoPlayer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Stage"))
        {
            if (VideoPlayer.enabled == false)
            {
                txt.enabled = true;

                if (Input.GetKeyDown(KeyCode.V))
                {
                    Debug.Log("video");
                    txt.enabled = false;
                    VideoPlayer.enabled = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Stage"))
        {
            txt.enabled = false;
        }
    }
}
