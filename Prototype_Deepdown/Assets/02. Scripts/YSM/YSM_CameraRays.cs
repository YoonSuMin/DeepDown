using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSM_CameraRays : MonoBehaviour {
    public Camera mainCamera;

    public RaycastHit rayHit;
    public Ray ray;

    public float MAX_RAY_DISTANCE;

    void Start()
    {
        InitVar();
    }

    void Update () {
        CameraRay();
	}

    void CameraRay()
    {
        ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

        if (Physics.Raycast(ray, out rayHit, MAX_RAY_DISTANCE))
            Debug.DrawLine(ray.origin, rayHit.point, Color.red);
    }

    void InitVar()
    {
        rayHit = new RaycastHit();
        MAX_RAY_DISTANCE = 500.0f;
    }
}
