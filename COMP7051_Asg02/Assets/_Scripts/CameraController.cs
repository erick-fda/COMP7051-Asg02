using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    /**the camera to be moved*/
    public Transform cam;

    /**how sensitive the camera rotation is*/
    public float camRotationSpeed = 100;

    /**how sensitive the camera zo0ming is*/
    public float zoomSpeed = 200;

    /*the closest you can zoom in*/
    public float minZoom = 2;

    /**the furthest you can zoom out*/
    public float maxZoom = 50;

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
