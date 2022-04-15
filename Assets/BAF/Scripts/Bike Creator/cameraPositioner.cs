using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPositioner : MonoBehaviour
{
    Camera cam;
    float zoom;
    float mouse;
    float distance;
    [SerializeField] Transform[] bounderers;

    void Start()
    {
        mouse = 4;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        distance = (bounderers[0].position - bounderers[1].position).magnitude;
        cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, zoom - distance - 2);

        zoom = Mathf.Clamp(Mathf.Lerp(zoom, zoom + (Input.mouseScrollDelta.y*20*distance), Time.deltaTime),-25, -1);

        var rot = transform.localEulerAngles;
        rot.x = Mathf.Clamp(rot.x + -Input.GetAxis("Mouse Y")*2 * mouse, 5, 85);
        rot.y += Input.GetAxis("Mouse X") * mouse;
        if(Input.GetMouseButton(1)) transform.localEulerAngles = rot;
    }
}
