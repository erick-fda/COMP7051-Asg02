using UnityEngine;
using System.Collections;
using System;

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

    /**horizontal camera rotation axis name*/
    private String camRotationHorizontal = "CamRotationHorizontal";

    /**horizontal camera rotation axis name*/
    private String camRotationVertical = "CamRotationVertical";

    // Use this for initialization
    void Start() {
        //detect platform and set approptiate camera movement axis control
        if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) {
            camRotationHorizontal += "_OSX";
            camRotationVertical += "_OSX";
        } else {
            camRotationHorizontal += "_WinLin";
            camRotationVertical += "_WinLin";
        }
    }

    // Update is called once per frame
    void Update() {

    }

    void LateUpdate() {
        float camDistance = Vector3.Distance(cam.position, transform.position);

        //mouse zoom controls
        if ((Input.GetAxis("Zoom") < 0 && camDistance > minZoom) || (Input.GetAxis("Zoom") > 0 && camDistance < maxZoom)) {
            cam.Translate(cam.forward * -Input.GetAxis("Zoom") * zoomSpeed * Time.deltaTime, Space.World);
        }

        //mouse camera rotation control
        if (Input.GetMouseButton(1)) {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * camRotationSpeed * Time.deltaTime);
            transform.Rotate(Vector3.right * -Input.GetAxis("Mouse Y") * camRotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        }

        //rotate camera along y axis while character moving with mouse
        else if (Input.GetMouseButton(0) && Input.touchCount == 0) {
            transform.Rotate(Vector3.right * -Input.GetAxis("Mouse Y") * camRotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        }

        //controller camera rotation
        else if (Input.GetAxis(camRotationHorizontal) != 0 || Input.GetAxis(camRotationVertical) != 0) {
            transform.Rotate(Vector3.up * Input.GetAxis(camRotationHorizontal) * camRotationSpeed * Time.deltaTime);
            transform.Rotate(Vector3.right * -Input.GetAxis(camRotationVertical) * camRotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        }

        //touch camera zoom and rotation controls
        else if (Input.touchCount == 2) {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = (prevTouchDeltaMag - touchDeltaMag) / (Screen.height * .05f);
            if (Math.Abs(deltaMagnitudeDiff) > .02f) {
                if ((deltaMagnitudeDiff < 0 && camDistance > minZoom) || (deltaMagnitudeDiff > 0 && camDistance < maxZoom))
                    cam.Translate(cam.forward * -deltaMagnitudeDiff * 1f * zoomSpeed * Time.deltaTime, Space.World);
            } else {
                transform.Rotate(Vector3.up * touchZero.deltaPosition.normalized.x * camRotationSpeed * Time.deltaTime);
                transform.Rotate(Vector3.right * touchZero.deltaPosition.normalized.y * camRotationSpeed * Time.deltaTime);
                transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
            }

        } 
            

    }
}
