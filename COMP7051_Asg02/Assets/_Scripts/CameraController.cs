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
    void Update()
    {
        float camDistance = Vector3.Distance(cam.position, transform.position);

        //keyboard/mouse zoom
        if ((Input.GetAxis("Zoom") < 0 && camDistance > minZoom) || (Input.GetAxis("Zoom") > 0 && camDistance < maxZoom))
        {
            cam.Translate(cam.forward * -Input.GetAxis("Zoom") * zoomSpeed * Time.deltaTime, Space.World);
        }

        //touch controls zoom
        if (Input.touchCount == 2)
        {
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
            float deltaMagnitudeDiff = (prevTouchDeltaMag - touchDeltaMag) * .01f;

            if ((deltaMagnitudeDiff < 0 && camDistance > minZoom) || (deltaMagnitudeDiff > 0 && camDistance < maxZoom))
            {
                cam.Translate(cam.forward * -deltaMagnitudeDiff * zoomSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    void LateUpdate() {
        if (Input.GetAxis("CamRotate") != 0) {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * camRotationSpeed * Time.deltaTime);
            transform.Rotate(Vector3.right * -Input.GetAxis("Mouse Y") * camRotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        }

        //touch camera rotation
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            Vector2 touchDeltaPosition1 = Input.GetTouch(0).deltaPosition;

            //rotate camera
            if ((touchDeltaPosition1 - touchDeltaPosition).normalized.magnitude < .01f)
          {
                transform.Rotate(Vector3.up * touchDeltaPosition.normalized.x * camRotationSpeed * Time.deltaTime);
                transform.Rotate(Vector3.right * touchDeltaPosition.normalized.y * camRotationSpeed * Time.deltaTime);
                transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
            }
            
            
        }

    }
}
