using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public Transform cam;
    public float camRotationSpeed = 100;
    public float zoomSpeed = 200;
    public float minZoom = 2;
    public float maxZoom = 50;

    private Vector3 offset;
    private Vector3 originalPos;
   
    // Use this for initialization
    void Start() {
       
       
    }

    // Update is called once per frame
    void Update() {
       float camDistance = Vector3.Distance(cam.position, transform.position);
        if ((Input.GetAxis("Zoom") < 0 && camDistance > minZoom) || (Input.GetAxis("Zoom") > 0 && camDistance < maxZoom)) {
            cam.Translate(cam.forward * -Input.GetAxis("Zoom") * zoomSpeed * Time.deltaTime, Space.World);
        }
        
    }

    void LateUpdate() {
        if (Input.GetAxis("CamRotate") != 0) {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * camRotationSpeed * Time.deltaTime);
            transform.Rotate(Vector3.right * -Input.GetAxis("Mouse Y") * camRotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        }

    }
}
